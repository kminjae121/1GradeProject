using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAttack : MonoBehaviour
{
    [Header ("Setting")]
    [SerializeField] private float _attackDamage;
    [field: SerializeField] public Transform AttackRange { get; set; }
    public bool IsAttack { get;  set; }
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private LayerMask _agentType;
    public bool _isContinuousAttack;

    private void Awake()
    {
        _isContinuousAttack = false;
    }
    public void BasicAttack()
    {
        if (_isContinuousAttack == true)
        {
            Collider2D[] hit = Physics2D.OverlapBoxAll(AttackRange.position, _boxSize, 0, _agentType);

            foreach (Collider2D Attack in hit)
            {
                Attack.transform.TryGetComponent(out AgentHealth agentHealth);

                agentHealth.MinusHealth(_attackDamage);
            }
            print("æ∆¿’");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(AttackRange.position, _boxSize);
        Gizmos.color = Color.white;
    }
}
