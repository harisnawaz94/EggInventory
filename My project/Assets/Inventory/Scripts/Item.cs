using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Item/Create Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int values;
    public Sprite icon;


}
