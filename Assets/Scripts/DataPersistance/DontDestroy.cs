using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static GameObject gameManager;

    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }

        if (this.gameObject != gameManager)
            Destroy(this.gameObject);
    }

}
