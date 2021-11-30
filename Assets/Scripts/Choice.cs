using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Choice : ScriptableObject
{
    public string choiceName;
    public List<Resource> requirement;
}
