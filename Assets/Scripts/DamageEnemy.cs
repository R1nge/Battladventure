using UnityEngine;

[CreateAssetMenu(fileName = "HealPlayerDamageEnemy", menuName = "Buff/HealPlayerDamageEnemy", order = 0)]
public class DamageEnemy : BuffSO
{
    public override void Execute(Character character)
    {
        if (apply == ApplyOn.Click)
        {
            character.characterSo.stats.data.health -= data.amount;
            return;
        }

        if (data.duration <= 0) return;

        if (target == Target.Both)
        {
            Apply(character);
            data.duration -= 0.5f;
        }
        else
        {
            Apply(character);
            data.duration -= 1f;
        }
    }

    private void Apply(Character character)
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