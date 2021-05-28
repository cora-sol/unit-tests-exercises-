using UnityEngine;
using UnityEngine.UI;

namespace AuthenticationUI
{
    public class LogOffButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;
        [SerializeField]
        private AuthenticatorUI authenticatorUI;

        private void Start()
        {
            button.onClick.AddListener(SignUp);
        }

        private void SignUp()
        {
            authenticatorUI.LogOff();
        }
    }
}