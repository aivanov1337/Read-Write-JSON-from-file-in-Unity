using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System;

[Serializable]
public class Character
{
    public string Name;
    public float Strength;
    public float Intelligence;
    public float Agility;
    public float Armor;
    public float Critical;
    public List<string> items = new List<string>();    
}
