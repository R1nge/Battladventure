using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Buff/Heal")]
public class HealCard : BuffSO
{
    protected override void Apply(Character character)
    {
        switch (apply)
        {
            case ApplyOn.Start:
            case ApplyOn.End:
                character.characterSo.stats.data.health += data.amount;
                break;
        }
    }
}