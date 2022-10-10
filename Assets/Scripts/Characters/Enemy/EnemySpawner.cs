using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;
    private int _index;

    public void SpawnNext()
    {
        Instantiate(enemies[_index].gameObject);
        //_index++;
    }
}