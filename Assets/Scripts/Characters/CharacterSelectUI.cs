using TMPro;
using UnityEngine;

public class CharacterSelectUI : MonoBehaviour
{
    [SerializeField] private CharacterStats stats;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TextMeshProUGUI health, attack;

    private void Awake()
    {
        spriteRenderer.sprite = stats.skin.skin;
        health.text = "Health: " + stats.health;
        attack.text = "Attack: " + stats.attack;
    }
}