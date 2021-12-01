using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EventData : ScriptableObject
{
    public string cardName;
    public Sprite cardImage;
    [Range(1, 3)]
    public List<Choice> choices;
}
