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
    [SerializeField] private int _waitTime;
    [SerializeField] private Player _player;
    [SerializeField] private AgentMove _agentMove;
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

    private void OnDestroy()
    {
        _playerInput.Skill1Event -= HandleSkill;
        _playerInput.Skill2Event -= HandleSkill2;
    }
    private void HandleSkill()
    {
        if (IsSkill == true && IsSkilling != false && _agentMove._isGround.Value)
        {
            SkillTool();
            StartCoroutine(Wait());
        }
    }

    private void HandleSkill2()
    {
        if(IsSkill2 == true && IsSkilling != false && _agentMove._isGround.Value)
        {
            SkillTool();
            StartCoroutine(Wait2());
        }
    }

    private void Update()
    {
        
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
    }

    IEnumerator Wait()
    {
        _agentMove.IsMove = false;
        IsSkillAnimator1 = true;
        IsSkilling = false;
        IsSkill = false;
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
