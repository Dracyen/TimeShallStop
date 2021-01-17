using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject Orientation;

    private void Awake()
    {
        Singletons.Player = this;

        Orientation = GetComponentInChildren<CameraController>().gameObject;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Singletons.GameManager.SwitchTime();

            Debug.Log("J");
        }
    }

    private void Movement()
    {
        
    }
}