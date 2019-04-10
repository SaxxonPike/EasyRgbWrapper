# EasyRgbWrapper

This expands on the RGBEasy API that is provided by Datapath, for use with supported Datapath capture cards.

## EasyRgbWrapper.Gui

A GUI utility for saving, auto-recalling (based on input display parameters such as resolution and refresh), and displaying Datapath
capture parameters. It will scale up and apply aspect ratio - useful for DOS game resolutions such as 320x200.

## EasyRgbWrapper.Lib

The meat of the project. This is actually a wrapper *for* the wrapper provided by Datapath. It provides sturctured exception handling
and proper Dispose patterns in case something goes wrong.
