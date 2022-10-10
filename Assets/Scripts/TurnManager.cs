using System;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public event Action OnTurnStarted;

    public void MakeTurn()
    {
        OnTurnStarted?.Invoke();
    }
}