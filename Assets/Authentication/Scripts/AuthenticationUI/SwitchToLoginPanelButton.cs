using Authentication;
using UnityEngine;
using UnityEngine.UI;

namespace AuthenticationUI
{
    public class SwitchToLoginPanelButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;
        [SerializeField]
        private AuthenticatorObject authenticatorObject;

        private void Start()
        {
            button.onClick.AddListener(SignUp);
        }

        private void SignUp()
        {
            authenticatorObject.SwitchToLoginPanel();
        }
    }
}