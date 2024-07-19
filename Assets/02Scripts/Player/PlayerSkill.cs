using System.Collections;
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
    [SerializeField] private float _skillDamage;
    [SerializeField] private float _waitTime;
    [SerializeField] private Player _player;
    [SerializeField] private AgentMove _agentMove;
    [SerializeField] private PlayerDash _playerDash;
    [SerializeField] private Rigidbody2D _rbCompo;
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private PlayerStat _playerStat;
    [field: SerializeField] public float DashSpeed { get; set; }    
    [field: SerializeField] public bool IsSkill { get; set; }
    public bool IsSkillAnimator1 { get; set; }
    [field: SerializeField] public bool IsSkill2 { get; set; }
    public bool IsSkillAnimator2 { get; set; }

    public static bool IsSkilling;

    public bool IsTrue { get; set; } = true;

    public bool IsFalse { get; set; } = false;

    public float GravityScale { get; set; } = 3.14f;

    [SerializeField] private Skill _skill;
    [SerializeField] private InputReader _playerInput;
    [SerializeField] private Color color;


    private void Awake()
    {
        IsSkilling = true;
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
        if (_skill == Skill.Skill1)
        {
            IsSkill = _playerStat.IsQTrue;
        }
        if(_skill == Skill.Skill2)
        {
            IsSkill2 = _playerStat.IsETrue;
        }
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
        if (_skill == Skill.Skill2 && IsSkill2 == true && IsSkilling != false && _agentMove._isGround.Value)
        {
            SkillTool();
            StartCoroutine(Wait2());
        }
    }

    private void Update()
    {
        if (_skill == Skill.Skill1)
        {
            _playerStat.IsQTrue = IsSkill;
        }

        if(_skill == Skill.Skill2)
        {
            _playerStat.IsETrue = IsSkill2;
        }
    }

    private void SkillTool()
    {
        Collider2D[] Skill = Physics2D.OverlapBoxAll(_skillRange.position, _skillBox, 0, _agentType);

        foreach (Collider2D skill in Skill)
        {
            skill.transform.TryGetComponent(out AgentHealth agentHealth);

            agentHealth.MinusHealth(_skillDamage += _player.AttackDamage);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawWireCube(_skillRange.position, _skillBox);
        Gizmos.color = Color.white;
    }


    private void MoveTrue(bool Not, bool Yes)
    {
        IsSkilling = Yes;
        IsSkillAnimator1 = Not;
        _agentMove.IsMove = Yes;
    }

    private void GravityTrue(float GravityScale, bool Not)
    {
        _rbCompo.gravityScale = GravityScale;
        _boxCollider.isTrigger = Not;
    }

    private void MoveFalse(bool Not, bool Yes)
    {
        _agentMove.IsMove = Not;
        IsSkillAnimator1 = Yes;
        IsSkilling = Not;
    }

    private void Jump(float zero)
    {
        _rbCompo.velocity = Vector2.zero;
        _rbCompo.velocity = new Vector2(transform.right.x * DashSpeed, zero);
        _rbCompo.gravityScale = 0;
        _boxCollider.isTrigger = true;
    }
    IEnumerator Wait(float zero)
    {
        MoveFalse(IsFalse, IsTrue);
        Jump(zero);
        yield return new WaitForSeconds(0.25f);
        GravityTrue(GravityScale, IsFalse);
        yield return new WaitForSeconds(_waitTime);
        MoveTrue(IsFalse, IsTrue);
        yield return new WaitForSeconds(3);
    }
    private void MoveTrue2(bool Not, bool Yes)
    {
        IsSkilling = Yes;
        IsSkillAnimator2 = Not;
        _agentMove.IsMove = Yes;
    }
    private void MoveFalse2(bool Not, bool Yes)
    {
        _agentMove.IsMove = Not;
        IsSkillAnimator2 = Yes;
        IsSkilling = Not;
    }

    IEnumerator Wait2()
    {
        MoveFalse2(IsFalse, IsTrue);
        yield return new WaitForSeconds(_waitTime);
        MoveTrue2(IsFalse, IsTrue);
        yield return new WaitForSeconds(5);
    }


}
