using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    [field: SerializeField] public InputReader PlayerInput { get; set; }
    [SerializeField] private AgentMove _agentMove;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void PlayerMoveAnimator()
    {
        if(PlayerInput.Movement.x != 0)
        {
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }
    }

    private void PlayerJumpAnimator()
    {
        if(_agentMove._isGround.Value == false)
        {
            _animator.SetBool("Jump", true);
        }
        else
        {
            _animator.SetBool("Jump", false);
        }
    }

    private void PlayerAttack()
    {
        if (_player._isAttack == false)
        {
            _animator.SetBool("Attack", true);
        }
        else if (_player._isAttack == true)
        {
            _animator.SetBool("Attack", false);
        }
    }


    private void Update()
    {
        PlayerAttack();
        PlayerMoveAnimator();
        PlayerJumpAnimator();
    }

}
