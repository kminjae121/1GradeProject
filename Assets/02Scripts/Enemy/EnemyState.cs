using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : Enemy
{
    protected Enemy Enemy;

    public EnemyState(Enemy owner)
    {
        Enemy = owner;
    }

    public virtual void Enter()
    {

    }
    public virtual void StateUpdate()
    {

    }
    public virtual void Exit()
    {

    }
}
