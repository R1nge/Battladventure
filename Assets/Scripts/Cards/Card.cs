﻿using UnityEngine;

public abstract class Card : MonoBehaviour
{
    [SerializeField] protected Target target;
    public BuffSO buffSo;
    private Player _player;
    private Enemy _enemy;

    protected enum Target
    {
        Enemy,
        Player,
        Both
    }

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _enemy = FindObjectOfType<Enemy>();
    }

    private void OnMouseDown() => Use();

    protected abstract void Use();
    
    //TODO: REDO BOTH
    protected void Add(Buff buff, Buff buff2)
    {
        switch (target)
        {
            case Target.Enemy:
                _enemy.buffs.Add(buff);
                break;
            case Target.Player:
                _player.buffs.Add(buff);
                break;
            case Target.Both:
                _enemy.buffs.Add(buff);
                _player.buffs.Add(buff2);
                break;
        }
    }
}