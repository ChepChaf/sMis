using UnityEngine;
using System.Collections;
using System;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    static T _instance;
    public static T Instance
    {
        get { return _instance; }
    }
    // Use this for initialization
    void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Trying to initialize existing singleton of class: " + typeof(T).ToString());
            return;
        }

        _instance = this as T;

        Initialization();
    }

    protected virtual void Initialization()
    {
    }
}