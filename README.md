# EasyRgbWrapper

This expands on the RGBEasy API that is provided by Datapath, for use with supported Datapath capture cards.

## EasyRgbWrapper.Gui

**Requires [.NET Framework 4.8](https://dotnet.microsoft.com/download)**

A GUI utility for saving, auto-recalling (based on input display parameters such as resolution and refresh), and displaying Datapath
capture parameters. Currently it is locked to a 4:3 display ratio - this should be customizable in a future release.

A window will be opened for each available Datapath input, regardless if they're capturing anything. These windows can be closed; they will simply minimize.

When focusing a capture window, the property grid will update with that input's information. You can then modify the properties of that particular input.

Closing the property grid will close the application, unlike closing the capture windows. But this window can be minimized and resized.

Some keyboard shortcuts are available for you when you have a capture focused:

- Up/Down/Left/Right arrow keys
  - Adjusts the capture's position (Vertical/Horizontal Position parameters)
- Shift + Left/Right arrow keys
  - Adjusts the capture's line capture frequency (Horizontal Scale parameter)
- Ctrl + Left/Right arrow keys
  - Adjusts the capture's phase (Phase parameter)

The parameters for a capture can be saved at any time by focusing the capture window you would like to save the parameters for, clicking the property window's title, then clicking Save. (This will be more intuitive later.) Each time a resolution changes, these saved settings will be queried and automatically applied if there are saved settings. The key used for settings is Lines+HSync+VSync.

Saved settings are stored in `capture.json`.

## EasyRgbWrapper.Lib

The meat of the project. This is actually a wrapper *for* the wrapper provided by Datapath. It provides sturctured exception handling
and proper Dispose patterns in case something goes wrong.

To use the API:

```
// create a context
var context = new RgbEasyContext();

// select an input, we'll use the first one
var input = context.Inputs[0];

// open a capture
var capture = input.OpenCapture();

// set the capture to a form
var form = new Form();
capture.Window = form.Handle;
```

Inputs can be enumerated and don't need to be disposed. You can quickly identify the inputs that are currently receiving a signal like so:

```
var inputsWithSignal = context.Inputs.Where(i => i.Signal.Type != SIGNALTYPE.NOSIGNAL);
```

Anything with a display area should be assignable to a capture's `Window` property - a PictureBox, for example, should work.

Be sure to clean up after you're done:

```
// dispose of all captures first, then the context
capture.Dispose();
context.Dispose();
```

Errors that happen during use of the API are wrapped into structured exceptions as the type `RgbEasyException` so they are easy to catch, identify and rectify. The `RgbError` property will contain the error code directly from the RGBEasy API.