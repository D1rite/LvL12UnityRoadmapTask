using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpLoadButtons : MonoBehaviour {
    Image image;
	// Use this for initialization
	void Start () {
        foreach (string file in System.IO.Directory.GetFiles(Application.persistentDataPath + "/SaveFiles/Data"))
        {
            Debug.Log(file);
                }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
