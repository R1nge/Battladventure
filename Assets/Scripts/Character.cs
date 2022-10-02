using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public TextMeshProUGUI health;
    public CharacterSO characterSo;
    public List<BuffSO> buffs;
    public List<BuffData> buffsData;
    public StatsData stats;
    private TurnManager _turnManager;

    private void Awake()
    {
        _turnManager = FindObjectOfType<TurnManager>();
        _turnManager.OnTurnStarted += ApplyBuffs;
        _turnManager.OnTurnEnded += ApplyBuffs;
        stats = new StatsData
        {
            Attack = characterSo.stats.attack,
            Energy = characterSo.stats.energy,
            Health = characterSo.stats.health
        };
        buffsData = new List<BuffData>();
        stats.OnHealthChanged += UpdateUI;
    }

    private void Start()
    {
        spriteRenderer.sprite = characterSo.sprite;

        for (int i = 0; i < buffs.Count; i++)
        {
            if (buffsData.Count < buffs.Count)
            {
                buffsData.Add(new BuffData
                {
                    duration = buffs[i].duration
                });
            }
        }
    }

    private void ApplyBuffs()
    {
        for (int i = 0; i < buffs.Count; i++)
        {
            if (buffsData.Count < buffs.Count)
            {
                buffsData.Add(new BuffData
                {
                    duration = buffs[i].duration
                });
            }

            if (buffsData[i].duration > 0)
            {
                buffs[i].Apply(this, buffsData[i]);
            }
        }

        for (int i = 0; i < buffsData.Count; i++)
        {
            if (buffsData[i].duration <= 0)
            {
                buffsData.RemoveAt(i);
            }
        }
    }

    private void UpdateUI(int value) => health.text = value.ToString();

    private void OnDestroy()
    {
        _turnManager.OnTurnStarted -= ApplyBuffs;
        _turnManager.OnTurnEnded -= ApplyBuffs;
        stats.OnHealthChanged -= UpdateUI;
    }
}