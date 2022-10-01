using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Buff/Heal")]
public class HealCard : BuffSO
{
    protected override void Apply(Character character)
    {
        character.characterSo.stats.data.Health += data.amount;
    }
}