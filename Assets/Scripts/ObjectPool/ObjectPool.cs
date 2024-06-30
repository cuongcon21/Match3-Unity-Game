using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//[System.Serializable]
//public class Preallocation
//{
//    public GameObject gameObject;
//    [HideInInspector]
//    public int count;
 
//}
public class ObjectPool : Singleton<ObjectPool>
{
    public List<GameObject> objInPool ;

    [HideInInspector]
    public List<GameObject> pooledGobjects;


    public GameObject Spawn(string tag)
    {
        for (int i = 0; i < pooledGobjects.Count; i++)
        {
            if (!pooledGobjects[i].activeSelf && pooledGobjects[i].name == tag)
            {
                pooledGobjects[i].transform.localScale = Vector3.one;
                pooledGobjects[i].SetActive(true);
                return pooledGobjects[i];
            }
        }

        for (int i = 0; i < objInPool.Count; i++)
        {
            if (objInPool[i].gameObject.name == tag)
            {
               
                    GameObject obj = CreateGobject(objInPool[i].gameObject, tag);
                    pooledGobjects.Add(obj);
                    obj.SetActive(true);
                    return obj;
                
            }
        }

        return null;
    }

    public void OffAll()
    {
        for (int i = 0; i < pooledGobjects.Count; i++)
        {
            if (!pooledGobjects[i].activeSelf)
            {
                pooledGobjects[i].SetActive (false);
            }
        }
    }

    GameObject CreateGobject(GameObject item, string tag)
    {
        GameObject gobject = Instantiate(item, transform);
        gobject.name = tag;
        gobject.SetActive(false);
        return gobject;
    }

    public bool isInPool(string tag)
    {
        for (int i = 0; i < objInPool.Count; i++)
        {
            if (objInPool[i].gameObject.name == tag)
            {
                return true;
            }
        }
        return false;
    }
 
}
