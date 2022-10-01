using TMPro;
using UnityEngine;

public class StateUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private TurnManager _turnManager;

    private void Awake()
    {
        _turnManager = FindObjectOfType<TurnManager>();
        _turnManager.OnTurnStarted += UpdateUI;
        _turnManager.OnTurnEnded += UpdateUI;
    }

    public void StartTurn() => _turnManager.StartTurn();

    public void EndTurn() => _turnManager.EndTurn();
    
    private void UpdateUI() => text.text = _turnManager.currentState.ToString();
}