using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMove : MonoBehaviour
{
    [Header("Setting")]
    public int Movespeed;
    public int JumpPower;
    public bool IsJump { get; set; }
    public bool IsMove { get; set;}

    [SerializeField] private Vector2 _boxSize;

    [SerializeField] private LayerMask _whatIsGround;
    
    
    [field: SerializeField] public Transform groundChecker { get; set; }
    public NotifyValue<bool> _isGround = new NotifyValue<bool>();


    private Rigidbody2D _rigid;

    protected float _xmove;
     
    private void Awake()
    {
        IsMove = true;
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void SetMovement(float Xmove)
    {
        _xmove = Xmove;
    }

    public void Jump(float multiplier = 1f)
    {
        _rigid.velocity = Vector2.zero;
        _rigid.AddForce(transform.up * JumpPower *multiplier, ForceMode2D.Impulse);
    }

    public bool JumpRange()
    {
        Collider2D hit = Physics2D.OverlapBox(groundChecker.position,_boxSize, 0, _whatIsGround);

        return hit;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundChecker.position, _boxSize);
        Gizmos.color = Color.white;
    }

    private void FixedUpdate()
    {
        _isGround.Value = JumpRange();

        if (IsMove == true)
            _rigid.velocity = new Vector2(_xmove * Movespeed, _rigid.velocity.y);
    }

}
