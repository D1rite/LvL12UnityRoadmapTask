using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class onLoadButtonPress : MonoBehaviour {

    public void LoadGameWithNewScene(GameObject button)
    {
        Debug.Log(button.name);
        PersiteantData pD = GameObject.Find("PersistantGameData").GetComponent<PersiteantData>();
        pD.loadGame = true;
        pD.loadGameName = button.name;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
