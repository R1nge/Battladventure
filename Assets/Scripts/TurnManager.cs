using System;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private TurnManagerUI _ui;
    public event Action OnTurnStarted;

    private void Awake() => _ui = GetComponent<TurnManagerUI>();

    private void Start() => InvokeRepeating(nameof(Auto), 0, 1);

    public void MakeTurn() => OnTurnStarted?.Invoke();

    private void Auto()
    {
        if (_ui.IsAuto())
        {
            MakeTurn();
        }
    }
}