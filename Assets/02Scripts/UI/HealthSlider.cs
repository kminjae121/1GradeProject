using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerStat _playerStat;
    private Slider _healthSlider;


    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
    }
    private void Update()
    {
        _healthSlider.maxValue = _playerStat.MaxHealth;
        SetSlider();
    }

    private void SetSlider()
    {
        _healthSlider.value = _player.Health;
    }
}
