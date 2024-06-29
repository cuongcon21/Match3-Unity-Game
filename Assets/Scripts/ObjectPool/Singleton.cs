using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Object
{ 
    private static T mInstance;

    public static T Instance
    {
        get
        {
            if (mInstance == null)
                mInstance = FindObjectOfType<T>();
            return mInstance;
        }
    }
}
