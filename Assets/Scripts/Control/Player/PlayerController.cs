using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private PlayerInput _playerInput;
    private FrameInput _frameInput;



    private Rigidbody2D _rigidbody;
    private Movement _movement;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        GatherInput();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void GatherInput()
    {
        _frameInput = _playerInput.FrameInput;
        
    }

    private void Movement()
    {
        _movement.SetCurrentDirection(_frameInput.Move.x, _frameInput.Move.y);
    }
}
