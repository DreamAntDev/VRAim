using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLifeController : MonoBehaviour
{
    private TestInteraction _interaction;
    private Coroutine _timerEnumerator;
    private float _time;

    private void Awake()
    {
        _interaction = GetComponent<TestInteraction>();
        _time = GameManager.Instance.TargetActiveTime;
    }

    private void OnEnable()
    {
        _timerEnumerator = StartCoroutine(ActiveTimer());
    }

    private void OnDisable()
    {
        StopCoroutine(_timerEnumerator);
    }

    IEnumerator ActiveTimer()
    {
        yield return new WaitForSeconds(_time);
        Debug.Log("Failed Broken Target");
        GameManager.Instance.RespawnTarget(_interaction);
    }
}
