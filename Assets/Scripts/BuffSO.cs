﻿using UnityEngine;

public abstract class BuffSO : ScriptableObject
{
    public Sprite sprite;
    public string description;
    public int amount;
    public float duration;
    public ApplyOn apply;
    public Target target;

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