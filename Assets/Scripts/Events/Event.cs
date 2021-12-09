using UnityEngine;

[CreateAssetMenu]
public class Event : ScriptableObject
{
    public bool throwSameCardBack;
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
