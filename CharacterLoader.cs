using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    private string path;
    public List<Character> charDb = new List<Character>();
    private string file = "characters.json";

    public void Start()
    {    
        path = Application.dataPath + "/" + file;        
        Load();
    }

    private void Load()
    {        
        string json = ReadFromFile(path);
        JsonUtility.FromJsonOverwrite(json,this);
    }

    private void Save()
    {
        string json = JsonUtility.ToJson(this);
        WriteToFile(path, json);
    }

    private void WriteToFile(string path, string json)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string ReadFromFile(string path)
    {
        using (StreamReader reader = new StreamReader(path))
        {
            string json = reader.ReadToEnd();
            return json;
        }
    }

}
