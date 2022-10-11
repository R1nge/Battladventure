public class Player : Character
{
    private Enemy _enemy;

    private void Start()
    {
        _enemy = FindObjectOfType<Enemy>();
        turnManager.OnTurnStarted += TryAttack;
        OnCharacterDied += GameOver;
    }

    private void TryAttack()
    {
        if (diceManager.Player > diceManager.Enemy)
        {
            Hit(_enemy);
            //TODO: Move enemy and player references to separate class
            _enemy = FindObjectOfType<Enemy>();
        }
    }

    private void GameOver()
    {
        print("Game over");
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        turnManager.OnTurnStarted -= TryAttack;
    }
}