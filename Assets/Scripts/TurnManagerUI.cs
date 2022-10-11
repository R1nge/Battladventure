using UnityEngine;
using UnityEngine.UI;

public class TurnManagerUI : MonoBehaviour
{
    [SerializeField] private Toggle auto;
    [SerializeField] private Button turn;

    public bool IsAuto()
    {
        var isOn = auto.isOn;
        turn.interactable = !isOn;
        return isOn;
    }
}