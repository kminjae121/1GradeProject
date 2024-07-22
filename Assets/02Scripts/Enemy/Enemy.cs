using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Agent
{
    [SerializeField] private EnemyStat _enemySO;
    private GameObject Player;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private LayerMask _player;

    private void Start()
    {
        _agentMove.Movespeed = 1;
        Player = GameObject.Find("Player");
        _agentHealth.SetHealth(_enemySO.Health);
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, _boxSize, 0, _player);

        if(hit == true)
        {
            _agentMove.SetMovement(Player.transform.position.x - transform.position.x);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _boxSize);
        Gizmos.color = Color.white;
    }

}
