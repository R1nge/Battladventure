﻿using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    private void Awake() => GetInstance();

    public static T GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<T>();
        }
        else if (instance != FindObjectOfType<T>())
        {
            Destroy(FindObjectOfType<T>());
        }

        DontDestroyOnLoad(instance.gameObject);
        return instance;
    }
}