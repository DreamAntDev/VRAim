using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUIPosition : MonoBehaviour
{
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = _mainCamera.transform.position + _mainCamera.transform.forward * 2f;
        Vector3 screenPos = _mainCamera.WorldToScreenPoint(targetPosition);

        // 스크린 좌표를 월드 좌표로 변환하여 UI 요소의 위치를 설정
        transform.position =
            _mainCamera.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y,
                Mathf.Abs(_mainCamera.transform.position.z)));
        
        transform.LookAt(targetPosition, _mainCamera.transform.up);
        
    }

}
