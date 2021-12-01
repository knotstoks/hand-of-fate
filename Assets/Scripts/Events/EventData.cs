using UnityEngine;

[CreateAssetMenu]
public class EventData : ScriptableObject
{
    public string cardName;
    public Sprite cardImage;
    [Space(20)]
    public int numberOfChoices;
    [Space(20)]
    public Choice firstChoice;
    [Space(20)]
    public Choice secondChoice;
    [Space(20)]
    public Choice thirdChoice;
}
