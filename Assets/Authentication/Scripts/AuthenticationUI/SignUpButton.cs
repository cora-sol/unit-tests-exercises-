using UnityEngine;
using UnityEngine.UI;

namespace AuthenticationUI
{
    public class SignUpButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;
        [SerializeField]
        private InputField firstNameField;
        [SerializeField]
        private InputField lastNameField;
        [SerializeField]
        private InputField emailField;
        [SerializeField]
        private InputField passwordField;
        [SerializeField]
        private AuthenticatorUI authenticatorUI;

        private void Start()
        {
            button.onClick.AddListener(SignUp);
        }

        private void SignUp()
        {
            string firstName = firstNameField.text;
            string lastName = lastNameField.text;
            string email = emailField.text;
            string password = passwordField.text;
            authenticatorUI.SignUp(firstName, lastName, email, password);
        }
    }
}