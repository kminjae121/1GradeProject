using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controll;


[CreateAssetMenu (menuName = "SO/InputReader")]
public class InputReader : ScriptableObject,IPlayerActions
{
    private Player player;
    private Controll _controll;
    public event Action JumpKeyEvent;
    public event Action AttackEvent;
    public bool _isMouseDown;

    public Vector2 Movement { get; private set; }

    private void OnEnable()
    {
        if(_controll == null)
        {
            _controll = new Controll();
        }
        _controll.Player.SetCallbacks(this);
        _controll.Player.Enable();
        
    }

    private void Awake()
    {
        _isMouseDown = true;
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
}
