using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamageable
{
    [SerializeField] private CharacterStats stats;
    public List<Buff> buffs;
    private int _health;
    private int _attack;
    protected TurnManager turnManager;
    protected DiceManager diceManager;
    public event Action OnCharacterDied;

    private void Awake()
    {
        turnManager = FindObjectOfType<TurnManager>();
        turnManager.OnTurnStarted += ApplyBuff;
        diceManager = FindObjectOfType<DiceManager>();
        InitValues();
    }

    private void InitValues()
    {
        _health = stats.health;
        _attack = stats.attack;
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            OnCharacterDied?.Invoke();
        }
    }

    public void Heal(int amount) => _health += amount;

    protected void Attack(IDamageable target) => target.TakeDamage(_attack);

    private void ApplyBuff()
    {
        for (int i = buffs.Count - 1; i >= 0; i--)
        {
            buffs[i].Apply(this);
        }
    }

    protected virtual void OnDestroy() => turnManager.OnTurnStarted -= ApplyBuff;
}