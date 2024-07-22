using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    protected AgentMove _agentMove;
    protected AgentHealth _agentHealth;
    protected AgentAttack _agentAttack;

    protected  void Awake()
    {
        _agentMove = GetComponent<AgentMove>();
        _agentHealth = GetComponent<AgentHealth>();
        _agentAttack = GetComponent<AgentAttack>();
    }
}
