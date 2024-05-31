using UnityEngine;
using UnityEngine.UI;

public class AfterBattleScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private GameObject _playerCamera;
    [SerializeField] private Stats_Count_At_End _statsCountAtEnd;
    [SerializeField] private Text endText;
    [SerializeField] private GameObject[] medals;
    
    public void SpawnScreen()
    {
        print("spawn End Screen");

        if (_statsCountAtEnd.howManyStarts == 0)
        {
            endText.text = "Defeat...";
            medals[0].SetActive(false);
            medals[1].SetActive(false);
            medals[2].SetActive(false);
        }
        else if (_statsCountAtEnd.howManyStarts == 1)
        {
            endText.text = "It's Ok!";
            medals[0].SetActive(true);
            medals[1].SetActive(false);
            medals[2].SetActive(false);
        }
        else if (_statsCountAtEnd.howManyStarts == 2)
        {
            endText.text = "You Did It!";
            medals[0].SetActive(true);
            medals[1].SetActive(true);
            medals[2].SetActive(false);
        }
        else if (_statsCountAtEnd.howManyStarts == 3)
        {
            endText.text = "Flawless Victory!";
            medals[0].SetActive(true);
            medals[1].SetActive(true);
            medals[2].SetActive(true);
        }
        
        _uiPanel.SetActive(!_uiPanel.activeSelf);
        var position = _playerCamera.transform.position + (2 * _playerCamera.transform.forward);
        transform.position = new Vector3(position.x, _playerCamera.transform.position.y, position.z);
        //transform.rotation = Quaternion.Euler(_playerCamera.transform.rotation.x, _playerCamera.transform.rotation.y,0);
        transform.LookAt(_playerCamera.transform.position);
        transform.Rotate(0,180,0);
    }
}
