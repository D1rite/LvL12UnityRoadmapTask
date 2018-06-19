using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersiteantData : MonoBehaviour {

    //This only centains Data between scenes.

    //Load DAta
    [HideInInspector]
    public bool loadGame = false;
    [HideInInspector]
    public string loadGameName = "";
}
