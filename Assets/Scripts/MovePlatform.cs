using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour, TimeController
{
    private Rigidbody thisRB;

    private Vector3 OrgPos;

    private float Speed;

    private void Awake()
    {
        OrgPos = gameObject.transform.position;

        Speed = 5;

        Singletons.TimeStoppable.Add(this);
    }
    public void Behaviour()
    {
        Movement();
    }

    public void LateBehaviour()
    {

    }

    private void Movement()
    {
        if(Vector3.Distance(OrgPos, gameObject.transform.position) > 4.5f)
        {
            Speed = -Speed;
        }

        gameObject.transform.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + Speed * Time.deltaTime);
    }
}