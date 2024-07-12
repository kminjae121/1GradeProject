using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMove : MonoBehaviour
{
    [Header("Setting")]
    public int Movespeed;
    public int JumpPower;
    public int BoxSize = 1;

    [SerializeField] private LayerMask player;
    [field: SerializeField] public Transform groundChecker { get; set; }


    private Rigidbody2D _rigid;

     
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void Movement(Vector2 MoveDir)
    {
        _rigid.velocity = MoveDir.normalized * Movespeed;
    }

    public void Jump()
    {
        _rigid.AddForce(transform.up.normalized * JumpPower);
    }

    private void JumpRange()
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll()
    }

    private void OnDrawGizmos()
    {
        
    }

}
