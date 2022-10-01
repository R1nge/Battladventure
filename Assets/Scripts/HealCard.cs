using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Buff/Heal")]
public class HealCard : BuffSO
{
    //TODO: Separate duration from SO
    public override void Execute(Character character)
    {
        if (apply == ApplyOn.Click)
        {
            character.character.stats.health += data.amount;
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
                character.character.stats.health += data.amount;
                break;
        }
    }
}