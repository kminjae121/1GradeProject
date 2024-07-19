using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyCount : MonoBehaviour
{
    [SerializeField] private Player _item;
    private float _energyBallCount;
    private TextMeshProUGUI _energyText;

    private void Awake()
    {
        _energyText = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        _energyBallCount = _item.Coin;
        ItemUI(_energyBallCount);
    }

    private void ItemUI(float Count)
    {
        _energyText.text = $":   {Count}°³";
    }
}
