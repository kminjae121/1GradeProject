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
        Attack();
    }

    private void Attack()
    {
        Enemy._agentAttack.BasicAttack(Enemy._attackDamage);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }
}
