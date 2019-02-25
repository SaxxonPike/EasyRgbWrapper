using System;
using System.Windows.Forms;

namespace EasyRgbWrapper.Gui.Controls
{
    public class ControlForm : IControlForm, IDisposable
    {
        private readonly PropertyGrid _editControl;
        private readonly ToolStrip _toolStrip;
        private readonly ToolStripButton _saveButton;
        
        public event EventHandler SaveClicked;
        
        private bool _disposed;

        public ControlForm()
        {
            Form = new Form
            {
                FormBorderStyle = FormBorderStyle.Sizable
            };
            
            _editControl = new PropertyGrid {Dock = DockStyle.Fill};
            _toolStrip = new ToolStrip();
            _saveButton = new ToolStripButton {Text = "Save"};
            _saveButton.Click += (sender, e) => SaveClicked?.Invoke(sender, e);
            _toolStrip.Items.Add(_saveButton);
            
            Form.Controls.Add(_toolStrip);
            Form.Controls.Add(_editControl);
        }

        private bool IsDisposed 
            => _disposed || _editControl.IsDisposed;

        public object Subject
        {
            get
            {
                if (IsDisposed)
                    return null;
                return _editControl.SelectedObject;
            }
            set
            {
                if (IsDisposed)
                    return;
                _editControl.BeginInvoke(new Action(() =>
                {
                    _editControl.SelectedObject = value;
                }));
            }
        }

        public Form Form { get; }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                Form?.Dispose();
            }
        }
    }
}