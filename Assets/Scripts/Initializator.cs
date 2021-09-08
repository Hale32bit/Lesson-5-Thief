using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Initializator : MonoBehaviour
{
    [SerializeField] private DoorSensor _door;
    [SerializeField] private Signaling _signaling;


    private void Start()
    {
        _signaling.Initialize(_door);
    }

    
}
