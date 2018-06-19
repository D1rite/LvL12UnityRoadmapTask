using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObjects : MonoBehaviour
{
    public AudioController aC;
    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        //Add Object to selectable obj List
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        // If hit box, show outline.

        if (Input.GetMouseButtonDown(0) && hit.collider != null && hit.collider.tag == "Player")
        {
            if (ObjController.selectedObjList.Contains(hit.collider.gameObject))
            {
                return;
            }
            else
            {
                ObjController.selectedObjList.Add(hit.collider.gameObject);
                aC.PlayClip(0);
            }
        }

        //Add Object to selectable obj List
        else if (Input.GetMouseButtonDown(1) && hit.collider != null && hit.collider.tag == "Player")
        {
            if (ObjController.selectedObjList.Contains(hit.collider.gameObject))
            {
                ObjController.selectedObjList.Remove(hit.collider.gameObject);
                aC.PlayClip(0);
            }
            else
            {
                return;
            }
        }
    }
}
