using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private AgentMove _agentMove;
    public event Action JumpEvent;
    [field : SerializeField] public InputReader PlayerInput { get; set; }

    private void Awake()
    {
        _agentMove = GetComponent<AgentMove>();
        PlayerInput.JumpKeyEvent += HandleJumpKeyEvent;
    }
    private void OnDestroy()
    {
        PlayerInput.JumpKeyEvent -= HandleJumpKeyEvent;
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

    private void Update()
    {
        FilpX();
        _agentMove.SetMovement(PlayerInput.Movement.x);
    }

}