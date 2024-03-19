using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class TestDirection : MonoBehaviour
{
    
    
    private InputAction _XR_Head_Position_InputAction;
    private InputAction _XR_Head_EyeGazePosition_InputAction;
    private InputAction _XR_LeftHand_SelectButton_InputAction;
    private InputAction _XR_RightHand_SelectButton_InputAction;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 5f, Color.green);
        Debug.DrawRay(transform.position, -transform.forward * 5f, Color.green);
    }
    /*private void FindActionByName()
    {
        foreach (var actionMap in _inputActionAsset.actionMaps)
        {
            foreach (var action in actionMap.actions)
            {
                Debug.Log($"Found action: {actionMap.name}/{action.name}");
            }
        }

        //Debug.LogError($"Action '{actionName}' not found in InputActionAsset!");
    }*/
    
    
}
