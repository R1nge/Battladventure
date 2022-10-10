public class HealBuff : Buff
{
    public override void Apply(Character character)
    {
        base.Apply(character);
        character.Heal(amount);
    }
}