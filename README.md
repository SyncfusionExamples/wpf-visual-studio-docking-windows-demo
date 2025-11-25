# Visual Studio-like Docking Windows Demo for WPF
This sample demonstrates how to build Visual Studio-style window layouts in a WPF application using the Syncfusion Docking Manager. It showcases docked tool windows, tabbed document interfaces, floating windows, auto-hidden panels, and layout persistence so users can organize their workspace like in Visual Studio. You can drag tool windows, snap them to any side, group documents into tab groups, float panes to separate monitors, and restore your preferred layout between sessions.

## Features
- Dock, float, document, and auto-hidden window states
- Drag-and-drop docking with dock hints and live preview
- Tabbed document interface with horizontal and vertical tab groups
- Built-in themes (e.g., VS2010) and style customization
- Size preferences in docked mode (DesiredWidthInDockedMode, DesiredHeightInDockedMode)
- Optional native float windows for unrestricted sizing
- Disable floating for specific panes when required
- Close, restore, and pin/unpin windows to edges
- Layout persistence: save and load docking state between sessions

## Getting Started
1. Create a new WPF project in Visual Studio (e.g., VisualStudioLikeDockWindow).
2. Install the NuGet package: Syncfusion.Tools.WPF.
3. Add the Syncfusion XML namespace in XAML:
   - xmlns:syncfusion="http://schemas.syncfusion.com/wpf"
4. Place a DockingManager in your Window/Page to host dockable panes.
5. Add children (e.g., ContentControl) and set:
   - syncfusion:DockingManager.Header for pane titles
   - syncfusion:DockingManager.State (Dock, Document, etc.)
   - syncfusion:DockingManager.SideInDockedMode and TargetNameInDockedMode for layout
   - DesiredWidthInDockedMode and DesiredHeightInDockedMode for sizing
6. Apply a theme with syncfusion:SkinStorage.VisualStyle (e.g., VS2010).

## Usage Tips
- Group documents programmatically with CreateHorizontalTabGroup and CreateVerticalTabGroup.
- Enable familiar drag behavior with IsVS2010DraggingEnabled.
- Allow double-click to float documents with EnableDocumentToFloatOnDoubleClick.
- Use UseNativeFloatWindow for desktop-like floating windows.
- Persist layouts using PersistState, SaveDockState, and LoadDockState so users can return to their preferred setup.

## About the Sample
This sample provides a concise starting point for creating a Visual Studio-like WPF workspace, demonstrating common panes (Solution Explorer, Output, Properties, Toolbox) and tabbed document views. Extend it by adding your own user controls, commands, and themes to match your application’s workflow and branding. The goal is to deliver a familiar environment where users can organize, pin, unpin, float, and restore windows effortlessly—just like in Visual Studio.


![](https://blog.syncfusion.com/wp-content/uploads/2018/09/VSlikeDockWindow-1.png)