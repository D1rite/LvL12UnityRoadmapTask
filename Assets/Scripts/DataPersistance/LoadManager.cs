using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour {

    public void Awake()
    {
        LoadOptionData();
        if (!Directory.Exists(Application.persistentDataPath + "/SaveFiles"))
        {
            return;
        }
        if (GameObject.Find("PersistantGameData").GetComponent<PersiteantData>().loadGame == true)
        {
            LoadGameData(GameObject.Find("PersistantGameData").GetComponent<PersiteantData>().loadGameName);
        }
    }

    public void LoadGameData(string id)
    {
        //Delete all current objects
        foreach (GameObject obj in ObjController.allObjList)
        {
            Destroy(obj);
        }
        ObjController.selectedObjList.Clear();
        ObjController.selectedObjList = new List<GameObject>();
        ObjController.allObjList.Clear();
        ObjController.allObjList = new List<GameObject>();

        // Start Load
        if (File.Exists(Application.persistentDataPath + "/SaveFiles/Data/" + id + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveFiles/Data/" + id + ".dat", FileMode.Open);
            List<ObjData> objList = new List<ObjData>();
            while (file.Position != file.Length)
            {
                ObjData data = (ObjData)bf.Deserialize(file);
                objList.Add(data);
            }
            file.Close();

            foreach (ObjData obj in objList)
            {
                GameObject inGameObj = GameObject.Instantiate(GetComponent<SpawnObject>().spanableObject) as GameObject;
                inGameObj.transform.position = new Vector3(obj.pos.x, obj.pos.y, obj.pos.z);
                inGameObj.transform.rotation = Quaternion.Euler(obj.rot.x, obj.rot.y, obj.rot.z);
                inGameObj.transform.localScale = new Vector3(obj.scale.x, obj.scale.y, obj.scale.z);
                inGameObj.GetComponent<Renderer>().material.SetColor("_Color", new Color(obj.color.r, obj.color.g, obj.color.b, obj.color.a));
                ObjController.allObjList.Add(inGameObj);
            }
        }
        else
            Debug.LogError("No save with such ID");

        GameObject.Find("PersistantGameData").GetComponent<PersiteantData>().loadGame = false;
    }



    public AudioSource[] audioSources;

    public void LoadOptionData()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveFiles/Options/SavedOptionData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveFiles/Options/SavedOptionData.dat", FileMode.Open);
            List<optionData> objList = new List<optionData>();
            while (file.Position != file.Length)
            {
                optionData data = (optionData)bf.Deserialize(file);
                objList.Add(data);
            }
            file.Close();
            int i = 0;
            foreach (optionData obj in objList)
            {
                Debug.Log(obj.Volume);
                audioSources[i].volume = obj.Volume;
                i++;
            }
        }
    }
}
