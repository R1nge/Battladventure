using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamageable
{
    [SerializeField] private CharacterStats stats;
    public List<Buff> buffs;
    public int health { get; private set; }
    public int attack { get; private set; }
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
        health = stats.health;
        attack = stats.attack;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            OnCharacterDied?.Invoke();
        }

        _characterUI.UpdateUI();
    }

    public void Heal(int amount) => health += amount;

    protected void Attack(IDamageable target) => target.TakeDamage(attack);

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