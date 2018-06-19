using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderHighlight : MonoBehaviour {

    public MeshRenderer mR;

    private void OnMouseEnter()
    {
        mR.enabled = true;
    }

    private void OnMouseExit()
    {
        if (ObjController.selectedObjList.Contains(gameObject))
            return;
        mR.enabled = false;

    }
}
