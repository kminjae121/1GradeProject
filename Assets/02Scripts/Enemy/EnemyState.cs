using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;

    public EnemyState(Enemy owner)
    {
        enemy = owner;
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
