using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private Card[] cards;
    [SerializeField] private Transform[] positions;
    private CardManagerUI _ui;

    private void Awake() => _ui = GetComponent<CardManagerUI>();

    public void ShowCards()
    {
        for (int i = 0; i < 3; i++)
        {
            var instance = Instantiate(cards[i].gameObject, positions[i].position, Quaternion.identity);
            instance.transform.parent = positions[i];
        }

        _ui.BlockInput();
    }

    public void HideCards()
    {
        for (int i = 0; i < 3; i++)
        {
            if (positions[i].childCount == 0) continue;
            Destroy(positions[i].GetChild(0).gameObject);
        }

        _ui.UnlockInput();
    }
}