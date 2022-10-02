using System;
using UnityEngine;

public abstract class BuffSO : ScriptableObject
{
    public int amount;
    public int duration;
    public MyTarget target;
    public ApplyState applyState;

    public enum MyTarget
    {
        Player,
        Enemy,
        Both
    }

    public enum ApplyState
    {
        OnStart,
        OnEnd
    }

    public void Apply(Character character, BuffData data)
    {
        Execute(character);
        data.duration--;
        Delete(character, data);
    }

    protected abstract void Execute(Character character);

    private void Delete(Character character, BuffData data)
    {
        if (data.duration <= 0)
        {
            character.buffs.Remove(this);
        }
    }
}