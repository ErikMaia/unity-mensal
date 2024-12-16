using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "Scriptable Objects/PlayerScriptableObject")]
public class PlayerScriptableObject : ScriptableObject
{
    public int dias;
    public Vector3 position;
    public float value;
}
