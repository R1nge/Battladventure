using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character")]
public class CharacterSO : ScriptableObject
{
    public Sprite sprite;
    public new string name;
    public Stats stats;
}