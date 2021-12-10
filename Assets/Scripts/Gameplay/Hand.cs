using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [Header("Prefabs for Resource Cards")]
    public List<GameObject> resourceCards;
    public int[] hand = new int[6]; // Money, Crewmate, Favour, Supplies, Idol, Omen
    public List<Transform> positions;
    public List<GameObject> existingResourceCards;
    public int occupied;
    public void ResolveChoice(Choice choice)
    {
        // Destroy choice requirement
        Requirement requirement = choice.requirement;
        // TODO: Animation for adding resources

        //Give choice result
        Result result = choice.result;

        for (int i = 0; i < 6; i++)
        {
            //animation stuff
            for(int j = 0; j < result.resourcesGiven[i]; j++)
            {
                AddResources(i);
            }
            
        }
        // TODO: Animation for removing resources
    }

    public void AddResources(Resource type)
    {
        int index = 0;
        switch (type)
        {
            case Resource.Money:
                index = 0;
                break;
            case Resource.Crewmate:
                index = 1;
                break;
            case Resource.Favour:
                index = 2;
                break;
            case Resource.Supplies:
                index = 3;
                break;
            case Resource.Omen:
                index = 4;
                break;
            case Resource.Idol:
                index = 5;
                break;
        }

        hand[index]++;
        occupied++;
        GameObject newCard = GameObject.Instantiate(resourceCards[index], positions[occupied].position, Quaternion.identity, this.transform);
        newCard.GetComponent<ResourceCard>().type = type;
        newCard.GetComponent<ResourceCard>().handIndex = occupied;
        existingResourceCards.Add(newCard);
    }

    public void AddResources(int index)
    {
        hand[index]++;
        occupied++;
        GameObject newCard = GameObject.Instantiate(resourceCards[index], positions[occupied].position, Quaternion.identity, this.transform);
        Resource type = Resource.Money;
        switch(index)
        {
            case 0:
                type = Resource.Money;
                break;
            case 1:
                type = Resource.Crewmate;
                break;
            case 2:
                type = Resource.Favour;
                break;
            case 3:
                type = Resource.Supplies;
                break;
            case 4:
                type = Resource.Omen;
                break;
            case 5:
                type = Resource.Idol;
                break;
        }
        newCard.GetComponent<ResourceCard>().type = type;
        newCard.GetComponent<ResourceCard>().handIndex = occupied;
        existingResourceCards.Add(newCard);
    }

    public Vector3 ReturnPosition(int index) 
    { 
        return positions[index].position;
    }

    public void RemoveResource(int index, Resource type)
    {
        for(int i = index; i < occupied; i++)
        {
            existingResourceCards[i + 1].GetComponent<Transform>().position = positions[i].position;
            existingResourceCards[i + 1].GetComponent<ResourceCard>().handIndex--;
            existingResourceCards[i] = existingResourceCards[i + 1];
        }
        existingResourceCards.RemoveAt(occupied);
        occupied--;

        switch (type)
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
            case Resource.Omen:
                hand[4]--;
                break;
            case Resource.Idol:
                hand[5]--;
                break;
        }
    }

}
