using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    [field: SerializeField] public InputReader PlayerInput { get; set; }
    [SerializeField] private AgentMove _agentMove;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerSkill _playerSkill1;
    [SerializeField] private PlayerSkill _playerSkill2;
    [SerializeField] private AgentHealth _agentHealth;
    [SerializeField] private PlayerDash _playerDash;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void PlayerMoveAnimator()
    {
        if(PlayerInput.Movement.x != 0 && _playerSkill1.IsSkillAnimator1 == false && _playerSkill2.IsSkillAnimator2 == false)
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

    private void PlayerAttackAnimator()
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

    private void PlayerSkill1()
    {
        if(_playerSkill1.IsSkillAnimator1 == true)
        {
            _animator.SetBool("Skill1", true);
        }
        else if(_playerSkill1.IsSkillAnimator1 == false)
        {
            _animator.SetBool("Skill1", false);
        }
    }

    private void PlayerSkill2()
    {
        if(_playerSkill2.IsSkillAnimator2 == true)
        {
            _animator.SetBool("Skill2", true);
        }
        else if(_playerSkill2.IsSkillAnimator2 == false)
        {
            _animator.SetBool("Skill2", false);
        }
    }
    private void PlayerDie()
    {
<<<<<<< HEAD
        if(_agentHealth.health <= 0)

=======
        if(_agentHealth.Health <= 0)
>>>>>>> parent of 507bcb3 (CoinAndUI)
        {
            _animator.SetBool("Die", true);
        }
    }


    private void PlayerDashAnimator()
    {
        if(_playerDash._IsDashAnimation == true)
        {
            _animator.SetBool("Dash", true);
        }
        else
        {
            _animator.SetBool("Dash", false);
        }
    }


    private void Update()
    {
        PlayerDashAnimator();
        PlayerDie();
        PlayerSkill1();
        PlayerSkill2();
        PlayerAttackAnimator();
        PlayerMoveAnimator();
        PlayerJumpAnimator();
    }

}
