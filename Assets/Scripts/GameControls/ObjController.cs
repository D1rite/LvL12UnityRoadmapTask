using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjController : MonoBehaviour
{
    public static List<GameObject> selectedObjList = new List<GameObject>();
    public static List<GameObject> allObjList = new List<GameObject>();
    ChangeColor cc = new ChangeColor();
    ChangeLocation cl = new ChangeLocation();
    ChangeSize cs = new ChangeSize();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Input for changing color
        if (Input.GetKeyDown(KeyCode.R))
            cc.ChangeSelectedObjColor(Color.red);
        if (Input.GetKeyDown(KeyCode.G))
            cc.ChangeSelectedObjColor(Color.green);
        if (Input.GetKeyDown(KeyCode.B))
            cc.ChangeSelectedObjColor(Color.blue);

        //Input for Scaling
        if (Input.GetKeyDown(KeyCode.RightArrow))
            cs.ChangeSelectedObjSize(new Vector3(0.1f, 0, 0.1f));
        if (Input.GetKeyDown(KeyCode.UpArrow))
            cs.ChangeSelectedObjSize(new Vector3(0, 0.1f, 0));
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            cs.ChangeSelectedObjSize(new Vector3(-0.1f, 0, -0.1f));
        if (Input.GetKeyDown(KeyCode.DownArrow))
            cs.ChangeSelectedObjSize(new Vector3(0, -0.1f, 0));

        //Input for changing position
        if (Input.GetKey(KeyCode.W))
            cl.ChangeSelectedObjLocation(new Vector3(50, 0, 0));
        if (Input.GetKey(KeyCode.S))
            cl.ChangeSelectedObjLocation(new Vector3(-50, 0, 0));
        if (Input.GetKey(KeyCode.D))
            cl.ChangeSelectedObjLocation(new Vector3(0, 0, -50));
        if (Input.GetKey(KeyCode.A))
            cl.ChangeSelectedObjLocation(new Vector3(0, 0, 50));
    }
}
