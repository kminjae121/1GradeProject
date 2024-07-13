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
            T before = _value; // ���� ���� before�� ����ش�
            _value = value; // _value�� �Է°��� �־��ش�.

            //before�� ��������ʰ� �Է°��� ������� �ʴٰų� before�� _value�� ���������� OnValueChanged ����
            if ((before == null && value != null) || !before.Equals(_value))
            {
                // ���� ���� ���� ���� ���̰� �߻�, �Ѱ��� �� ���� ���� ����
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
