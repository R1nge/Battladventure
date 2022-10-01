using UnityEngine;

[CreateAssetMenu(fileName = "HealPlayerDamageEnemy", menuName = "Buff/HealPlayerDamageEnemy", order = 0)]
public class DamageEnemy : BuffSO
{
    protected override void Apply(Character character)
    {
        switch (apply)
        {
            case ApplyOn.Start:
            case ApplyOn.End:
                character.characterSo.stats.data.health -= data.amount;
                break;
        }
    }
}