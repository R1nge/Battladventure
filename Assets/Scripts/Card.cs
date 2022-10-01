using System;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI description;
    private SpriteRenderer _spriteRenderer;
    private BuffManager _buffManager;
    private BuffSO _buffSo;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _buffManager = FindObjectOfType<BuffManager>();
        _buffSo = _buffManager.Pick();
    }

    private void Start()
    {
        description.text = _buffSo.description;
        _spriteRenderer.sprite = _buffSo.sprite;
    }

    private void OnMouseDown() => Use();

    private void Use()
    {
        _buffManager.Use(_buffSo);
        Destroy(gameObject);
    }
}