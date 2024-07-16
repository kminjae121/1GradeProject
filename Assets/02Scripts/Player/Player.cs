using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private WaitForSeconds _waitTimeSec;
    private WaitForSeconds _waitTimeSecond;
    public bool _isAttack { get; set; }
    public bool _isJump { get; set; }

    private AgentAttack _agentAttack;
    private AgentMove _agentMove;

    public event Action JumpEvent;
    [field: SerializeField] public InputReader PlayerInput { get; set; }

    private void Awake()
    {
        _waitTimeSec = new WaitForSeconds(0.65f);
        _waitTimeSecond = new WaitForSeconds(0.08f);
        _agentAttack = GetComponent<AgentAttack>();
        _agentMove = GetComponent<AgentMove>();
        _isAttack = true;
        _isJump = true;
        PlayerInput.AttackEvent += HandleAttackEvent;
        PlayerInput.JumpKeyEvent += HandleJumpKeyEvent;
    }
    private void HandleAttackEvent()
    {
        if (_isAttack == true && _agentMove._isGround.Value && PlayerSkill.IsSkilling == true)
        {
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
        if (_agentMove._isGround.Value && _isJump == true)
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
        PlayerSkill.IsSkilling = false;
        _isJump = false;
        _agentMove.IsMove = false;
        _isAttack = false;
        _agentAttack._isContinuousAttack = true;
        _agentAttack.BasicAttack();
        yield return new WaitForSeconds(0.5f);
        _agentAttack._isContinuousAttack = true;
        _agentAttack.BasicAttack();
        yield return new WaitForSeconds(0.25f);
        _agentMove.IsMove = true;
        _isJump = true;
        yield return _waitTimeSec;
        _isAttack = true;
        PlayerSkill.IsSkilling = true;
    }

    private void Update()
    {
        if (_agentMove.IsMove == true)
        {
            FilpX();
        }
        _agentMove.SetMovement(PlayerInput.Movement.x);
    }
}