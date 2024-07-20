using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Player _coin;
    [SerializeField] private GameObject StatStore;
    [SerializeField] private GameObject SkillStore;
    [SerializeField] private GameObject MainStore;
    [SerializeField] private PlayerSkill _playerSkill2;
    [SerializeField] private PlayerSkill _playerSkill;
    private bool IsStore;

    [SerializeField] private Button _Skill2Button;
    [SerializeField] private Button _Skill1Button;


    private void Awake()
    {
        IsStore = false;
        MainStore.SetActive(false);
        StatStore.SetActive(false);
        SkillStore.SetActive(false);
    }


    private void Start()
    {
        if (_playerSkill2.IsSkill2 == true)
        {
            _Skill2Button.interactable = false;
        }
        if (_playerSkill.IsSkill == true)
        {
            _Skill1Button.interactable = false;
        }
    }

    private void Update()
    {
        StartStore();
    }

    private void StartStore()
    {
        if (IsStore == false && Input.GetKeyDown(KeyCode.Escape))
        {
            MainStore.SetActive(true);
            IsStore = true;
        }
        else if(IsStore == true && Input.GetKeyDown(KeyCode.Escape))
        {
            MainStore.SetActive(false);
            IsStore = false;
        }
    }

    public void PlusHealth()
    {
        if(_coin.Coin >= 5)
        {
            _coin.Coin -= 5;
            _coin.MaxHealth += 10;
        }    
    }

    public void EnterStatStore()
    {
        StatStore.SetActive(true);
        MainStore.SetActive(false);
    }
    public void EnterSkillStore()
    {
        SkillStore.SetActive(true);
        MainStore.SetActive(false);
    }

    public void ExitMainStore()
    {
        MainStore.SetActive(true);
        StatStore.SetActive(false);
        SkillStore.SetActive(false);
    }

    public void PlusAttackDamage()
    {
        if(_coin.Coin >= 10)
        {
            _coin.Coin -= 10;
            _coin.AttackDamage += 10;
        }
    }


    public void StudySkill1()
    {
        if (_coin.Coin >= 15 && _playerSkill.IsSkill == false)
        {
            _Skill1Button.interactable = false;
            _coin.Coin -= 15;
            _playerSkill.IsSkill = true;
        }
    }

    public void StudySkill2()
    {
        if (_coin.Coin >= 20 && _playerSkill2.IsSkill2 == false)
        {
            _Skill2Button.interactable = false;
            _coin.Coin -= 20;
            ;
        }
    }
}