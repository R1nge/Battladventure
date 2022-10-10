using UnityEngine;

public class Card : MonoBehaviour
{
    public BuffSO buffSo;
    private void OnMouseDown()
    {
        var buff = FindObjectOfType<Player>().buff = new Buff();
        buff.amount = buffSo.buff.amount;
        buff.duration = buffSo.buff.duration;
        Destroy(gameObject);
    }
}