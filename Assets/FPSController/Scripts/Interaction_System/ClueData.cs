using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClueData", menuName = "ScriptableObjects/ClueData", order = 1)]
public class ClueData : ScriptableObject
{
    public string clueName;
    public string clueDescription;
    public Texture clueImage;
    public GameObject cluePrefab;
    public ClueType clueType;
}

public enum ClueType
{
    Item,
    Memory
}
