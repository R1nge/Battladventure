using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stats")]
public class Stats : ScriptableObject
{
    public int health;
    public int attack;
    public int energy;
}

[Serializable]
public class StatsData
{
    public event Action<int> OnHealthChanged;
    public event Action<int> OnAttackChanged;
    public event Action<int> OnEnergyChanged;

    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            OnHealthChanged?.Invoke(Health);
        }
    }

    public int Attack
    {
        get => _attack;
        set
        {
            _attack = value;
            OnAttackChanged?.Invoke(Attack);
        }
    }

    public int Energy
    {
        get => _energy;
        set
        {
            _energy = value;
            OnEnergyChanged?.Invoke(Energy);
        }
    }
    
    private int _health;
    private int _attack;
    private int _energy;
}