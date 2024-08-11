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
            Enemy._agentMove.SetMovement(Enemy.Player.transform.position.x - Enemy.transform.position.x);
        }
    }



    public override void Exit()
    {
        base.Exit();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        if (Enemy.IsMove == false)
        {
            Enemy.ChangeState(StateEnum.EnemyIdle);
        }
        if(Enemy.IsAttack == true)
        {
            Enemy.ChangeState(StateEnum.EnemyAttack);
        }
    }
}
