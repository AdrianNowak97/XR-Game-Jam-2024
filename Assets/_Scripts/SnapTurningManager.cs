using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;

public class SnapTurningManager : MonoBehaviour
{
    [SerializeField] private SnapTurnProvider _snapTurningManager;
    [SerializeField] private ContinuousTurnProvider _continuousTurnProvider;

    public void ChangeState(bool snapTurning)
    {
        if (snapTurning)
        {
            _snapTurningManager.enabled = true;
            _continuousTurnProvider.enabled = false;
        }
        else
        {
            _snapTurningManager.enabled = false;
            _continuousTurnProvider.enabled = true;
        }
    }
}
