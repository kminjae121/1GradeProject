using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controll;


[CreateAssetMenu (menuName = "SO/InputReader")]
public class InputReader : ScriptableObject,IPlayerActions
{
    private Controll _controll;
    public event Action JumpKeyEvent;
    public event Action<bool> AttackEvent;
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
}
