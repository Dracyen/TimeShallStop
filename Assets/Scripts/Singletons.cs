using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletons : MonoBehaviour
{
    public static List<TimeController> TimeStoppable = new List<TimeController>();

    public static PlayerController Player;

    public static GameManager GameManager;

    public static CameraController MainCamera;
}