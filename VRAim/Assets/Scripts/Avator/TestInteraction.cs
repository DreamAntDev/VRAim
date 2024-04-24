using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

[SelectionBase]
[DisallowMultipleComponent]
[AddComponentMenu("XR/XR Test Interactable", 11)]
public class TestInteraction : XRBaseInteractable
{
    //Action
    public Action<IXRHoverInteractor> itemHoverEnteredAction; 
    public Action<IXRHoverInteractor> itemHoverExitedAction;
    
    protected override void OnEnable()
    {
        base.OnEnable();
        hoverEntered.AddListener(OnHoverEnteredListener);
        hoverExited.AddListener(OnHoverExitedListener);
    }

    private void OnHoverEnteredListener(HoverEnterEventArgs args)
    {
        if(itemHoverEnteredAction != null)
            itemHoverEnteredAction.Invoke(args.interactorObject);
    }
    
    private void OnHoverExitedListener(HoverExitEventArgs args)
    {
        if(itemHoverExitedAction != null)
            itemHoverExitedAction.Invoke(args.interactorObject);
    }
}
