using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(Enemy enemy) : base(enemy)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        if(enemy.IsMove == true)
        {
            enemy.ChangeState(StateEnum.EnemyMove);
        }

        if (enemy.IsAttack == true)
        {
            enemy.ChangeState(StateEnum.EnemyAttack);
        }
    }
}
