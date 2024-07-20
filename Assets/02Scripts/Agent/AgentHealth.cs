using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHealth : MonoBehaviour
{


    [field: SerializeField] public float health { get; set; }


    [field: SerializeField] public AgentMove _agentMove { get; set; }




    private void Awake()
    {
        
    }
    private void Die()
    {
        if(health <= 0)
        {
            StartCoroutine(Wait());
        }
    }

    public void SetHealth(float Health)
    {
        health = Health;
    }

    public void MinusHealth(float AttackDamage)
    {
        health -= AttackDamage;
    }

    public void PlusHealth(float Heal)
    {
        health += Heal;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.03f);
        gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        Die();
    }

}
