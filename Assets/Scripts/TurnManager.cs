using System;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private Toggle auto;
    [SerializeField] private Button turn;

    public event Action OnTurnStarted;

    private void Start() => InvokeRepeating(nameof(Auto), 0, 1);

    public void MakeTurn() => OnTurnStarted?.Invoke();

    private void Auto()
    {
        if (auto.isOn)
        {
            OnTurnStarted?.Invoke();
            turn.interactable = false;
        }
        else
        {
            turn.interactable = true;
        }
    }
}