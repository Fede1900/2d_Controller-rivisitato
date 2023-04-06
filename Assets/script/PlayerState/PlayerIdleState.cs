using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : State
{

    private PlayerController _playerController;

    public PlayerIdleState(PlayerController playerController)
    {
        _playerController = playerController;
    }
    public override void OnEnter()
    {
        //eseguiamo l'animazione di attesa

        _playerController.Animator.SetTrigger("Idle");
    }

    public override void OnUpdate()
    {
        //se il giocatore ha premuto i tasti per muoversi passo allo stato walk

        Debug.Log(_playerController.IsGrounded);

        if (!_playerController.IsGrounded)
        {
            _playerController.StateMachine.SetState(PlayerStateType.Fall);
            return;
        }

        if (Input.GetAxis("Horizontal") != 0f)
        {
            _playerController.StateMachine.SetState(PlayerStateType.Walk);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerController.StateMachine.SetState(PlayerStateType.Jump);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _playerController.StateMachine.SetState(PlayerStateType.Attack);
        }
    }
}
