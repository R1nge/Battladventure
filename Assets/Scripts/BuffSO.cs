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

    public abstract void Execute(Character character);

    public void Add(Character character) => character.buffs.Add(this);
}