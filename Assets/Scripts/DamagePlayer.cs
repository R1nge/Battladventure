using UnityEngine;

[CreateAssetMenu(fileName = "DamagePlayer", menuName = "Buffs/DamagePlayer")]
public class DamagePlayer : BuffSO
{
    protected override void Execute(Character character)
    {
        character.stats.Health -= amount;
    }
}