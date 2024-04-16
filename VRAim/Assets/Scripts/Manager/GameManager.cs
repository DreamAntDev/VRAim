using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Robotry.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class GameManager : Singleton<GameManager>
{
    [Header("Option")] 
    [SerializeField] private double playTime = 300f;
    [SerializeField] private int respawnCount = 16;
    [Space(10)] 
    
    [Header("UI Component")] 
    [SerializeField] private TextMeshProUGUI tmp_State;
    [SerializeField] private TextMeshProUGUI tmp_Count;
    [SerializeField] private TextMeshProUGUI tmp_StartAndTimer;
    [SerializeField] private Button btn_Start;
    [Space(10)] 
    
    [Header("Item Component")] 
    [SerializeField] private Transform targetParentTransform;
    [SerializeField] private GameObject targetObject;
    [Space(10)] 
    
    [Header("XR Component")]
    [SerializeField] private InputActionManager inputActionManager;
    [Space(10)]
    private InputActionAsset _inputActionAsset;
    
    private List<TestInteraction> _targetList;
    public bool IsGameStart { get; private set; }

    private GameObject _currentHoverObject;
    private int _breakCount;
    private ITargetInfo _targetInfo;

    private void Awake()
    {
        _targetList = new List<TestInteraction>();
        _targetInfo = new TargetInfo();
    }

    private void Start()
    {
        btn_Start.onClick.AddListener(GameStart);
        
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
            tmp_State.text = "Trigger On";
            Debug.Log("Trigger On");
            if (IsGameStart)
            {
                if (_currentHoverObject != null)
                {
                    _currentHoverObject.gameObject.SetActive(false);
                    tmp_Count.text = $"Count - {++_breakCount}";
                    CreateTarget();
                }
            }
        });
        hand_InputAction.canceled += (ctx =>
        {
            tmp_State.text = "Trigger Off";
            Debug.Log("Trigger Off");
        });
        
        hand_InputAction.Enable();
        
/*        _XR_Head_Position_InputAction.Enable();
        _XR_Head_EyeGazePosition_InputAction.Enable();
        _XR_LeftHand_SelectButton_InputAction.Enable();
        _XR_RightHand_SelectButton_InputAction.Enable();*/
        
        
        //FindActionByName();
    }
    
    public void GameStart()
    {
        if (IsGameStart)
            return;
        
        IsGameStart = true;
        tmp_State.text = String.Empty;
        tmp_State.text = "GameStart";
        StartCoroutine(Timer());
        CreateTarget();
    }

    public void GameEnd()
    {
        IsGameStart = false;
        tmp_State.text = $"GameEnd Count : " + _breakCount;
        tmp_StartAndTimer.text = "Start";
    }

    private void CreateTarget()
    {
        tmp_State.text = "Target Shoot!!";
        GameObject targetObj = Instantiate(targetObject, Camera.main.transform.position - (Quaternion.Euler(0f, _targetInfo.GetTargetAngle(respawnCount), 0f) * Camera.main.transform.forward * 3f), Quaternion.identity, targetParentTransform);
        TestInteraction ti = targetObj.GetComponent<TestInteraction>();
        ti.itemHoverEnteredAction += OnHoverEnteredListener;
        ti.itemHoverExitedAction += OnHoverExitedListener;
        _targetList.Add(ti);
    }
    private void OnHoverEnteredListener(GameObject obj)
    {
        _currentHoverObject = obj;
        tmp_State.text = "Hover Target - " + obj.name;
    }
    
    private void OnHoverExitedListener(GameObject obj)
    {
        if (_currentHoverObject == obj)
            _currentHoverObject = null;
    }

    IEnumerator Timer()
    {
        var currentTime = playTime;
        TimeSpan timeSpan;
        while (currentTime > 0)
        {
            currentTime -=  1;
            timeSpan = TimeSpan.FromSeconds(currentTime);
            tmp_StartAndTimer.text = timeSpan.ToString(@"mm\:ss");
            yield return new WaitForSeconds(1);

            if (Mathf.Approximately((float)currentTime, 0))
            {
                Debug.Log("Timer End");
                GameEnd();
                break;
            }
        }
    }
}
