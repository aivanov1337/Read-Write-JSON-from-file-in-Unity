using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLoader : MonoBehaviour
{
    public Text textbox;

    [Header("Character Loader")]

    public string file = "characters.json";    

    public string path;


    public List<Character> charDb = new List<Character>();

    [Header("Character Builder")]
    public CharacterBuilder characterBuilder;


    public void Awake()
    {
        TextAsset characters = Resources.Load<TextAsset>("characters");
        Debug.Log(characters);

        path = Application.persistentDataPath + "/" + file;

        textbox.text = path;
        //foreach(Character n in charDb)
        //{
        //    Debug.Log(n.Agility);
        //}
        //Debug.Log(JsonUtility.ToJson(this));
        //Save();

        Load();

        var newChar = new Character() { Strength = 15, items = { "iron_helmet1", "iron_chest1" } };
        charDb.Add(newChar);
        Save();

        //SpawnCharacter(charDb[1]);
        //SpawnItem(charDb[1]);
        characterBuilder.SpawnCharacter(charDb[0]);
    }

    public void Start()
    {
        //textbox.text = file + " |||| " + path + "||||" + charDb[1].Strength +"||||" + Application.dataPath.ToString();
    }

    private void Load()
    {
        try
        {
            string json = ReadFromFile(path);
            JsonUtility.FromJsonOverwrite(json, this);
        }

        catch(IOException)
        {
            File.Create(path);
            Load();
        }

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
