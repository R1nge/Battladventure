using UnityEngine;

public abstract class BuffSO : ScriptableObject
{
    public int amount;
    public float duration;
    public ApplyOn apply;
    public Target target;
    public BuffData data;

    protected void OnEnable() => data = new BuffData {amount = amount, duration = duration};

    public enum ApplyOn
    {
        Start,
        End,
        Click
    }

    public enum Target
    {
        Player,
        Enemy,
        Both
    }

    public void Execute(Character character)
    {
        if (apply == ApplyOn.Click)
        {
            Apply(character);
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

    protected abstract void Apply(Character character);

    public void Add(Character character) => character.buffs.Add(this);
}