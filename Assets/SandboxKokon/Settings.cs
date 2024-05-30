using UnityEngine;

public class Settings : MonoBehaviour
{
    
    [SerializeField] private GameObject _uiPanel;
    
    public void TurnOnOffUIPanel()
    {
        _uiPanel.SetActive(!_uiPanel.activeSelf);    
    }
}
