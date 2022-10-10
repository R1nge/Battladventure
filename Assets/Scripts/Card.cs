using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public BuffSO buffSo;
    private void OnMouseDown() => Use();

    protected abstract void Use();
}