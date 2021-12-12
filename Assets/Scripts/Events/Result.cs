using System.Collections.Generic;

[System.Serializable]
public class Result
{
    public bool isCardToAddPresent;
    public List<Event> cardsToAdd;
    public int[] resourcesGiven = new int[6];
    // Money, Crewmate, Favour, Supplies, Omen, Idol
    // [2, 0, 0, 0, 0, 0] Gives 2 Money
    // [0, 1, 1, 0, 0, 0] Gives 1 Crewmate, 1 Favour

    // Communicating with Hand
}
