using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private WaitForSeconds _waitTimeSec;
    private bool _isAttack;

    private AgentAttack _agentAttack;
    private AgentMove _agentMove;

    public event Action JumpEvent;
    [field : SerializeField] public InputReader PlayerInput { get; set; }

    private void Awake()
    {
        _waitTimeSec = new WaitForSeconds(0.5f);
        _agentAttack = GetComponent<AgentAttack>();
        _agentMove = GetComponent<AgentMove>();
        _isAttack = true;
        PlayerInput.AttackEvent += HandleAttackEvent;
        PlayerInput.JumpKeyEvent += HandleJumpKeyEvent;
    }
    private void HandleAttackEvent()
    {
        if(_isAttack == true)
        {
            _agentAttack.Attack();
            StartCoroutine(AttackWait());
              print("»Ð");
        }
    }

    private void OnDestroy()
    {
        PlayerInput.JumpKeyEvent -= HandleJumpKeyEvent;
        PlayerInput.AttackEvent -= HandleAttackEvent;
    }
    private void HandleJumpKeyEvent()
    {
        if (_agentMove._isGround.Value)
        {
            JumpEvent?.Invoke();
            _agentMove.Jump();
        }
    }

    private void FilpX()
    {
        if(PlayerInput.Movement.x < 0)
        {
            transform.rotation = Quaternion.Euler(0,-150,0);
        }
        else if(transform.rotation == Quaternion.Euler(0, -150, 0) && PlayerInput.Movement.x == 0)
        {
            transform.rotation = Quaternion.Euler(0, -150, 0);
        }
        else if(PlayerInput.Movement.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }    
    }

    IEnumerator AttackWait()
    {
        PlayerInput._isMouseDown = false;
        yield return new WaitForSeconds(2f);
        PlayerInput._isMouseDown = true;
        _isAttack = false;
        yield return _waitTimeSec;
        _isAttack = true;   
    }

    private void Update()
    {
        FilpX();
        _agentMove.SetMovement(PlayerInput.Movement.x);
    }

}