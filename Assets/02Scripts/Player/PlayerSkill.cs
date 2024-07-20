using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum Skill
{
    Skill1,
    Skill2,
}

public class PlayerSkill : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private Vector2 _skillBox;
    [SerializeField] private LayerMask _agentType;
    [SerializeField] private Transform _skillRange;
    [SerializeField] private int _skillDamage;
    [SerializeField] private float _waitTime;
    [SerializeField] private Player _player;
    [SerializeField] private AgentMove _agentMove;
    [SerializeField] private PlayerDash _playerDash;
    [SerializeField] private Rigidbody2D _rbCompo;
    [SerializeField] private BoxCollider2D _boxCollider;

    [SerializeField] private PlayerStat _playerStat;

    [field: SerializeField] public float DashSpeed { get; set; }
    public bool IsSkill { get; set; }
    public bool IsSkillAnimator1 { get; set; }
    public bool IsSkill2 { get; set; }
    public bool IsSkillAnimator2 { get; set; }

    public static bool IsSkilling;

    [SerializeField] private Skill _skill;
    [SerializeField] private InputReader _playerInput;
    [SerializeField] private Color color;
  

    private void OnEnable()
    {
        IsSkilling = true;
        IsSkill = true;
        IsSkill2 = true;
        if (_skill == Skill.Skill1)
        {
            _playerInput.Skill1Event += HandleSkill;
        }
        if (_skill == Skill.Skill2)
        {
            _playerInput.Skill2Event += HandleSkill2;
        }
    }


    private void Start()
    {
        IsSkill = _playerStat.IsQTrue;
        IsSkill2 = _playerStat.IsETrue;
    }


    private void OnDestroy()
    {
        _playerInput.Skill1Event -= HandleSkill;
        _playerInput.Skill2Event -= HandleSkill2;
    }
    private void HandleSkill()
    {
        if (_skill == Skill.Skill1 && IsSkill == true && IsSkilling != false && _agentMove._isGround.Value)
        {
            SkillTool();
            StartCoroutine(Wait(0));
        }
    }

    private void HandleSkill2()
    {
        if(_skill ==Skill.Skill2 && IsSkill2 == true && IsSkilling != false && _agentMove._isGround.Value)
        {
            SkillTool();
            StartCoroutine(Wait2());
        }
    }

    private void Update()
    {
        _playerStat.IsETrue = IsSkill;
        _playerStat.IsQTrue = IsSkill2;

    }

    private void SkillTool()
    {
        Collider2D[] Skill = Physics2D.OverlapBoxAll(_skillRange.position, _skillBox, 0, _agentType);
        
        foreach(Collider2D skill in Skill)
        {
            skill.transform.TryGetComponent(out AgentHealth agentHealth);

            agentHealth.MinusHealth(_skillDamage);
        }
    } 

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawWireCube(_skillRange.position, _skillBox);
        Gizmos.color = Color.white;    
<<<<<<< HEAD
    }


    IEnumerator Wait(float zero)
    {

=======
>>>>>>> parent of 507bcb3 (CoinAndUI)
    }

    IEnumerator Wait(float zero)
    {
        _agentMove.IsMove = false;
        IsSkillAnimator1 = true;
        IsSkilling = false;
        IsSkill = false;
        _rbCompo.velocity = Vector2.zero;
        _rbCompo.velocity = new Vector2(transform.right.x * DashSpeed, zero);
        _rbCompo.gravityScale = 0;
        _boxCollider.isTrigger = true;
        yield return new WaitForSeconds(0.25f);
        _rbCompo.gravityScale = 3.14f;
        _boxCollider.isTrigger = false;
        yield return new WaitForSeconds(_waitTime);
        IsSkilling = true;
        IsSkillAnimator1 = false;
        _agentMove.IsMove = true;
        yield return new WaitForSeconds(3);
        IsSkill = true;
    }

    IEnumerator Wait2()
    {
        _agentMove.IsMove = false;
        IsSkillAnimator2 = true;
        IsSkilling = false;
        IsSkill2 = false;
        yield return new WaitForSeconds(_waitTime);
        IsSkilling = true;
        IsSkillAnimator2 = false;
        _agentMove.IsMove = true;
        yield return new WaitForSeconds(5);
        IsSkill2 = true;
    }
}
