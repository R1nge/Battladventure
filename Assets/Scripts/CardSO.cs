using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardSO", menuName = "Card")]
public class CardSO : ScriptableObject
{
    public List<BuffSO> buffSo = new List<BuffSO>();
    public Sprite sprite;
    public string description;
}