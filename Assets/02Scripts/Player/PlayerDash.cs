using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private float DashSpeed;
    private Rigidbody2D _rbCompo;
    public bool _isDash { get; set; }
    [SerializeField] private InputReader _playerInput;
    private AgentMove _agentMove;
    [SerializeField] private BoxCollider2D _boxCollider;
    public bool _IsDashAnimation { get; set;}

    private void Awake()
    {
        _IsDashAnimation = false;
        _isDash = true;
        _rbCompo = GetComponent<Rigidbody2D>();
        _agentMove = GetComponent<AgentMove>();
        _playerInput.DashEvent += HandleDash;
    }

    private void OnDestroy()
    {
        _playerInput.DashEvent -= HandleDash;
    }

    public void HandleDash()
    {
        if(_isDash == true && PlayerSkill.IsSkilling == true)
        {
            StartCoroutine(Wait(0,DashSpeed));
        }
    }

    IEnumerator Wait(float zero, float DashSpeed)
    {
        _IsDashAnimation = true;
        PlayerSkill.IsSkilling = false;
        _isDash = false;
        _agentMove.IsMove = false;
        _rbCompo.velocity = Vector2.zero;
        _rbCompo.velocity = new Vector2(transform.right.x * DashSpeed,zero);
        _rbCompo.gravityScale = 0;
        _boxCollider.isTrigger = true;
        yield return new WaitForSeconds(0.3f);
        _boxCollider.isTrigger = false;
        _rbCompo.gravityScale = 3.14f;
        yield return new WaitForSeconds(0.6f);
        _agentMove.IsMove = true;
        _IsDashAnimation = false;
        PlayerSkill.IsSkilling = true;
        yield return new WaitForSeconds(3f);
        _isDash = true;
    }
}
