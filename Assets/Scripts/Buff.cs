using System;

[Serializable]
public class Buff
{
    public int duration;
    public int amount;

    public virtual void Apply(Character character)
    {
        amount--;
        if (amount <= 0)
        {
            character.buff = null;
        }
    }
}