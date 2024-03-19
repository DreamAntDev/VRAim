using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TestDirection : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 5f, Color.green);
        Debug.DrawRay(transform.position, -transform.forward * 5f, Color.green);
    }
}
