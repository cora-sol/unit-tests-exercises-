using Authentication;
using UnityEngine;

namespace AuthenticationUI
{
    public class AuthenticatorUI : MonoBehaviour
    {
        private readonly Authenticator authenticator = new Authenticator();

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
    }
}