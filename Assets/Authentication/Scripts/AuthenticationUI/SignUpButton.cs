using Authentication;
using UnityEngine;
using UnityEngine.Serialization;
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
        [FormerlySerializedAs("authenticatorUI")]
        [SerializeField]
        private AuthenticatorObject authenticatorObject;

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
            authenticatorObject.SignUp(firstName, lastName, email, password);
        }
    }
}