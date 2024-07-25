using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    public AgentMove _agentMove { get; set; }
    public AgentHealth _agentHealth { get; set; }
    public AgentAttack _agentAttack { get; set; }

    protected virtual void Awake()
    {
        _agentMove = GetComponent<AgentMove>();
        _agentHealth = GetComponent<AgentHealth>();
        _agentAttack = GetComponent<AgentAttack>();
    }
}
