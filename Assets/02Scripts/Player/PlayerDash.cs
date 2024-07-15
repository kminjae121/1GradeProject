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
        _isDash = true;
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
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        Debug.Log("»Ð»Ð");
        _rbCompo.velocity = Vector2.right * DashSpeed;
        _isDash = false;
        yield return new WaitForSeconds(3f);
        _isDash = true;
    }
}
