using UnityEngine;

public class DiceManager : MonoBehaviour
{
    private TurnManager _turnManager;
    private DiceUI _diceUI;
    public int Player { get; private set; }
    public int Enemy { get; private set; }

    private void Awake()
    {
        _turnManager = FindObjectOfType<TurnManager>();
        _turnManager.OnTurnStarted += RollDice;
        _diceUI = FindObjectOfType<DiceUI>();
    }

    private void RollDice()
    {
        Player = Random.Range(0, 6);
        Enemy = Random.Range(0, 6);
        _diceUI.UpdateUI(Player, Enemy);
    }

    private void OnDestroy() => _turnManager.OnTurnStarted -= RollDice;
}