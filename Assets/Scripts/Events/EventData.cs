using UnityEngine;

[CreateAssetMenu]
public class EventData : ScriptableObject
{
    public string cardName;
    public Sprite cardImage;
    public int numberOfChoices;
    public Choice firstChoice;
    public Choice secondChoice;
    public Choice thirdChoice;
}
