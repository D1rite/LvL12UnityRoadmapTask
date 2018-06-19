using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject spanableObject;
    // Use this for initialization
    public void Spawn()
    {
        ObjController.allObjList.Add( GameObject.Instantiate(spanableObject));
    }
}
