using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card")]
public class CardSO : ScriptableObject
{
    public List<BuffSO> buffs = new List<BuffSO>();
}