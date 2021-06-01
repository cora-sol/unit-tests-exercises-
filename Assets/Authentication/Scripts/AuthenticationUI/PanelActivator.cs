using Authentication;
using UnityEngine;

namespace AuthenticationUI
{
    public class PanelActivator : MonoBehaviour
    {
        [SerializeField]
        private GameObject panel;
        [SerializeField]
        private PanelType panelType;
        [SerializeField]
        private AuthenticatorObject authenticatorObject;

        private void Start()
        {
            Refresh();
            authenticatorObject.OnChangePanel += Refresh;
        }

        private void Refresh()
        {
            PanelType currentPanel = authenticatorObject.GetCurrentPanel();
            bool shouldBeActive = currentPanel == panelType;
            if (panel.activeSelf == shouldBeActive)
                return;
            panel.SetActive(shouldBeActive);
        }
    }
}