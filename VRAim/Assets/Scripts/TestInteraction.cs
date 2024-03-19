using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

[SelectionBase]
[DisallowMultipleComponent]
[AddComponentMenu("XR/XR Test Interactable", 11)]
public class TestInteraction : MonoBehaviour
{
    [SerializeField] private InputActionManager inputActionManager;
    private InputActionAsset _inputActionAsset;
    
    private InputAction _XR_Head_Position_InputAction;
    private InputAction _XR_Head_EyeGazePosition_InputAction;
    private InputAction _XR_LeftHand_SelectButton_InputAction;
    private InputAction _XR_RightHand_SelectButton_InputAction;
    
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
        _XR_Head_Position_InputAction = _inputActionAsset.FindAction("XRI Head/Position");
        Debug.Assert(_XR_Head_Position_InputAction != null);
        _XR_Head_Position_InputAction.started += ctx => OnActionStarted(ctx.ReadValue<Vector3>());
        //XRI Head/Eye Gaze Position
        _XR_Head_EyeGazePosition_InputAction = _inputActionAsset.FindAction("XRI Head/Eye Gaze Position");
        Debug.Assert(_XR_Head_EyeGazePosition_InputAction != null);
        _XR_Head_EyeGazePosition_InputAction.started += ctx => OnActionStarted(ctx.ReadValue<Vector3>());
        
        /*_XR_Head_Position_InputAction = _inputActionAsset.FindAction("XRI Head/Tracking State");
        _XR_Head_Position_InputAction.started += (ctx =>
        {
            int isTracking = ctx.ReadValue<int>();
            
            Debug.Log("Tracking : " + isTracking);
        });*/
        
        //XRI LeftHand Interaction/Select"
        //XRI RightHand Interaction/Select
        _XR_LeftHand_SelectButton_InputAction = _inputActionAsset.FindAction("XRI LeftHand Interaction/Select Value");
        _XR_RightHand_SelectButton_InputAction = _inputActionAsset.FindAction("XRI RightHand Interaction/Select Value");
        Debug.Assert(_XR_LeftHand_SelectButton_InputAction != null);
        Debug.Assert(_XR_RightHand_SelectButton_InputAction != null);
        _XR_LeftHand_SelectButton_InputAction.started += ctx => OnTriggerButtonPress(ctx.ReadValue<float>());
        _XR_RightHand_SelectButton_InputAction.started += ctx => OnTriggerButtonPress(ctx.ReadValue<float>());
        
        //Test
        var hand_InputAction = _inputActionAsset.FindAction("XRI State/Hand Trigger Click");
        Debug.Assert(_XR_Head_EyeGazePosition_InputAction != null);
        hand_InputAction.started += (ctx =>
        {
            Debug.Log("Trigger On");
        });
        hand_InputAction.canceled += (ctx =>
        {
            Debug.Log("Trigger Off");
        });
        
        hand_InputAction.Enable();
        
        _XR_Head_Position_InputAction.Enable();
        _XR_Head_EyeGazePosition_InputAction.Enable();
        _XR_LeftHand_SelectButton_InputAction.Enable();
        _XR_RightHand_SelectButton_InputAction.Enable();
        
        
        //FindActionByName();
    }

    private void OnDisable()
    {
    }
    private void OnActionStarted(Vector3 value)
    {
        Debug.Log($"XRI Head Vector3 value: {value}");
        // Add your logic here based on the received Vector3 value
    }
    private void OnTriggerButtonPress(float value)
    {
        if (value > 0.5f) // You can adjust the threshold value based on your preference
        {
            Debug.Log("Trigger button clicked!");
            // Add your desired functionality here
        }
    }
    
    private void OnTriggerButtonReleased(float value)
    {
        if (value > 0.5f) // You can adjust the threshold value based on your preference
        {
            Debug.Log("Trigger button clicked!");
            // Add your desired functionality here
        }
    }
}
