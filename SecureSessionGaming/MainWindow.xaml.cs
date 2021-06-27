using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;
using SecureSessionGaming.Config;
using SecureSessionGaming.Controller;

namespace SecureSessionGaming
{
    public partial class MainWindow : Window
    {
        //
        // App

        private MainWindowController mainWindowController = new MainWindowController();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        public void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            mainWindowController.Close();
        }

        //
        // Private

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = ApplicationConfig.NAME + ApplicationConfig.GetVersion();

            //
            mainWindowController.uiLabelAdmin = uiLabelAdmin;
            mainWindowController.uiLabelSession = uiLabelSession;
            mainWindowController.uiButtonStatus = uiButtonStatus;
            mainWindowController.uiTextBoxLog = uiTextBoxLog;
            mainWindowController.uiComboBoxGameSelector = uiComboBoxGameSelector;

            //
            await mainWindowController.Init();
        }

        //
        // Actions

        private void uiButtonStatus_Click(object sender, RoutedEventArgs e)
        {
            mainWindowController.UpdateStatus();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
