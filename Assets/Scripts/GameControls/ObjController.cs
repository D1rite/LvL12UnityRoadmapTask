using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjController : MonoBehaviour
{
    public static List<GameObject> selectedObjList = new List<GameObject>();
    public static List<GameObject> allObjList = new List<GameObject>();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Input for changing color
        if (Input.GetKeyDown(KeyCode.R))
            ChangeSelectedObjColor(Color.red);
        if (Input.GetKeyDown(KeyCode.G))
            ChangeSelectedObjColor(Color.green);
        if (Input.GetKeyDown(KeyCode.B))
            ChangeSelectedObjColor(Color.blue);

        //Input for Scaling
        if (Input.GetKeyDown(KeyCode.RightArrow))
            ChangeSelectedObjSize(new Vector3(0.1f, 0, 0.1f));
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ChangeSelectedObjSize(new Vector3(0, 0.1f, 0));
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            ChangeSelectedObjSize(new Vector3(-0.1f, 0, -0.1f));
        if (Input.GetKeyDown(KeyCode.DownArrow))
            ChangeSelectedObjSize(new Vector3(0, -0.1f, 0));

        //Input for changing position
        if (Input.GetKey(KeyCode.W))
            ChangeSelectedObjLocation(new Vector3(50, 0, 0));
        if (Input.GetKey(KeyCode.S))
            ChangeSelectedObjLocation(new Vector3(-50, 0, 0));
        if (Input.GetKey(KeyCode.D))
            ChangeSelectedObjLocation(new Vector3(0, 0, -50));
        if (Input.GetKey(KeyCode.A))
            ChangeSelectedObjLocation(new Vector3(0, 0, 50));
    }

    public void ChangeSelectedObjSize(Vector3 size)
    {
        foreach (GameObject item in ObjController.selectedObjList)
        {
            item.gameObject.transform.localScale += size;
        }
    }

    public void ChangeSelectedObjLocation(Vector3 force)
    {
        foreach (GameObject item in ObjController.selectedObjList)
        {
            item.gameObject.GetComponent<Rigidbody>().AddForce(force);
        }
    }

    public void ChangeSelectedObjColor(Color color)
    {
        foreach (GameObject item in ObjController.selectedObjList)
        {
            item.GetComponent<Renderer>().material.SetColor("_Color", color);
        }
    }
}
