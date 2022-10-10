public class Enemy : Character
{
    private Player _player;
    private EnemySpawner _spawner;
    private CardManager _cardManager;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _spawner = FindObjectOfType<EnemySpawner>();
        _cardManager = FindObjectOfType<CardManager>();
        turnManager.OnTurnStarted += delegate { Attack(_player); };
        OnCharacterDied += SpawnNextEnemy;
    }

    private void SpawnNextEnemy()
    {
        _spawner.SpawnNext();
        print("Spawned next enemy");
        _cardManager.ShowCards();
        Destroy(gameObject);
    }
}