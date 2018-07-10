using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class LoadScrollViewFiller : MonoBehaviour
{

    public GameObject button;
    public void FillUpScrollView()
    {
        StartCoroutine(DoIt());
    }

    IEnumerator DoIt()
       {
        yield return new WaitForEndOfFrame();
        if (!Directory.Exists((Application.persistentDataPath + "/SaveFiles")))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveFiles");
        }
        if (!Directory.Exists((Application.persistentDataPath + "/SaveFiles/Data")))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveFiles/Data");
        }
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath + "/SaveFiles/Data");
        FileInfo[] info = dir.GetFiles();
        foreach (FileInfo currentFile in info)
        {
            GameObject btn = Instantiate(button);
            string screenshotName = Path.GetFileNameWithoutExtension(Application.persistentDataPath + "/SaveFiles/ScreenShots" + currentFile);
            StartCoroutine(load_image(screenshotName, btn));
        }
        Debug.Log(info.Length);
        if (info.Length > 2)
        {
            gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0, -100 * (info.Length - 2));
            gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        }
        else
        {
            gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        }
        Debug.Log(new Vector2(0, -100 * info.Length));
    }


    IEnumerator load_image( string ssName, GameObject btn)
    {
        if (Directory.Exists(Application.persistentDataPath + "/SaveFiles/ScreenShots"))
        {
#if !UNITY_EDITOR 
            ssName = ssName.Remove(ssName.IndexOf("ScreenShots"), "ScreenShots".Length);
#endif
            yield return new WaitForSeconds(0.1f);
            btn.transform.SetParent(gameObject.transform);
            btn.name = ssName;
            WWW www = new WWW("file://" + Application.persistentDataPath + "/SaveFiles/ScreenShots/" + ssName + "/" + ssName + ".png");
            yield return www;
            Texture2D new_texture = new Texture2D(1, 1);
            www.LoadImageIntoTexture(new_texture);
            Sprite newSprite = Sprite.Create(new_texture, new Rect(0, 0, new_texture.width, new_texture.height), new Vector2(0, 0));
            if(btn != null)
            btn.transform.GetChild(0).GetComponent<Image>().sprite = newSprite;
            yield break;
        }
    }
}
