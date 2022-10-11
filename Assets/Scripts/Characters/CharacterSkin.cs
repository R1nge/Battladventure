using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "Character/Skin")]
public class CharacterSkin : ScriptableObject
{
    public Sprite skin;
    public new string name;
}