using Authentication;
using UnityEngine;
using UnityEngine.UI;

namespace AuthenticationUI
{
    public class OptionToggle : MonoBehaviour
    {
        [SerializeField]
        private int index;
        [SerializeField]
        private Toggle toggle;
        [SerializeField]
        private AuthenticatorObject authenticatorObject;

        private void Start()
        {
            toggle.onValueChanged.AddListener(SetOption);
        }

        private void SetOption(bool isOn)
        {
            authenticatorObject.SetOption(index, isOn);
        }
    }
}