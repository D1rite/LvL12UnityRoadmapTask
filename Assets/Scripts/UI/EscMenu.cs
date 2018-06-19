using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{

    public GameObject escMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escMenu.activeSelf)
                escMenu.SetActive(false);
            else escMenu.SetActive(true);
        }

    }
}
