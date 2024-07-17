using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private PlayerInput _playerInput;
    private FrameInput _frameInput;

    private Movement _movement;


    private void Awake()
    {
        if (Instance == null) { Instance = this; }

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
