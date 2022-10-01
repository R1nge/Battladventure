using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CardSO cardSo;
    [SerializeField] private TextMeshProUGUI description;
    private SpriteRenderer _spriteRenderer;
    private BuffManager _buffManager;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _buffManager = FindObjectOfType<BuffManager>();
    }

    private void Start()
    {
        description.text = cardSo.description;
        _spriteRenderer.sprite = cardSo.sprite;
    }

    private void OnMouseDown() => Use();

    private void Use()
    {
        foreach (var buff in cardSo.buffSo)
        {
            _buffManager.Use(buff);
        }

        Destroy(gameObject);
    }
}