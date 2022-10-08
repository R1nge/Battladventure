using UnityEngine;

[CreateAssetMenu(fileName = "HealthBuff", menuName = "Buffs/Health")]
public class HealthBuff : BuffSO
{
    protected override void Execute(Character character)
    {
        character.stats.Health += amount;
    }
}