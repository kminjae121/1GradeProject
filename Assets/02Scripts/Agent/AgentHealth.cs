using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHealth : MonoBehaviour
{
<<<<<<< HEAD
    [field: SerializeField] public float health { get; set; }
    [field: SerializeField] public AgentMove _agentMove { get; set; }
=======
    [field: SerializeField] public float Health { get; set; }

>>>>>>> parent of 507bcb3 (CoinAndUI)


    private void Awake()
    {
        
    }
    

    private void Die()
    {
        if(Health <= 0)
        {
            _agentMove.IsMove = false;
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
    private void LateUpdate()
    {
        Die();
    }

}
