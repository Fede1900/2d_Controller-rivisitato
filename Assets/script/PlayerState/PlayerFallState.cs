using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : State
{
    private PlayerController _playerController;

    public PlayerFallState(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public override void OnEnter()
    {
        _playerController.Animator.SetTrigger("Fall");
    }

    public override void OnUpdate()
    {
        if (_playerController.IsGrounded)
        {
            _playerController.StateMachine.SetState(PlayerStateType.Idle);
        }

        //controlli arei
        float horizontal = Input.GetAxis("Horizontal");

        horizontal *= _playerController.walkSpeed * Time.deltaTime;

        _playerController.transform.Translate(horizontal, 0, 0);

        _playerController.FlipSprite(horizontal);
    }
}
