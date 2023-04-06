using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : State
{
    private PlayerController _playerController;

    public PlayerJumpState(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public override void OnEnter()
    {
        _playerController.Animator.SetTrigger("Jump");

        _playerController.Rigidbody2D.AddForce(Vector2.up * _playerController.jumpForce, ForceMode2D.Impulse);

        


    }

    public override void OnUpdate()
    {
        if (_playerController.Rigidbody2D.velocity.y < 0)
        {
            _playerController.StateMachine.SetState(PlayerStateType.Fall);
        }


        // controlli arerei
        float horizontal = Input.GetAxis("Horizontal");        

        horizontal *= _playerController.walkSpeed * Time.deltaTime;

        _playerController.transform.Translate(horizontal, 0, 0);

        _playerController.FlipSprite(horizontal);
    }
}
