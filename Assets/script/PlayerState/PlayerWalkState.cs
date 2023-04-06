using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : State
{
    private PlayerController _playerController;

    public PlayerWalkState(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public override void OnEnter()
    {
        _playerController.Animator.SetTrigger("Walk");
    }

    public override void OnUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal == 0f)
        {
            _playerController.StateMachine.SetState(PlayerStateType.Idle);
            return;
        }

        horizontal *= _playerController.walkSpeed * Time.deltaTime;

        _playerController.transform.Translate(horizontal, 0, 0);

        _playerController.FlipSprite(horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerController.StateMachine.SetState(PlayerStateType.Jump);
        }
    }
}
