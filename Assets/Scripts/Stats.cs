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
        data.health = health;
        data.attack = attack;
        data.energy = energy;
    }
}

[Serializable]
public class Data
{
    public int health;
    public int attack;
    public int energy;
}