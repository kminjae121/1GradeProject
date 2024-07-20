using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHealth : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD

    [field: SerializeField] public float health { get; set; }
=======
    [field: SerializeField] public float Health { get; set; }
>>>>>>> parent of 507bcb3 (CoinAndUI)

    [field: SerializeField] public AgentMove _agentMove { get; set; }

=======
>>>>>>> parent of 507bcb3 (CoinAndUI)
    [field: SerializeField] public float Health { get; set; }



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
            StartCoroutine(Wait());
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

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.03f);
        gameObject.SetActive(false);
    }

}
