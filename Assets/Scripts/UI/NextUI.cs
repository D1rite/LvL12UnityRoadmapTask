using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextUI : MonoBehaviour {
    public GameObject nextUI;
	
    public void OnButtonPress()
    {
        nextUI.SetActive(true);
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }
}
