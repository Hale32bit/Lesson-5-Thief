using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
[RequireComponent(typeof(Door),typeof(Collider2D))]
public class DoorSensor : MonoBehaviour, ISensor
{

    public event Action<GameObject> TriggeredUp;
    public event Action<GameObject> TriggeredDown;



    private Door _door;

    private void Start()
    {
        _door = GetComponent<Door>();

    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        
        Vector3 direction = collision.transform.position - this.transform.position;
        float projection = Vector3.Dot(direction, _door.InsideDirection);


        if (projection > 0)
            SobodyEnter(collision);
        else
            SomebodyExit(collision);

    }

    private void SomebodyExit(Collider2D collision)
    {
        TriggeredDown?.Invoke(collision.gameObject);
    }

    private void SobodyEnter(Collider2D collision)
    {
        TriggeredUp?.Invoke(collision.gameObject);
    }




}
