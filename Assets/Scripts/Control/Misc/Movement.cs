using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private float _rotateLeft = 180f;
    private float _rotateRight = 0f;

    private float _moveX;
    private float _moveY;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

   

    private void FixedUpdate()
    {
        Move();
    }

    public void SetCurrentDirection(float currentDirectionX, float currentDirectionY)
    {
        _moveX = currentDirectionX;
        _moveY = currentDirectionY;
       
        if(_moveX > 0)
        {
            transform.rotation = Quaternion.Euler(0,_rotateRight, 0);
        }
        else if(_moveX < 0)
        {
            transform.rotation = Quaternion.Euler(0, _rotateLeft, 0);
        }
    }

    private void Move()
    {       
        Vector2 movement = new Vector2(_moveX * _moveSpeed, _moveY * _moveSpeed);
        _rigidbody.velocity = movement;
    }
}
