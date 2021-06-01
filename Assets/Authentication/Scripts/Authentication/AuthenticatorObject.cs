using UnityEngine;

namespace Authentication
{
    public class AuthenticatorObject : MonoBehaviour
    {
        private Authenticator authenticator;

        public event ChangePanelDelegate OnChangePanel
        {
            add => authenticator.OnChangePanel += value;
            remove => authenticator.OnChangePanel -= value;
        }

        private void Awake()
        {
            PlayerPrefsDataBase playerPrefsDataBase = new PlayerPrefsDataBase();
            authenticator = new Authenticator(playerPrefsDataBase);
        }

        private void OnDestroy()
        {
            authenticator.Dispose();
        }

        public void SignUp(string firstName, string lastName, string email, string password)
        {
            authenticator.SignUp(firstName, lastName, email, password);
        }

        public void SignIn(string email, string password)
        {
            authenticator.SignIn(email, password);
        }

        public void LogOff()
        {
            authenticator.LogOff();
        }

        public void SetOption(int index, bool isOn)
        {
            authenticator.SetOption(index, isOn);
        }

        public void SwitchToLoginPanel()
        {
            authenticator.SwitchToLoginPanel();
        }

        public PanelType GetCurrentPanel()
        {
            return authenticator.CurrentPanel;
        }
    }
}