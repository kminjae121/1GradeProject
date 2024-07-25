using System;
using System.Collections.Generic;
using UnityEngine;
public enum StateEnum
{
    EnemyIdle,
    EnemyMove,
    EnemyAttack,
    EnemyDead,
}

public class Enemy : Agent
{
    [SerializeField] private EnemyStat _enemySO;
    public GameObject Player;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private LayerMask _player;
    public bool IsMove { get; private set; }
    private StateEnum _currentStatEnum;
    private Dictionary<StateEnum, EnemyState> _stateDictionary = new Dictionary<StateEnum, EnemyState>();


    protected override void Awake()
    {
        base.Awake();
        _agentHealth.SetHealth(_enemySO.Health);
        _agentMove.Movespeed = _enemySO.MoveSpeed;
        IsMove = false;

        foreach (StateEnum stateEnum in Enum.GetValues(typeof(StateEnum)))
        {
            string EnumName = stateEnum.ToString();
            Type t = Type.GetType(EnumName + "State");
            EnemyState state = Activator.CreateInstance(t, this) as EnemyState;
            _stateDictionary.Add(stateEnum, state);
        }
        ChangeState(StateEnum.EnemyIdle);
    }
    private void Start()
    {
    }

    private void Update()
    {
        _stateDictionary[_currentStatEnum].StateUpdate();
        MoveRange();
    }

    private void MoveRange()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, _boxSize, 0, _player);

        if (hit == true)
        {
            IsMove = true;
        }
        else
        {
            IsMove = false;
        }
    }

    public void ChangeState(StateEnum idle)
    {
        _stateDictionary[_currentStatEnum].Exit();
        _currentStatEnum = idle;
        _stateDictionary[_currentStatEnum].Enter();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _boxSize);
        Gizmos.color = Color.white;
    }
}
