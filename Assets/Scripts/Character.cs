using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public new TextMeshProUGUI name;
    public CharacterSO characterSo;
    public List<BuffSO> buffs;
    private TurnManager _turnManager;

    private void Awake()
    {
        _turnManager = FindObjectOfType<TurnManager>();
        _turnManager.OnTurnStarted += ApplyBuffs;
        _turnManager.OnTurnEnded += ApplyBuffs;
    }

    private void Start() => spriteRenderer.sprite = characterSo.sprite;

    private void ApplyBuffs()
    {
        for (int i = 0; i < buffs.Count; i++)
        {
            switch (_turnManager.currentState)
            {
                case TurnManager.TurnState.Start:
                {
                    if (buffs[i].apply == BuffSO.ApplyOn.Start)
                    {
                        buffs[i].Execute(this);
                    }

                    break;
                }
                case TurnManager.TurnState.End:
                {
                    if (buffs[i].apply == BuffSO.ApplyOn.End)
                    {
                        buffs[i].Execute(this);
                    }

                    break;
                }
            }
        }

        for (int i = 0; i < buffs.Count; i++)
        {
            if (buffs[i].data.duration <= 0)
            {
                buffs.Remove(buffs[i]);
            }
        }
    }

    private void OnDestroy()
    {
        _turnManager.OnTurnStarted -= ApplyBuffs;
        _turnManager.OnTurnEnded -= ApplyBuffs;
    }
}