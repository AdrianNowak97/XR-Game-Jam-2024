using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Settings : MonoBehaviour
{
    public InputActionProperty MenuSwitch;
    [SerializeField] private GameObject _vignette;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private Material _handsMaterial;
    [SerializeField] private GameObject _playerCamera;
    private float previousTriggerValue = 0;

    public void Update()
    {
        var triggerValue = MenuSwitch.action.ReadValue<float>();
        
        if (triggerValue == 1 && previousTriggerValue == 0)
        {
            _uiPanel.SetActive(!_uiPanel.activeSelf);
            var position = _playerCamera.transform.position + (2 * _playerCamera.transform.forward);
            transform.position = new Vector3(position.x, _playerCamera.transform.position.y, position.z);
            //transform.rotation = Quaternion.Euler(_playerCamera.transform.rotation.x, _playerCamera.transform.rotation.y,0);
            transform.LookAt(_playerCamera.transform.position);
            transform.Rotate(0,180,0);
        }

        previousTriggerValue = triggerValue;
    }

    public void TurnOnOffUIPanel()
    {
        _uiPanel.SetActive(!_uiPanel.activeSelf);    
    }

    public void ChangeHandsColor(int color)
    {
        if (color == 1)
        {
            _handsMaterial.color = new Color(0.30f, 0.17f,0.20f, 1);
        }
        else if(color == 2)
        {
            _handsMaterial.color = new Color(0.48f, 0.28f,0.25f, 1);
        }
        else if(color == 3)
        {
            _handsMaterial.color = new Color(0.68f, 0.47f,0.34f, 1);
        }
        else if(color == 4)
        {
            _handsMaterial.color = new Color(0.75f, 0.58f,0.45f, 1);
        }
        else if(color == 5)
        {
            _handsMaterial.color = new Color(0.84f, 0.70f,0.58f, 1);
        }
    }
    
    
    
    
}
