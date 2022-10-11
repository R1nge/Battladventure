using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : Singleton<CharacterManager>
{
    private GameObject _currentCharacter;

    public void SetCharacter(GameObject character)
    {
        _currentCharacter = character;
        //TODO: REDO
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public GameObject GetCharacter() => _currentCharacter;
}