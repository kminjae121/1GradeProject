using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private WaitForSeconds _waitTimeSec;
    private WaitForSeconds _waitTimeSecond;
    public bool _isAttack { get; set; }
    public bool _isJump { get; set; }
    public bool _isChangeHealth;

    private AgentAttack _agentAttack;
    private AgentMove _agentMove;

    public event Action JumpEvent;
    [field: SerializeField] public InputReader PlayerInput { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
    [field: SerializeField] public float Coin { get; set; }
    [SerializeField] private PlayerStat _playerStat;
    public float AttackDamage { get; set; }
    public float Health { get; set; }
    public float MaxHealth { get; set; }

=======
>>>>>>> parent of 507bcb3 (CoinAndUI)
=======
>>>>>>> parent of 507bcb3 (CoinAndUI)

    private void Awake()
    {
        GetComp();
        _waitTimeSec = new WaitForSeconds(0.65f);
        _waitTimeSecond = new WaitForSeconds(0.08f);
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> parent of 507bcb3 (CoinAndUI)
=======
>>>>>>> parent of 507bcb3 (CoinAndUI)
        _agentAttack = GetComponent<AgentAttack>();
        _agentMove = GetComponent<AgentMove>();

        _isAttack = true;
        _isJump = true;
        PlayerInput.AttackEvent += HandleAttackEvent;
        PlayerInput.JumpKeyEvent += HandleJumpKeyEvent;
    }
<<<<<<< HEAD
<<<<<<< HEAD


    private void Start()
    {
        StatSetStart();
    }

    private void GetComp()
    {
        _agentHealth = GetComponent<AgentHealth>();
        _agentAttack = GetComponent<AgentAttack>();
        _agentMove = GetComponent<AgentMove>();
    }

    private void StatSetStart()
    {
        MaxHealth = _playerStat.MaxHealth;
        Health = _playerStat.MaxHealth;
        AttackDamage = _playerStat.AttackDamage;
        Coin = _playerStat.Coin;
    }
=======
>>>>>>> parent of 507bcb3 (CoinAndUI)
=======
>>>>>>> parent of 507bcb3 (CoinAndUI)
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

    private void SetStat()
    {
        _playerStat.AttackDamage = AttackDamage;
        _playerStat.Coin = Coin;
        _playerStat.Health = Health;
        _playerStat.MaxHealth = MaxHealth;
    }
    private void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        SetStat();

        _agentHealth.SetHealth(Health);

        if (Input.GetKeyDown(KeyCode.T))
        {
            Health -= 1;
        }
=======
>>>>>>> parent of 507bcb3 (CoinAndUI)
=======
>>>>>>> parent of 507bcb3 (CoinAndUI)
        if (_agentMove.IsMove == true)
        {
            FilpX();
        }
        _agentMove.SetMovement(PlayerInput.Movement.x);
    }

}