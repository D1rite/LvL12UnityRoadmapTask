using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUIMenu : MonoBehaviour {

    public GameObject toMenu;
	public void ChangeMenu()
    {
        toMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
