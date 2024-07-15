using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private float DashSpeed = 4;
    private Rigidbody2D _rbCompo;
    public bool _isDash { get; set; }
    [SerializeField] private InputReader _playerInput;

    private void Awake()
    {
        _rbCompo = GetComponent<Rigidbody2D>();
        _playerInput.DashEvent += HandleDash;
    }

    private void OnDestroy()
    {
        _playerInput.DashEvent -= HandleDash;
    }

    private void HandleDash()
    {
        if(_isDash == true)
            _rbCompo.AddForce(transform.right * DashSpeed, ForceMode2D.Impulse);
    }

    IEnumerator Wait()
    {
        _rbCompo.AddForce(transform.right * DashSpeed, ForceMode2D.Impulse);
        _isDash = false;
        yield return new WaitForSeconds(3f);
        _isDash = true;
    }
}
