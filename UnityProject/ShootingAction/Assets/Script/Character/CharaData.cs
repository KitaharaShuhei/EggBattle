using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharaData
{ 
    public int Id;
    public string Name;
    public int Speed;
    public int Attack;

    public void _CharaData()
    {
        Id = 0;
        Name = "";
        Speed = 0;
        Attack = 0;
    }
}
