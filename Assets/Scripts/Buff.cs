using System;

[Serializable]
public class Buff
{
    public int duration;
    public int amount;

    public virtual void Apply(Character character)
    {
        duration--;
        if (duration <= 0)
        {
            character.buffs.Remove(this);
        }
    }
}