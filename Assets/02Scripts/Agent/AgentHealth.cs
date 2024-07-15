using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHealth : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private float Health;



    private void Awake()
    {
        
    }
    private void Update()
    {
        Die();
    }

    private void Die()
    {
        if(Health <= 0)
        {
            gameObject.SetActive(false);
        }
    }


    public void MinusHealth(float AttackDamage)
    {
        Health -= AttackDamage;
    }

    public void PlusHealth(float Heal)
    {
        Health += Heal;
    }

}
