public class DamageBuff : Buff
{
    public override void Apply(Character character)
    {
        base.Apply(character);
        character.TakeDamage(amount);
    }
}