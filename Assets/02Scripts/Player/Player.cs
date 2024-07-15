using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private WaitForSeconds _waitTimeSec;
    public bool _isAttack;

    private AgentAttack _agentAttack;
    private AgentMove _agentMove;

    public event Action JumpEvent;
    [field: SerializeField] public InputReader PlayerInput { get; set; }

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
        if (_isAttack == true)
        {
            _agentAttack.Attack();
            StartCoroutine(AttackWait());
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
        if (PlayerInput.Movement.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, -150, 0);
        }
        else if (transform.rotation == Quaternion.Euler(0, -150, 0) && PlayerInput.Movement.x == 0)
        {
            transform.rotation = Quaternion.Euler(0, -150, 0);
        }
        else if (PlayerInput.Movement.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    IEnumerator AttackWait()
    {
        _isAttack = false;
        yield return new WaitForSeconds(1.04f);
        _isAttack = true;
    }

    private void Update()
    {
        FilpX();
        _agentMove.SetMovement(PlayerInput.Movement.x);
    }

}