using System;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamageable
{
    [SerializeField] private CharacterStats stats;
    public Buff buff;
    private int _health;
    private int _attack;
    protected TurnManager turnManager;
    public event Action OnCharacterDied;

    private void Awake()
    {
        turnManager = FindObjectOfType<TurnManager>();
        turnManager.OnTurnStarted += ApplyBuff;
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

    public void Heal(int amount)
    {
        _health += amount;
    }

    protected void Attack(IDamageable target)
    {
        target.TakeDamage(_attack);
    }

    private void ApplyBuff()
    {
        buff.Apply(this);
    }

    private void OnDestroy()
    {
        turnManager.OnTurnStarted -= ApplyBuff;
    }
}