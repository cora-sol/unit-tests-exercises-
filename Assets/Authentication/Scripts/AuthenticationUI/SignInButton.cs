using UnityEngine;
using UnityEngine.UI;

namespace AuthenticationUI
{
    public class SignInButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;
        [SerializeField]
        private InputField emailField;
        [SerializeField]
        private InputField passwordField;
        [SerializeField]
        private AuthenticatorUI authenticatorUI;

        private void Start()
        {
            button.onClick.AddListener(SignIn);
        }

        private void SignIn()
        {
            string email = emailField.text;
            string password = passwordField.text;
            authenticatorUI.SignIn(email, password);
        }
    }
}