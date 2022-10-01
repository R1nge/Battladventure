using System;
using UnityEngine;

//Singleton
public class TurnManager : MonoBehaviour
{
    public event Action OnTurnStarted, OnTurnEnded;
    public TurnState currentState;

    public enum TurnState
    {
        Start,
        InProgress,
        End
    }

    public void StartTurn()
    {
        currentState = TurnState.Start;
        OnTurnStarted?.Invoke();
    }

    public void EndTurn()
    {
        currentState = TurnState.End;
        OnTurnEnded?.Invoke();
    }
}