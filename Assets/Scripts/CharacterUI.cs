using TMPro;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite sprite;
    [SerializeField] private TextMeshProUGUI attack, health;
    private Character _character;

    private void Awake()
    {
        spriteRenderer.sprite = sprite;
        _character = GetComponent<Character>();
    }

    private void Start() => UpdateUI();

    public void UpdateUI()
    {
        attack.text = "Attack: " + _character.Attack;
        health.text = "Health: " + _character.Health;
    }
}