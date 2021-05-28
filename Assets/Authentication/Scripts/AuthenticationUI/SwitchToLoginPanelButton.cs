using UnityEngine;
using UnityEngine.UI;

namespace AuthenticationUI
{
    public class SwitchToLoginPanelButton : MonoBehaviour
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
            authenticatorUI.SwitchToLoginPanel();
        }
    }
}