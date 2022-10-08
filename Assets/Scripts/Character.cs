using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public TextMeshProUGUI health;
    public CharacterSO characterSo;
    public List<BuffSO> buffs;
    public StatsData stats;
    private TurnManager _turnManager;
    private List<BuffData> _buffsData;

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
        _buffsData = new List<BuffData>();
        stats.OnHealthChanged += UpdateUI;
    }

    private void Start()
    {
        spriteRenderer.sprite = characterSo.sprite;

        for (int i = 0; i < buffs.Count; i++)
        {
            if (_buffsData.Count < buffs.Count)
            {
                _buffsData.Add(new BuffData
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
            if (_buffsData.Count < buffs.Count)
            {
                _buffsData.Add(new BuffData
                {
                    duration = buffs[i].duration
                });
            }
            else
            {
                if (buffs.Count <= 0)
                {
                    _buffsData.Clear();
                }
            }
        }
        
        for (int i = buffs.Count - 1; i >= 0; i--)
        {
            buffs[i].Apply(this, _buffsData[i]);
        }

        _buffsData.RemoveAll(r => r.duration <= 0);
    }

    private void UpdateUI(int value) => health.text = value.ToString();

    private void OnDestroy()
    {
        _turnManager.OnTurnStarted -= ApplyBuffs;
        _turnManager.OnTurnEnded -= ApplyBuffs;
        stats.OnHealthChanged -= UpdateUI;
    }
}