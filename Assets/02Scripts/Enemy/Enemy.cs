using System;
using System.Collections.Generic;
using UnityEngine;
public enum StateEnum
{
    EnemyIdle,
    EnemyMove,
    EnemyAttack,
}

public class Enemy : Agent
{
    [field : SerializeField] public float _attackDamage { get; set; }
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private EnemyStat _enemySO;
    public GameObject Player;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private LayerMask _player;
    public bool IsMove { get; private set; }
    public bool IsAttack { get; private set; }
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
            EnemyState state = Activator.CreateInstance(t, this as object) as EnemyState;
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
        FollowPlayer();
        AttackRange();
    }

    private void FollowPlayer()
    {
        if (transform.position.x > Player.transform.position.x)
        {
            _sprite.flipX = true;
        }
        else
        {
            _sprite.flipX = false;
        }
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

    private void AttackRange()
    {
        Collider2D Attack = Physics2D.OverlapBox(transform.position, _boxSize, 0, _player);

        if(Attack == true)
        {
            IsAttack = true;
        }
        else
        {
            IsAttack = false;
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
