#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Windows.Controls;
using Syncfusion.Windows.Tools.Controls;
namespace DockingStudio
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
	{
		#region Constructor
        /// <summary>
        /// Constructor for window1.
        /// </summary>
		public MainWindow()
        {
			InitializeComponent();
            DockingManager.ActiveWindow = MainWindowCSView;			
			SubscribeForEvents();                 
            MainWindowCSView.Content = new MainWindowCSView();
            DockingManager.SetHeader(MainWindowCSView, "MainWindow.xaml.cs");
            MainWindowXAMLView.Content = new MainWindowXAMLView();
            DockingManager.SetHeader(MainWindowXAMLView, "MainWindow.xaml");
        }        
        #endregion

        #region Implementation
        
        /// <summary>
        /// Ckear the events
        /// </summary>
        private void OnClear(object sender, EventArgs args)
        {
            Log.Text = "";
        }
       
        /// <summary>
        /// Events
        /// </summary>
		private void SubscribeForEvents()
		{
            // Subscribe the Loaded event of DockingManager
            DockingManager.Loaded += DockingManager_Loaded;
            //Subscribe the AutoHideAnimationStart property changed event
            DockingManager.AutoHideAnimationStart += new RoutedEventHandler( OnEventRaising );
            //Subscribe the AutoHideAnimationStop property changed event
			DockingManager.AutoHideAnimationStop += new RoutedEventHandler( OnEventRaising );
            //Subscribe the WindowActivated property changed event
			DockingManager.WindowActivated += new RoutedEventHandler( OnEventRaising );
            //Subscribe the WindowDeactivated property changed event
			DockingManager.WindowDeactivated += new RoutedEventHandler( OnEventRaising );
            //Subscribe the WindowDragStart property changed event
			DockingManager.WindowDragStart += new RoutedEventHandler( OnEventRaising );
            //Subscribe the WindowDragEnd property changed event
			DockingManager.WindowDragEnd += new RoutedEventHandler( OnEventRaising );
            // Subscribe the CloseAllTabs event of DockingManager
            DockingManager.CloseAllTabs += DockingManager_CloseAllTabs;
            // Subscribe the CloseOtherTabs event of DockingManager
            DockingManager.CloseOtherTabs += DockingManager_CloseOtherTabs;
            //Subscribe the ActiveWindow property changed event
            DockingManager.ActiveWindowChanged += new PropertyChangedCallback( OnPropertyChanged );
        }

        #endregion

        #region Events
        /// <summary>
        /// Routed event raising
        /// </summary>
        private void OnEventRaising( object sender, RoutedEventArgs e )
		{
			FrameworkElement element = e.OriginalSource as FrameworkElement;
			string name = element != null ? element.Name : string.Empty;
            Log.TextWrapping = TextWrapping.Wrap;
            Log.Text =Log.Text + e.RoutedEvent.Name + " : " + name + "\n";
            Scroll.ScrollToBottom();
			
		}

        /// <summary>
        /// To load the last saved layout of DockingManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DockingManager_Loaded(object sender, RoutedEventArgs e)
        {
            DockingManager.LoadDockState();
        }

        /// <summary>
        /// Property changed event raising
        /// </summary>
		private void OnPropertyChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			string name = e.NewValue != null ? ( e.NewValue as FrameworkElement ).Name : string.Empty;
            Log.TextWrapping = TextWrapping.Wrap;
			Log.Text= Log.Text + e.Property.Name + " : " + name + "\n" ;
            Scroll.ScrollToBottom();
		}        
    	#endregion

        /// <summary>
        /// Handles the CloseAllTabs event of the DockingManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Tools.Controls.CloseTabEventArgs"/> instance containing the event data.</param>
        private void DockingManager_CloseAllTabs(object sender, CloseTabEventArgs e)
        {
            string closingtabs = "";
            MessageBoxResult result = MessageBox.Show("Do you want to close the tabs? ", "Closing Tabs", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                for (int i = 0; i < e.ClosingTabItems.Count; i++)
                {
                    TabItemExt tabitem = e.ClosingTabItems[i] as TabItemExt;
                    if (tabitem.Content != null && (tabitem.Content as ContentPresenter) != null)
                    {
                        ContentPresenter presenter = tabitem.Content as ContentPresenter;
                        if (presenter != null && presenter.Content != null)
                        {
                            closingtabs = closingtabs + "\n\t" + DockingManager.GetHeader(presenter.Content as DependencyObject) ;
                        }
                    }
                }
                Log.TextWrapping = TextWrapping.Wrap;
                Log.Text = Log.Text + "Closed Tabs" + " : " + closingtabs + "\n";
                Scroll.ScrollToBottom();
            }
            else if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Handles the CloseOtherTabs event of the DockingManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Tools.Controls.CloseTabEventArgs"/> instance containing the event data.</param>
        private void DockingManager_CloseOtherTabs(object sender, CloseTabEventArgs e)
        {
            string closingtabs = "";
            MessageBoxResult result = MessageBox.Show("Do you want to close the tabs? ", "Closing Tabs", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                for (int i = 0; i < e.ClosingTabItems.Count; i++)
                {
                    TabItemExt tabitem = e.ClosingTabItems[i] as TabItemExt;
                    if (tabitem.Content != null && (tabitem.Content as ContentPresenter) != null)
                    {
                        ContentPresenter presenter = tabitem.Content as ContentPresenter;
                        if (presenter != null && presenter.Content != null)
                        {
                            closingtabs = closingtabs + "\n\t" + DockingManager.GetHeader(presenter.Content as DependencyObject) ;
                        }
                    }
                }
                Log.TextWrapping = TextWrapping.Wrap;
                Log.Text = Log.Text + "Closed Tabs" + " : " + closingtabs + "\n";
                Scroll.ScrollToBottom();
            }
            else if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

    }   
}

