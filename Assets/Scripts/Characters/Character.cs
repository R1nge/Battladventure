using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamageable
{
    [SerializeField] private CharacterStats stats;
    public List<Buff> buffs;
    public int Health { get; private set; }
    public int Attack { get; private set; }
    protected TurnManager turnManager;
    protected DiceManager diceManager;
    public event Action OnCharacterDied;
    private CharacterUI _characterUI;

    private void Awake()
    {
        turnManager = FindObjectOfType<TurnManager>();
        turnManager.OnTurnStarted += ApplyBuff;
        diceManager = FindObjectOfType<DiceManager>();
        _characterUI = GetComponent<CharacterUI>();
        InitValues();
    }

    private void InitValues()
    {
        Health = stats.health;
        Attack = stats.attack;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            OnCharacterDied?.Invoke();
        }

        _characterUI.UpdateUI();
    }

    public void Heal(int amount) => Health += amount;

    protected void Hit(IDamageable target) => target.TakeDamage(Attack);

    private void ApplyBuff()
    {
        for (int i = buffs.Count - 1; i >= 0; i--)
        {
            buffs[i].Apply(this);
        }

        _characterUI.UpdateUI();
    }

    protected virtual void OnDestroy() => turnManager.OnTurnStarted -= ApplyBuff;
}