using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [Header("Prefabs for Resource Cards")]
    public List<ResourceCard> resourceCards;
    public int[] hand = new int[6]; // Money, Crewmate, Favour, Supplies, Idol, Omen

    public void ResolveChoice(Choice choice)
    {
        // Destroy choice requirement
        Requirement requirement = choice.requirement;

        int idolRequired = 0;
        for (int i = 0; i < 5; i++)
        {
            int surplus = requirement.resourcesNeeded[i] - hand[i];
            if (surplus > 0)
            {
                idolRequired += surplus;
                hand[i] = 0;
            } else
            {
                hand[i] -= requirement.resourcesNeeded[i];
            }
        }

        hand[5] -= idolRequired;
        // TODO: Animation for adding resources

        //Give choice result
        Result result = choice.result;

        for (int i = 0; i < 6; i++)
        {
            //animation stuff
            hand[i] += result.resourcesGiven[i];
        }
        // TODO: Animation for removing resources
    }
}
