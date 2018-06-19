using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize
{

    public void ChangeSelectedObjSize(Vector3 size)
    {
        foreach (GameObject item in ObjController.selectedObjList)
        {
            item.gameObject.transform.localScale += size;
        }
    }
}
