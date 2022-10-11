using UnityEngine;

public class CharacterSkinUI : MonoBehaviour
{
    [SerializeField] private CharacterStats skin;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake() => spriteRenderer.sprite = skin.skin.skin;
}