using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite ItemIcon;
    [Range(1, 100)]public int maxStackSize = 100;
}