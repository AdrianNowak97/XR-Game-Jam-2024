using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandsOnInput : MonoBehaviour
{
    public InputActionProperty triggerInputAction;
    public InputActionProperty gripInputAction;
    public Animator animator;

    private void Update()
    {
        var triggerValue = triggerInputAction.action.ReadValue<float>();
        animator.SetFloat("Trigger", triggerValue);

        var gripValue = gripInputAction.action.ReadValue<float>();
        animator.SetFloat("Grip", gripValue);
    }
}
