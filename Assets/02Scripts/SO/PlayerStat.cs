using UnityEngine;

[CreateAssetMenu(fileName = ("PlayerStat"))]
public class PlayerStat : ScriptableObject
{
    [field: SerializeField] public float Coin { get; set; }
    [field: SerializeField] public float AttackDamage { get; set; }
    [field: SerializeField] public float Health { get; set; }
    [field: SerializeField] public float MaxHealth { get; set; }

    [field: SerializeField] public bool IsQTrue { get; set; }
    [field: SerializeField] public bool IsETrue { get; set; }
}
