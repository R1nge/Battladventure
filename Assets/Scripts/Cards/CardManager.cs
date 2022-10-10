using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private Card[] cards;
    [SerializeField] private Transform[] positions;

    public void ShowCards()
    {
        for (int i = 0; i < 3; i++)
        {
            var instance = Instantiate(cards[i].gameObject, positions[i].position, Quaternion.identity);
            instance.transform.parent = positions[i];
        }
    }

    public void HideCards()
    {
        for (int i = 0; i < 3; i++)
        {
            if (positions[i].childCount == 0) continue;
            Destroy(positions[i].GetChild(0).gameObject);
        }
    }
}