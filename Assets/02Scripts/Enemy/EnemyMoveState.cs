public class EnemyMoveState : EnemyState
{
    public EnemyMoveState(Enemy enemy) : base(enemy)
    {

    }

    public override void Enter()
    {
        base.Enter();
        EnemyMove();
    }

    public void EnemyMove()
    {
        if (Enemy.IsMove == true)
        {
            _agentMove.SetMovement(Enemy.Player.transform.position.x - Enemy.transform.position.x);
        }
        else if (Enemy.IsMove == false)
        {
            Enemy.ChangeState(StateEnum.EnemyIdle);
        }
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
