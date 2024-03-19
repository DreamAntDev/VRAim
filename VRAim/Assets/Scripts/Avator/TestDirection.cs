using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class TestDirection : MonoBehaviour
{
    [Header("UI Component")]
    [SerializeField] private GameObject panel;
    
    [Space(15)]
    [Header("XR Component")]
    [SerializeField] private InputActionManager inputActionManager;
    [Space(15)]
    private InputActionAsset _inputActionAsset;
    
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
        //XRI Head/Position
        /*_XR_Head_Position_InputAction = _inputActionAsset.FindAction("XRI Head/Position");
        Debug.Assert(_XR_Head_Position_InputAction != null);
        _XR_Head_Position_InputAction.started += ctx => OnActionStarted(ctx.ReadValue<Vector3>());
        //XRI Head/Eye Gaze Position
        _XR_Head_EyeGazePosition_InputAction = _inputActionAsset.FindAction("XRI Head/Eye Gaze Position");
        Debug.Assert(_XR_Head_EyeGazePosition_InputAction != null);
        _XR_Head_EyeGazePosition_InputAction.started += ctx => OnActionStarted(ctx.ReadValue<Vector3>());*/
        
        /*_XR_Head_Position_InputAction = _inputActionAsset.FindAction("XRI Head/Tracking State");
        _XR_Head_Position_InputAction.started += (ctx =>
        {
            int isTracking = ctx.ReadValue<int>();
            
            Debug.Log("Tracking : " + isTracking);
        });*/
        
        //XRI LeftHand Interaction/Select"
        //XRI RightHand Interaction/Select
        /*_XR_LeftHand_SelectButton_InputAction = _inputActionAsset.FindAction("XRI LeftHand Interaction/Select Value");
        _XR_RightHand_SelectButton_InputAction = _inputActionAsset.FindAction("XRI RightHand Interaction/Select Value");
        Debug.Assert(_XR_LeftHand_SelectButton_InputAction != null);
        Debug.Assert(_XR_RightHand_SelectButton_InputAction != null);
        _XR_LeftHand_SelectButton_InputAction.started += ctx => OnTriggerButtonPress(ctx.ReadValue<float>());
        _XR_RightHand_SelectButton_InputAction.started += ctx => OnTriggerButtonPress(ctx.ReadValue<float>());*/
        
        //Test
        var hand_InputAction = _inputActionAsset.FindAction("XRI State/Hand Trigger Click");
        Debug.Assert(hand_InputAction != null);
        hand_InputAction.started += (ctx =>
        {
            Debug.Log("Trigger On");
        });
        hand_InputAction.canceled += (ctx =>
        {
            Debug.Log("Trigger Off");
        });
        
        hand_InputAction.Enable();
        
/*        _XR_Head_Position_InputAction.Enable();
        _XR_Head_EyeGazePosition_InputAction.Enable();
        _XR_LeftHand_SelectButton_InputAction.Enable();
        _XR_RightHand_SelectButton_InputAction.Enable();*/
        
        
        //FindActionByName();
    }
}
