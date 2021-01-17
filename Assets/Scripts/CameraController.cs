using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject Camera;

    private float lookSpeed;

    private float fnlPos;

    private float cntPos;

    private float Speed;

    private GameObject Target;

    private void Awake()
    {
        Singletons.MainCamera = this;

        Camera = GetComponentInChildren<Camera>().gameObject;

        lookSpeed = 100;

        fnlPos = Camera.transform.position.z;

        cntPos = Camera.transform.position.z;

        Speed = 3;
    }

    void Update()
    {
        //transform.LookAt(Singletons.Player.transform);

        LookAround();

        SmoothScroll();

        LookAt();

        Debug.Log(fnlPos);
    }

    void LookAround()
    {
        transform.eulerAngles += new Vector3(-(Input.GetAxisRaw("Mouse Y") * lookSpeed * Time.deltaTime), Input.GetAxisRaw("Mouse X") * lookSpeed * Time.deltaTime, 0.0f);
    }

    void SmoothScroll()
    {
        if (fnlPos < -10)
        {
            fnlPos = -10;
        }
        else if (fnlPos > -5)
        {
            fnlPos = -5;
        }

        if (fnlPos > cntPos)
        {
            cntPos += Speed * Time.deltaTime;
        }

        if (fnlPos < cntPos)
        {
            cntPos -= Speed * Time.deltaTime;
        }

        Camera.transform.localPosition = new Vector3(Camera.transform.localPosition.x, Camera.transform.localPosition.y, cntPos);

        fnlPos += Input.mouseScrollDelta.y;
    }

    void LookAt()
    {
        RaycastHit Target;

        Physics.Raycast(Camera.transform.position, Camera.transform.position, out Target);
        Debug.DrawRay(Camera.transform.position, Vector3.forward * 100, Color.red);

        if(Target.transform.gameObject.GetComponent(typeof(TimeController))) 
        {
            this.Target = Target.collider.gameObject;
        }

        Debug.Log(this.Target.name);
    }
}
