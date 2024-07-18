using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerSkill _playerSkill2;
    [SerializeField] private PlayerSkill _playerSkill;
    [SerializeField] private TextMeshProUGUI HealthText;
    [SerializeField] private TextMeshProUGUI DamageText;
    [SerializeField] private TextMeshProUGUI Skill2Text;
    [SerializeField] private TextMeshProUGUI Skill1Text;
    private bool IsCollect1;
    private bool IsCollect2;

    private void Update()
    {
        HealthTextMachine();
        DamageTextMachine();
        Skill1TextMachine();
        Skill2TextMachine();
    }


    private void HealthTextMachine()
    {
        HealthText.text = $"���� �ִ� ä��: {_player.MaxHealth}";
    }

    private void DamageTextMachine()
    {
        DamageText.text = $"���� ���ݷ�: {_player.AttackDamage}";
    }

    private void Skill1TextMachine()
    {
        IsCollect1 = true;
        Skill1Text.text = $"ȹ�濩��: {IsCollect1}";
    }
    private void Skill2TextMachine()
    {
        IsCollect2 = true;
        Skill2Text.text = $"ȹ�濩��: {IsCollect2}";
    }
}
