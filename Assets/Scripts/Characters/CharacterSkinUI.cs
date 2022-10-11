using UnityEngine;

public class CharacterSkinUI : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Character _character;

    private void Awake()
    {
        _character = GetComponent<Character>();
        spriteRenderer.sprite = _character.GetStats().skin.skin;
    }
}