using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLocation
{
    public void ChangeSelectedObjLocation(Vector3 force)
    {
        foreach (GameObject item in ObjController.selectedObjList)
        {
            item.gameObject.GetComponent<Rigidbody>().AddForce(force);
        }
    }
}
