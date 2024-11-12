using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    public static T Instance { get { return _instance; } }
    


    private void Awake()
    {
        if (_instance == null)
        {

            _instance = this as T;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
