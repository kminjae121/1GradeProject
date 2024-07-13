using System;
using UnityEngine;

[Serializable]
public class NotifyValue<T>
{
    public delegate void ValueChanged(T prev, T next);

    public event ValueChanged OnValueChanged;

    //public event Action<T, T> OnValueChangedAction;

    [SerializeField] private T _value;
    
    public T Value
    {
        get
        {
            return _value;
        }
        set
        {
            T before = _value; // 현재 값을 before에 담아준다
            _value = value; // _value에 입력값을 넣어준다.

            //before이 비어있지않고 입력값이 비어있지 않다거나 before가 _value가 같지않으면 OnValueChanged 실행
            if ((before == null && value != null) || !before.Equals(_value))
            {
                // 이전 값과 다음 값의 차이가 발생, 넘겨줄 시 다음 값을 전달
                OnValueChanged?.Invoke(before, _value);
            }

        }
    }

    public NotifyValue()
    {
        _value = default(T);
    }

    public NotifyValue(T value)
    {
        _value = value;
    }
}
