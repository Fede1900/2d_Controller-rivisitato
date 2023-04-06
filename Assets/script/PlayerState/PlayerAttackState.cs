using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : State
{
    private PlayerController _playerController;

    float duration;

    public PlayerAttackState(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public override void OnEnter()
    {
        _playerController.Animator.SetTrigger("Attack");

        


       // duration = _playerController.Animator.GetCurrentAnimatorStateInfo(0).length;   //prende il tempo di idle, forse perchè sono messi a livello di codice troppo attaccati

        Debug.Log(duration);





    }

    public override void OnUpdate()
    {
        if (duration <= 0)
        {
            duration = _playerController.Animator.GetCurrentAnimatorStateInfo(0).length;       //soluzione

            Debug.Log(duration);
        }


        duration -= Time.deltaTime;

        if (duration <= 0)
        {
            _playerController.StateMachine.SetState(PlayerStateType.Idle);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
