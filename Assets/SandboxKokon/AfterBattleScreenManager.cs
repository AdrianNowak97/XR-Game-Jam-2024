using UnityEngine;

public class AfterBattleScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private GameObject _playerCamera;
    
    public void SpawnScreen()
    {
        _uiPanel.SetActive(!_uiPanel.activeSelf);
        var position = _playerCamera.transform.position + (2 * _playerCamera.transform.forward);
        transform.position = new Vector3(position.x, _playerCamera.transform.position.y, position.z);
        //transform.rotation = Quaternion.Euler(_playerCamera.transform.rotation.x, _playerCamera.transform.rotation.y,0);
        transform.LookAt(_playerCamera.transform.position);
        transform.Rotate(0,180,0);
    }
}
