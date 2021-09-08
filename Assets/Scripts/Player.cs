using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            direction += Vector2.up;

        if (Input.GetKey(KeyCode.S))
            direction += Vector2.down;

        if (Input.GetKey(KeyCode.A))
            direction += Vector2.left;

        if (Input.GetKey(KeyCode.D))
            direction += Vector2.right;

        direction = direction.normalized;

        _rigidbody.velocity = direction * _speed;


    }
}
