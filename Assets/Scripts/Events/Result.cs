using System.Collections.Generic;

[System.Serializable]
public class Result
{
    public bool isCardToAddPresent;
    public Event cardToAdd;
    public int[] resourcesGiven = new int[6];
}
