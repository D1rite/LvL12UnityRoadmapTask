using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class SaveOptionData : MonoBehaviour
{
    public Slider[] optionSliders;
    public void Save()
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
