using System.Collections.Generic;

[System.Serializable]
public class Result
{
    public bool isCardToAddPresent;
    public List<Event> cardsToAdd;
    public int[] resourcesGiven = new int[6];
}
