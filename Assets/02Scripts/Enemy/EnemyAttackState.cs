using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    
   
    public EnemyAttackState(Enemy owner) : base(owner)
    {

    }

    public override void Enter()
    {
        base.Enter();

        AttackManager();
    }


    private void AttackManager()
    {
        int _randomSkill = Random.Range(1, 4);

        switch (_randomSkill)
        {
            case 1:
                Attack();
                break;
            case 2:
                ComboSkill();
                break;
            case 3:
                EnforceSkill();
                break;
            case 4:
                SwingSkill();
                break;
        }
    }

    private void Attack()
    {
        if(enemy.Player.transform.TryGetComponent(out AgentHealth health))
        { 
        health.MinusHealth(enemy._attackDamage);
         Debug.Log("¿¿");
        enemy.IsAttack = false;
        Debug.Log("æ∆¿’ª–");
        }


    }

    private  void ComboSkill()
    {
        if (enemy.Player.transform.TryGetComponent(out AgentHealth health))
        {
            health.MinusHealth(enemy._attackDamage);
            Debug.Log("¿¿");
            enemy.IsAttack = false;
            Debug.Log("æ∆¿’ª–");
        }
    }

    private void EnforceSkill()
    {
        if (enemy.Player.transform.TryGetComponent(out AgentHealth health))
        {
            health.MinusHealth(enemy._attackDamage);
            Debug.Log("¿¿");
            enemy.IsAttack = false;
            Debug.Log("æ∆¿’ª–");
        }
    }

    private void SwingSkill()
    {
        if (enemy.Player.transform.TryGetComponent(out AgentHealth health))
        {
            health.MinusHealth(enemy._attackDamage);
            Debug.Log("¿¿");
            enemy.IsAttack = false;
            Debug.Log("æ∆¿’ª–");
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();

        if(enemy.IsAttack == false)
        {
            enemy.ChangeState(StateEnum.EnemyIdle);
        }
    }
}
