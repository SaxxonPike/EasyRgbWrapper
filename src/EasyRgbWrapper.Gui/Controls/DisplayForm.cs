using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Datapath.RGBEasy;
using EasyRgbWrapper.Gui.Logic;
using EasyRgbWrapper.Lib;

namespace EasyRgbWrapper.Gui.Controls
{
    public class DisplayForm : IDisplayForm, IDisposable
    {
        private readonly Form _parentForm;
        private readonly IRgbEasyCapture _capture;
        private readonly ICaptureSwitcher _captureSwitcher;
        private readonly IDialogFactory _dialogFactory;
        private int _scale = 1;

        public event KeyEventHandler KeyDown;
        public event EventHandler GotFocus;
        
        public DisplayForm(Form parentForm, IRgbEasyCapture capture, ICaptureSwitcher captureSwitcher,
            IDialogFactory dialogFactory)
        {
            _parentForm = parentForm;
            _capture = capture;
            _captureSwitcher = captureSwitcher;
            _dialogFactory = dialogFactory;
            Form = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedSingle
            };

            Form.FormClosing += FormOnFormClosing;
            Form.Shown += FormOnShown;
            Form.GotFocus += FormOnGotFocus;
            Form.KeyDown += FormOnKeyDown;
            Form.Paint += FormPaint;
            Form.DoubleClick += FormDoubleClick;
            capture.ModeChanged += CaptureOnModeChanged;
            parentForm.AddOwnedForm(Form);

            Form.Text = $"Vision - {capture.Input + 1}";
        }

        private void FormDoubleClick(object? sender, EventArgs e)
        {
            var tempName = Path.GetTempFileName();
            _capture.Pause();
            _capture.SaveCurrentFrame(tempName);
            _capture.Resume();
            using var bmp = new Bitmap(tempName);
            var dialog = _dialogFactory.GetSave();
            dialog.Filters = "PNG files|*.png";
            dialog.FileName = $"{DateTime.Now:yyyyMMdd-HHmmss}.png";
            if (dialog.Show() == DialogResult.OK)
            {
                bmp.Save(dialog.FileName, ImageFormat.Png);
            }
            bmp?.Dispose();
            File.Delete(tempName);
        }

        private void FormPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = SmoothingMode.None;
            e.Graphics.CompositingMode = CompositingMode.SourceCopy;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
        }

        private void FormOnKeyDown(object sender, KeyEventArgs e)
        {
            KeyDown?.Invoke(this, e);
            if (e.Handled)
                return;

            if (_capture.CaptureState != CAPTURESTATE.CAPTURING)
                return;

            switch (e.KeyCode)
            {
                case Keys.Down:
                {
                    if (_capture.VerticalPosition > _capture.VerticalPositionMinimum)
                        _capture.VerticalPosition--;
                    break;
                }
                case Keys.Up:
                {
                    if (_capture.VerticalPosition < _capture.VerticalPositionMaximum)
                        _capture.VerticalPosition++;
                    break;
                }
                case Keys.Right:
                {
                    if (e.Shift && !e.Control)
                    {
                        if (_capture.HorizontalScale < _capture.HorizontalScaleMaximum)
                            _capture.HorizontalScale++;
                    }
                    else if (!e.Shift && e.Control)
                    {
                        if (_capture.Phase < _capture.PhaseMaximum)
                            _capture.Phase++;
                    }
                    else if (!e.Shift && !e.Control)
                    {
                        if (_capture.HorizontalPosition > _capture.HorizontalPositionMinimum)
                            _capture.HorizontalPosition--;
                    }

                    break;
                }
                case Keys.Left:
                {
                    if (e.Shift && !e.Control)
                    {
                        if (_capture.HorizontalScale > _capture.HorizontalScaleMinimum)
                            _capture.HorizontalScale--;
                    }
                    else if (!e.Shift && e.Control)
                    {
                        if (_capture.Phase > _capture.PhaseMinimum)
                            _capture.Phase--;
                    }
                    else if (!e.Shift && !e.Control)
                    {
                        if (_capture.HorizontalPosition < _capture.HorizontalPositionMaximum)
                            _capture.HorizontalPosition++;
                    }

                    break;
                }
                case Keys.Oemplus:
                {
                    _scale++;
                    UpdateFormGeometry(false);
                    break;
                }
                case Keys.OemMinus:
                {
                    if (_scale > 1)
                        _scale--;
                    UpdateFormGeometry(false);
                    break;
                }
            }
        }

        private void FormOnGotFocus(object sender, EventArgs e) =>
            GotFocus?.Invoke(this, e);

        private void FormOnShown(object sender, EventArgs e)
        {
            Form.PerformLayout();
            Form.Location = new Point(0, 0);
            Form.Visible = true;
            UpdateFormGeometry(true);
            _capture.Window = Form.Handle;
        }

        private void FormOnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Don't close these, minimize them instead
                e.Cancel = true;
                Form.WindowState = FormWindowState.Minimized;
                return;
            }

            _parentForm.RemoveOwnedForm(Form);
        }

        private bool IsDisposed { get; set; }

        private Form Form { get; }

        public bool Visible
        {
            get => Form.Visible;
            set => Form.Visible = value;
        }

        public IntPtr Handle => Form.Handle;

        public int Scale
        {
            get { return _scale; }
            set
            {
                if (value > 0)
                {
                    _scale = value;
                    UpdateFormGeometry(false);
                }
            }
        }

        public void Dispose()
        {
            if (!IsDisposed)
            {
                IsDisposed = true;
                Form?.Dispose();
            }
        }

        private void UpdateFormGeometry(bool reload)
        {
            if (reload)
            {
                var info = _capture.ModeInfo;
                if (info.State == CAPTURESTATE.CAPTURING)
                {
                    var parameters = _captureSwitcher
                        .Switch(_capture, info.TotalLines, info.LineRate, info.RefreshRate);
                    _scale = parameters.Scale ?? 1;
                    if (_scale < 1)
                        _scale = 1;
                }
            }

            var height = _capture.CaptureHeight;
            Form.BeginInvoke(
                new Action(() => { Form.ClientSize = new Size(height * 4 * _scale / 3, height * _scale); }));
        }

        private void CaptureOnModeChanged(object sender, RgbEasyModeChangedEventArgs e)
        {
            Debug.WriteLine(
                $"Mode changed: totalLines={e.Info.TotalNumberOfLines} vRate={e.Info.LineRate} hRate={e.Info.RefreshRate}");
            Debug.WriteLine(
                $"Capture: hPos={e.Capture.HorizontalPosition} hScale={e.Capture.HorizontalScale} vPos={e.Capture.VerticalPosition}");
            Debug.WriteLine($"Capture: width={e.Capture.CaptureWidth} height={e.Capture.CaptureHeight}");

            UpdateFormGeometry(true);
        }
    }
}