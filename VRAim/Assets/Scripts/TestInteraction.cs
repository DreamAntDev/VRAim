using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

[SelectionBase]
[DisallowMultipleComponent]
[AddComponentMenu("XR/XR Test Interactable", 11)]
public class TestInteraction : MonoBehaviour
{
    [SerializeField] private InputActionManager inputActionManager;
    private InputActionAsset _inputActionAsset;
    

    private void FindActionByName()
    {
        foreach (var actionMap in _inputActionAsset.actionMaps)
        {
            foreach (var action in actionMap.actions)
            {
                Debug.Log($"Found action: {actionMap.name}/{action.name}");
            }
        }

        //Debug.LogError($"Action '{actionName}' not found in InputActionAsset!");
    }
    
    private void OnEnable()
    {
        foreach (var actionAsset in inputActionManager.actionAssets)
        {
            Debug.Log("ActionAsset : " + actionAsset.name);
            if (actionAsset != null)
                _inputActionAsset = actionAsset;
        }
        
        FindActionByName();
    }

    private void OnDisable()
    {
    }

    private void OnTriggerButtonPress(XRController controller, float value)
    {
        if (value > 0.5f) // You can adjust the threshold value based on your preference
        {
            Debug.Log("Trigger button clicked!");
            // Add your desired functionality here
        }
    }
}
