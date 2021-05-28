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

        public bool IsLoggedIn => authenticationStatus.IsLoggedIn;

        public void SignUp(string firstName, string lastName, string email, string password)
        {
            bool success = signUpHandler.SignUp(firstName, lastName, email, password);
            if (success)
                panelNavigator.SwitchToPanel(PanelType.Settings);
        }

        public void SignIn(string email, string password)
        {
            bool success = signInHandler.SignIn(email, password);
            if (success)
                panelNavigator.SwitchToPanel(PanelType.Settings);
        }

        public void LogOff()
        {
            bool success = logOffHandler.LogOff();
            if (success)
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
