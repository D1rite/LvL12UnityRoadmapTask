using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour {
    // Save game Data.
	public void SaveGameData()
    {
        // Is no objects, then dont save the game.
        if (ObjController.allObjList.Count == 0)
            return;
        if (!Directory.Exists((Application.persistentDataPath + "/SaveFiles")))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveFiles");
        }
        if (!Directory.Exists((Application.persistentDataPath + "/SaveFiles/Data")))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveFiles/Data");
        }

        string customName = CaptureScreenshot.scName = GenerateNameForSS();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveFiles/Data/" + customName + ".dat");
        ObjData data = new ObjData();
        foreach (var obj in ObjController.allObjList)
        {
            data.pos.x = obj.transform.position.x;
            data.pos.y = obj.transform.position.y;
            data.pos.z = obj.transform.position.z;
            data.rot.x = obj.transform.eulerAngles.x;
            data.rot.y = obj.transform.eulerAngles.y;
            data.rot.z = obj.transform.eulerAngles.z;
            data.scale.x = obj.transform.localScale.x;
            data.scale.y = obj.transform.localScale.y;
            data.scale.z = obj.transform.localScale.z;
            data.color.r = obj.GetComponent<Renderer>().material.GetColor("_Color").r;
            data.color.g = obj.GetComponent<Renderer>().material.GetColor("_Color").g;
            data.color.b = obj.GetComponent<Renderer>().material.GetColor("_Color").b;
            data.color.a = obj.GetComponent<Renderer>().material.GetColor("_Color").a;
            CaptureScreenshot.m_screenShotLock = true;
            CaptureScreenshot.scName = customName;
            codeName = "";
            bf.Serialize(file, data);
        }
        file.Close();
    }

    public void Save(GameObject thisButton)
    {

        if (!Directory.Exists((Application.persistentDataPath + "/SaveFiles")))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveFiles");
        }
        if (!Directory.Exists((Application.persistentDataPath + "/SaveFiles/Data")))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveFiles/Data");
        }
        File.Delete(Application.persistentDataPath + "/SaveFiles/Data/" + thisButton.name + ".dat");
        File.Delete(Application.persistentDataPath + "/SaveFiles/ScreenShots" + thisButton.name);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveFiles/Data/" + thisButton.name + ".dat");
        ObjData data = new ObjData();
        foreach (var obj in ObjController.allObjList)
        {
            data.pos.x = obj.transform.position.x;
            data.pos.y = obj.transform.position.y;
            data.pos.z = obj.transform.position.z;
            data.rot.x = obj.transform.eulerAngles.x;
            data.rot.y = obj.transform.eulerAngles.y;
            data.rot.z = obj.transform.eulerAngles.z;
            data.scale.x = obj.transform.localScale.x;
            data.scale.y = obj.transform.localScale.y;
            data.scale.z = obj.transform.localScale.z;
            data.color.r = obj.GetComponent<Renderer>().material.GetColor("_Color").r;
            data.color.g = obj.GetComponent<Renderer>().material.GetColor("_Color").g;
            data.color.b = obj.GetComponent<Renderer>().material.GetColor("_Color").b;
            data.color.a = obj.GetComponent<Renderer>().material.GetColor("_Color").a;
            CaptureScreenshot.m_screenShotLock = true;
            CaptureScreenshot.scName = thisButton.name;
            codeName = "";
            bf.Serialize(file, data);
        }
        file.Close();
    }

    const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";
    string codeName;
    string GenerateNameForSS()
    {
        for (int i = 0; i < 10; i++)
        {
            codeName += glyphs[Random.Range(0, glyphs.Length)];
        }
        return codeName;
    }

    public void DeleteSave(GameObject thisButton)
    {
        File.Delete(Application.persistentDataPath + "/SaveFiles/Data/" + thisButton.name + ".dat");
        string[] files = Directory.GetFiles(Application.persistentDataPath + "/SaveFiles/ScreenShots/" + thisButton.name);
        string[] directories = Directory.GetDirectories(Application.persistentDataPath + "/SaveFiles/ScreenShots/" + thisButton.name);
        foreach (string item in files)
        {
            File.Delete(item);
        }
        foreach (string item in directories)
        {
            Directory.Delete(item);
        }
        Directory.Delete(Application.persistentDataPath + "/SaveFiles/ScreenShots/" + thisButton.name);
    }

    public void ReloadButtons(GameObject thisButton)
    {
        thisButton.transform.parent.GetComponent<LoadScrollViewFiller>().FillUpScrollView();
    }
    public void ReloadButtons(Transform thisGameObject)
    {
        thisGameObject.GetComponent<LoadScrollViewFiller>().FillUpScrollView();
    }

    // Save option Data
    public Slider[] optionSliders;
    public void SaveOptionData()
    {
        if (!Directory.Exists((Application.persistentDataPath + "/SaveFiles/Options")))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveFiles/Options");
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveFiles/Options/SavedOptionData.dat");
        optionData data = new optionData();
        foreach (Slider obj in optionSliders)
        {
            data.Volume = obj.GetComponent<Slider>().value;
            bf.Serialize(file, data);
        }
        file.Close();
    }
}
