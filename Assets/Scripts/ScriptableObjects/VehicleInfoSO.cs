using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Vehicle Info")]
public class VehicleInfoSO : ScriptableObject
{
    public string make;
    public string model;
    public string year;
    public string engine;
    public AudioClip voiceover;
}
