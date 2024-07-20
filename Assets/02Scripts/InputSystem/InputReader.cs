using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controll;


[CreateAssetMenu (menuName = "SO/InputReader")]
public class InputReader : ScriptableObject,IPlayerActions
{
    private Controll _controll;
    public event Action JumpKeyEvent;
    public event Action AttackEvent;
    public event Action Skill1Event;
    public event Action Skill2Event;
    public event Action DashEvent;
    public event Action IntractionEvent;

    public Vector2 Movement { get;  set; }

    private void OnEnable()
    {
        if(_controll == null)
        {
            _controll = new Controll();
        }
        _controll.Player.SetCallbacks(this);
        _controll.Player.Enable();
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
       if(context.performed)
        {
            JumpKeyEvent?.Invoke();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
        { 
            AttackEvent?.Invoke();
        }
    }

    public void OnSkill1(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Skill1Event?.Invoke();
        }
    }

    public void OnSkill2(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Skill2Event?.Invoke();
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            DashEvent?.Invoke();
        }
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            IntractionEvent?.Invoke();
        }
    }
}
