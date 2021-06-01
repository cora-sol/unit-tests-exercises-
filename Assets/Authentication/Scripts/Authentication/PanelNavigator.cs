using UnityEngine;

namespace Authentication
{
    public class PanelNavigator
    {
        private PanelType currentPanel = PanelType.SignUp;

        public event ChangePanelDelegate OnChangePanel;

        public PanelType CurrentPanel => currentPanel;

        public void SwitchToPanel(PanelType panel)
        {
            Debug.LogWarning(panel);
            currentPanel = panel;
            OnChangePanel?.Invoke();
        }
    }
}