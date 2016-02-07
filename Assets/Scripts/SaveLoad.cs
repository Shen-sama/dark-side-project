using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class SaveLoad : MonoBehaviour {
    Global script;

    void Start()
    {
        script = FindObjectOfType(typeof(Global)) as Global;

    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.nome = script.npc[0].nome;
        data.falasPersonagem = script.npc[0].falasPersonagem;
        bf.Serialize(file, data);
        file.Close();

    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            script.npc[0].nome  = data.nome;         
            script.npc[0].falasPersonagem =   data.falasPersonagem;
          
        }
    }
}

[Serializable]
class PlayerData
{
    public string nome;
    public string[] falasPersonagem;
}