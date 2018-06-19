using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor
{

    public void ChangeSelectedObjColor(Color color)
    {
        foreach (GameObject item in ObjController.selectedObjList)
        {
            item.GetComponent<Renderer>().material.SetColor("_Color", color);
        }
    }

}
