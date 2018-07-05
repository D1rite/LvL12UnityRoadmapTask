using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour {
    public string scenename;
	// Use this for initialization
	public void StartScene()
    {
        SceneManager.LoadScene(scenename);
    }
}
