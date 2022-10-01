using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stats")]
public class Stats : ScriptableObject
{
    public int health;
    public int attack;
    public int energy;
    public Data data;
    
    private void OnEnable()
    {
        data.Health = health;
        data.attack = attack;
        data.energy = energy;
    }
}

[Serializable]
public class Data
{
    public event Action<int> OnHealthChanged;

    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            OnHealthChanged?.Invoke(Health);
        }
    }
    
    private int _health;

    public int attack;
    public int energy;
}