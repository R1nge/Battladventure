using UnityEngine;

[CreateAssetMenu(fileName = "Character Stats", menuName = "Character/Stats")]
public class CharacterStats : ScriptableObject
{
    public int health;
    public int attack;
    public CharacterSkin skin;
}