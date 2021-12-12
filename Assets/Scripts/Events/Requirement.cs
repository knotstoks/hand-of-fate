[System.Serializable]
public class Requirement
{
    public int[] resourcesNeeded = new int[6];
    // Money, Crewmate, Favour, Supplies, Omen, Idol
    // [2, 0, 0, 0, 0, 0] Need 2 Money
    // [0, 1, 1, 0, 0, 0] Need 1 Crewmate, 1 Favour

    // Communicating with PlayArea
}
