using System;
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

    public void Use(BuffSO buffSo)
    {
        switch (buffSo.apply)
        {
            case BuffSO.ApplyOn.Start:
                Add(buffSo);
                break;
            case BuffSO.ApplyOn.End:
                Add(buffSo);
                break;
            case BuffSO.ApplyOn.Click:
                Execute(buffSo);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Execute(BuffSO buff)
    {
        switch (buff.target)
        {
            case BuffSO.Target.Both:
                buff.Execute(_player);
                buff.Execute(_enemy);
                break;
            case BuffSO.Target.Enemy:
                buff.Execute(_enemy);
                break;
            case BuffSO.Target.Player:
                buff.Execute(_player);
                break;
        }
    }

    private void Add(BuffSO buff)
    {
        switch (buff.target)
        {
            case BuffSO.Target.Both:
                buff.Add(_player);
                buff.Add(_enemy);
                break;
            case BuffSO.Target.Enemy:
                buff.Add(_enemy);
                break;
            case BuffSO.Target.Player:
                buff.Add(_player);
                break;
        }
    }
}