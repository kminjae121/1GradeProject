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
        if(Enemy.IsMove == true)
        {
            Enemy.ChangeState(StateEnum.EnemyMove);
        }

        if (Enemy.IsAttack == true)
        {
            Enemy.ChangeState(StateEnum.EnemyAttack);
        }
    }
}
