using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    [field: SerializeField] public InputReader PlayerInput { get; set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void PlayerMoveAnimator()
    {
        if(PlayerInput.Movement.x != 0)
        {
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }
    }


    private void Update()
    {
        PlayerMoveAnimator();
    }

}
