using UnityEngine;

public class DiceUI : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerDice, enemyDice;
    [SerializeField] private Sprite[] player, enemy;

    public void UpdateUI(int playerVal, int enemyVal)
    {
        playerDice.sprite = player[playerVal];
        enemyDice.sprite = enemy[enemyVal];
    }
}