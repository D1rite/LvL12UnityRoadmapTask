using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
public class LoadOptionData : MonoBehaviour {

    public AudioSource[] audioSources;

    void Awake()
    {
        Load();
    }

        public void Load()
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
