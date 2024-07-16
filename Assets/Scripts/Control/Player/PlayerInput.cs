using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public FrameInput FrameInput {  get; private set; }

    private PlayerInputAction _playerInputAction;
    private InputAction _move;

    private void Awake()
    {
        _playerInputAction = new PlayerInputAction();

        _move = _playerInputAction.Player.Move;

    }

    private void OnEnable()
    {
        _playerInputAction.Enable();
    }

    private void OnDisable()
    {
        _playerInputAction.Disable();
    }

    private void Update()
    {
        FrameInput = GatherInput();
    }

    private FrameInput GatherInput()
    {
        return new FrameInput
        {
            Move = _move.ReadValue<Vector2>()
        };
    }


}

public struct FrameInput
{
    public Vector2 Move;
}
