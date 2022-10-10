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
        turnManager.OnTurnStarted += TryAttack;
        OnCharacterDied += SpawnNextEnemy;
    }

    private void TryAttack()
    {
        if (diceManager.Enemy > diceManager.Player)
        {
            Attack(_player);
        }
    }

    private void SpawnNextEnemy()
    {
        _spawner.SpawnNext();
        print("Spawned next enemy");
        _cardManager.ShowCards();
        Destroy(gameObject);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        turnManager.OnTurnStarted -= TryAttack;
    }
}