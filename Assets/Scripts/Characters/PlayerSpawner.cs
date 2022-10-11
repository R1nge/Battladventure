using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private void Awake() => Instantiate(CharacterManager.GetInstance().GetCharacter());
}