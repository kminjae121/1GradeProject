using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private Vector2 _skillBox;
    [SerializeField] private LayerMask _agentType;
    [SerializeField] private Transform _skillRange;
    [SerializeField] private int _skillDamage;

    private void Update()
    {
        
    }

    private void SkillTool()
    {
        Collider2D[] Skill1 = Physics2D.OverlapBoxAll(_skillRange.position, _skillBox, 0, _agentType);
        
        foreach(Collider2D skill1 in Skill1)
        {
            skill1.transform.TryGetComponent(out AgentHealth agentHealth);

            agentHealth.MinusHealth(_skillDamage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_skillRange.position, _skillBox);
        Gizmos.color = Color.white;
    }
}
