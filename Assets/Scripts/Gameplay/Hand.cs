using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [Header("Prefabs for Resource Cards")]
    public List<ResourceCard> resourceCards;
    public int[] hand = new int[6]; // Money, Crewmate, Favour, Supplies, Idol, Omen
    
    private void Start()
    {
        Deck.ChoiceChosen += ResolveChoice;
    }

    private void ResolveChoice(Choice choice)
    {
        // Destroy choice requirement
        Requirement requirement = choice.requirement;
        
        foreach (Resource resource in requirement.resourcesNeeded) 
        {
            switch (resource)
            {
            case Resource.Money:
            hand[0]--;
            break;
            case Resource.Crewmate:
            hand[1]--;
            break;
            case Resource.Favour:
            hand[2]--;
            break;
            case Resource.Supplies:
            hand[3]--;
            break;
            case Resource.Idol:
            hand[4]--;
            break;
            case Resource.Omen:
            hand[5]--;
            break;
            }
        }
        // TODO: Animation for adding resources

        //Give choice result
        Result result = choice.result;

        foreach (Resource resource in result.resourcesGiven) 
        {
            switch (resource)
            {
            case Resource.Money:
            hand[0]++;
            break;
            case Resource.Crewmate:
            hand[1]++;
            break;
            case Resource.Favour:
            hand[2]++;
            break;
            case Resource.Supplies:
            hand[3]++;
            break;
            case Resource.Idol:
            hand[4]++;
            break;
            case Resource.Omen:
            hand[5]++;
            break;
            }
        }
        // TODO: Animation for removing resources
    }
}
