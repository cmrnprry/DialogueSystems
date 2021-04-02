using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Dialogue //This is a struct. Please do not be afraid
{
    public string name;
    [TextArea(3, 5)]
    public string words;
}
public class TwoWayText : MonoBehaviour
{
    //An array of structs
    public Dialogue[] dialogue;
}
