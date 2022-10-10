public class Player : Character
{
    private Enemy _enemy;

    private void Start()
    {
        _enemy = FindObjectOfType<Enemy>();
        turnManager.OnTurnStarted += delegate { Attack(_enemy); };
        OnCharacterDied += GameOver;
    }

    private void GameOver()
    {
        print("Game over");
    }
}