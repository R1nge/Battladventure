using UnityEngine;

public class BuffManager : MonoBehaviour
{
    private Player _player;
    private Enemy _enemy;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _enemy = FindObjectOfType<Enemy>();
    }

    public void Add(BuffSO buffSo)
    {
        switch (buffSo.target)
        {
            case BuffSO.MyTarget.Player:
                _player.buffs.Add(buffSo);
                break;
            case BuffSO.MyTarget.Enemy:
                _enemy.buffs.Add(buffSo);
                break;
            case BuffSO.MyTarget.Both:
                _player.buffs.Add(buffSo);
                _enemy.buffs.Add(buffSo);
                break;
        }
    }
}