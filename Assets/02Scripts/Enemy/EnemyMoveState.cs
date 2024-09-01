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
        if (enemy.IsMove == true)
        {
            enemy._agentMove.SetMovement(enemy.Player.transform.position.x - enemy.transform.position.x);
        }
    }



    public override void Exit()
    {
        base.Exit();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        if (enemy.IsMove == false)
        {
            enemy.ChangeState(StateEnum.EnemyIdle);
        }
        else if (enemy.IsAttack == true)
        {
            enemy.ChangeState(StateEnum.EnemyAttack);
        }
    }
}
