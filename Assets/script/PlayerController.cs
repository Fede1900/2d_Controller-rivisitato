using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    //state machine

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _ridigbody2d;
    public StateMachine<PlayerStateType> StateMachine { get; } = new();

    public int walkSpeed = 10;
    [SerializeField] private float groundCheckDistance;
    public LayerMask groundLayerMask;

    public float jumpForce = 10f;




    public Animator Animator
    {
        get
        {
            if (_animator == null)
            {
                _animator = GetComponent<Animator>();
            }

            return _animator;
        }
    }

    public SpriteRenderer SpriteRenderer
    {
        get
        {
            if (!_spriteRenderer)
            {
                _spriteRenderer = GetComponent<SpriteRenderer>();
            }

            return _spriteRenderer;
        }
    }

    public Rigidbody2D Rigidbody2D
    {
        get
        {
            if (!_ridigbody2d)
            {
                _ridigbody2d = GetComponent<Rigidbody2D>();
            }

            return _ridigbody2d;
        }
    }

    public bool IsGrounded => Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayerMask);
   
    private void Start()
    {
        //registriamo tutti gli stati possibili

        StateMachine.RegisterState(PlayerStateType.Idle, new PlayerIdleState(this));
        StateMachine.RegisterState(PlayerStateType.Walk, new PlayerWalkState(this));
        StateMachine.RegisterState(PlayerStateType.Fall, new PlayerFallState(this));
        StateMachine.RegisterState(PlayerStateType.Jump, new PlayerJumpState(this));
        StateMachine.RegisterState(PlayerStateType.Attack, new PlayerAttackState(this));

        //impostiamo il primo stato

        StateMachine.SetState(PlayerStateType.Idle);
    }

    private void Update()
    {
        //chiamo update della stateMachine
        StateMachine.Update();
    }

    public void FlipSprite(float speed)
    {
        
        SpriteRenderer.flipX = speed < 0f;
    }
}
