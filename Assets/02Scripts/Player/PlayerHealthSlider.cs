using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSlider : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _healthSlider;
    private void Update()
    {
        SetSlider();
    }

    private void SetSlider()
    {
        _healthSlider.value = _player.Health;
        _healthSlider.maxValue = _player.MaxHealth;
    }
}
