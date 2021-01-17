using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool TimeRun { get; private set; }

    private void Awake()
    {
        Singletons.GameManager = this;

        TimeRun = true;
    }

    private void Update()
    {
        TSUpdate();
    }

    private void LateUpdate()
    {
        TSLateUpdate();
    }

    private void TSUpdate()
    {
        if(TimeRun)
        {
            foreach(TimeController Piece in Singletons.TimeStoppable)
            {
                Piece.Behaviour();
            }
        }
    }

    private void TSLateUpdate()
    {
        if (TimeRun)
        {
            foreach (TimeController Piece in Singletons.TimeStoppable)
            {
                Piece.LateBehaviour();
            }
        }
    }

    public void SwitchTime()
    {
        Debug.Log("Switch!!");

        TimeRun = !TimeRun;
    }
}
