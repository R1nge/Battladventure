using TMPro;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TextMeshProUGUI title, description;
    [SerializeField] private CardData cardData;

    private void Awake()
    {
        spriteRenderer.sprite = cardData.icon;
        title.text = cardData.title;
        description.text = cardData.description;
    }
}