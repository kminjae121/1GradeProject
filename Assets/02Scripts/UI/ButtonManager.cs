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
    public bool IsStore;
    [SerializeField] private Button _Skill2Button;
    [SerializeField] private Button _Skill1Button;

    private void Awake()
    {
        IsStore = false;
        MainStore.SetActive(false);
        StatStore.SetActive(false);
        SkillStore.SetActive(false);

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
        else if (IsStore == true && Input.GetKeyDown(KeyCode.Escape))
        {
            MainStore.SetActive(false);
            IsStore = false;
        }
    }

    public void PlusHealth()
    {
        if (_coin.Coin >= 5)
        {
            _coin._isAttack = true;
            _coin.Coin -= 5;
            _coin.MaxHealth += 10;
        }
    }

    public void EnterStatStore()
    {
        _coin._isAttack = true;
        StatStore.SetActive(true);
        MainStore.SetActive(false);
    }
    public void EnterSkillStore()
    {
        _coin._isAttack = true;
        SkillStore.SetActive(true);
        MainStore.SetActive(false);
    }

    public void ExitMainStore()
    {
        _coin._isAttack = true;
        MainStore.SetActive(true);
        StatStore.SetActive(false);
        SkillStore.SetActive(false);
    }

    public void PlusAttackDamage()
    {
        _coin._isAttack = true;
        _coin.Coin -= 10;
        _coin.AttackDamage += 10;
    }


    public void StudySkill1()
    {
        if (_coin.Coin >= 15 && _Skill2Button.interactable == true)
        {
            _coin._isAttack = true;
            _coin.Coin -= 15;
            _playerSkill.IsSkill = true;
            _Skill1Button.interactable = false;
        }
    }

    public void StudySkill2()
    {
        if (_coin.Coin >= 20 && _Skill2Button.interactable == true)
        {
            _coin._isAttack = true;
            _coin.Coin -= 20;
            _playerSkill2.IsSkill2 = true;
            _Skill2Button.interactable = false;
        }
    }
}
