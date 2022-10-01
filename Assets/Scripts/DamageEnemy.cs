using UnityEngine;

[CreateAssetMenu(fileName = "HealPlayerDamageEnemy", menuName = "Buff/HealPlayerDamageEnemy", order = 0)]
public class DamageEnemy : BuffSO
{
    protected override void Apply(Character character)
    {
        character.characterSo.stats.data.Health -= data.amount;
    }
}