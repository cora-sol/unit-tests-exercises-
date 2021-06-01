namespace Authentication
{
    public class Authenticator
    {
        private readonly AuthenticationStatus authenticationStatus = new AuthenticationStatus();
        private readonly PanelNavigator panelNavigator = new PanelNavigator();
        private readonly SignUpHandler signUpHandler = new SignUpHandler();
        private readonly SignInHandler signInHandler = new SignInHandler();
        private readonly LogOffHandler logOffHandler = new LogOffHandler();
        private readonly SetOptionHandler setOptionHandler = new SetOptionHandler();
        private readonly IDataBase dataBase;

        public event ChangePanelDelegate OnChangePanel
        {
            add => panelNavigator.OnChangePanel += value;
            remove => panelNavigator.OnChangePanel -= value;
        }

        public bool IsLoggedIn => authenticationStatus.IsLoggedIn;

        public PanelType CurrentPanel => panelNavigator.CurrentPanel;

        public Authenticator(IDataBase dataBase)
        {
            this.dataBase = dataBase;
            dataBase.Initialize();
        }

        public void Dispose()
        {
            dataBase.Dispose();
        }

        public void SignUp(string firstName, string lastName, string email, string password)
        {
            bool success = signUpHandler.SignUp(dataBase, firstName, lastName, email, password);
            if (!success)
                return;
            authenticationStatus.IsLoggedIn = true;
            panelNavigator.SwitchToPanel(PanelType.Settings);
        }

        public void SignIn(string email, string password)
        {
            bool success = signInHandler.SignIn(dataBase, email, password);
            if (!success)
                return;
            authenticationStatus.IsLoggedIn = true;
            panelNavigator.SwitchToPanel(PanelType.Settings);
        }

        public void LogOff()
        {
            bool success = logOffHandler.LogOff();
            if (!success)
                return;
            authenticationStatus.IsLoggedIn = false;
            panelNavigator.SwitchToPanel(PanelType.SignUp);
        }

        public void SetOption(int index, bool isOn)
        {
            setOptionHandler.SetOption(index, isOn);
        }

        public void SwitchToLoginPanel()
        {
            panelNavigator.SwitchToPanel(PanelType.Login);
        }
    }
}
