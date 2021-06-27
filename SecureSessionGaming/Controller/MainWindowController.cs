using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SecureSessionGaming.Exceptions;
using SecureSessionGaming.Security;
using SecureSessionGaming.Service;
using SecureSessionGaming.Support.Games;
using SecureSessionGaming.Support.Log;
using SecureSessionGaming.Support.UserInterface;

namespace SecureSessionGaming.Controller
{
    public class MainWindowController
    {
        // UI elements
        public TextBlock uiLabelAdmin = null;
        public RadioButton uiRadioGame = null;
        public ComboBox uiComboBoxGameSelector = null;
        public Label uiLabelSession = null;
        public Button uiButtonStatus = null;
        public TextBox uiTextBoxLog = null;

        //
        private ConfigService configService;

        // 
        private bool active = false;

        public MainWindowController()
        {
            configService = new ConfigService();
            configService.SetLogLevel();
            LogSupport.Debug("Loaded Config");
        }

        public void Close()
        {
            //
            // Disable rules at close
            new PolicyService().RemoveAllPolicies();

            //
            LogSupport.Debug("Closing Application");
        }

        #pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Init()
        #pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
                if (!AccessSecurity.IsUserAdministrator())
                {
                    uiButtonStatus.IsEnabled = false;

                    uiLabelAdmin.Visibility = Visibility.Visible;
                    SetControl(false);
                }

                //
                // Add the games
                uiComboBoxGameSelector.Items.Clear();
                foreach (string game in GameAbstract.GetAll())
                {
                    uiComboBoxGameSelector.Items.Add(game);
                }
                uiComboBoxGameSelector.SelectedItem = 0;
                uiComboBoxGameSelector.SelectedIndex = 0;
            }
            catch (AppException e)
            {
                LogSupport.Error(e.Message);
                uiTextBoxLog.Text = e.Message;
            }
        }

        //
        // Status

        public void UpdateStatus()
        {
            try
            {
                active = !active;
                
                new PolicyService(active)
                    .ForGame(uiComboBoxGameSelector.SelectionBoxItem.ToString())
                    .UpdatePolicy();
                SetControl(active);
            }
            catch (AppException e)
            {
                LogSupport.Error(e.Message);
                uiTextBoxLog.Text = e.Message;
            }
        }

        //
        // Private

        private void SetControl(bool status)
        {
            // Update UI
            InterfaceSupport ui = new InterfaceSupport(status);

            uiLabelSession.Background = ui.GetBackground();
            uiLabelSession.Content = ui.GetStatusText();
            uiButtonStatus.Content = ui.GetButtonText();

            uiComboBoxGameSelector.IsEnabled = ui.GetActiveStatus();
        }
    }
}
