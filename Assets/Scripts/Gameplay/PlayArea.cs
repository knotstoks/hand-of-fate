using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    //6 resources for Money, crewmate, favour, supplies, omen, idol 
    public static int[] resourcesIn = new int[6];
    public Hand hand;
    [HideInInspector] List<Requirement> requirements = new List<Requirement>();
    public List<ChoiceArea> choiceArea;
    public List<GameObject> resourceCards;
    public List<Sprite> numbers;
    // TODO: Implement Drag and Drop Feature

    private void Start() // TODO: May want to change this depending on how many resources they want to start with
    {
        requirements = new List<Requirement>(3);
        for (int i = 0; i < 6; i++)
        {
            resourcesIn[i] = 0;
        }
    }

    public void UpdateEvent(Event newEvent) 
    {
        requirements.Clear();
        requirements.Add(newEvent.firstChoice.requirement);
        requirements.Add(newEvent.secondChoice.requirement);
        requirements.Add(newEvent.thirdChoice.requirement);
    }
    
    /*
    Static Method to add resources
    */
    
    //Checks the current number of resources inside the playarea to determine the sprite
    private void checkStatus(int index)
    {
        if(resourcesIn[index] == 0)
        {
            resourceCards[index].SetActive(false);
        } 
        else
        {
            resourceCards[index].SetActive(true);
            resourceCards[index].GetComponent<ResourceCardNumber>().Replace(numbers[resourcesIn[index] - 1]);
        }
    }

    public void AddResources(Resource resourceToAdd)
    {
        switch (resourceToAdd)
        {
            case Resource.Money:
                PlayArea.resourcesIn[0]++;
                checkStatus(0);
                break;
            case Resource.Crewmate:
                PlayArea.resourcesIn[1]++;
                checkStatus(1);
                break;
            case Resource.Favour:
                PlayArea.resourcesIn[2]++;
                checkStatus(2);
                break;
            case Resource.Supplies:
                PlayArea.resourcesIn[3]++;
                checkStatus(3);
                break;
            case Resource.Omen:
                PlayArea.resourcesIn[4]++;
                checkStatus(4);
                break;
            case Resource.Idol:
                PlayArea.resourcesIn[5]++;
                checkStatus(5);
                break;
        }


        /*
        if(choices[0] == null)
        {
            return;
        }
        for(int i = 0; i < 3; i++) { 
            int idolRequired = 0;
            for(int j = 0; j < 5; i++) {
                int surplus = choices[i].resourcesNeeded[j] - PlayArea.resourcesIn[j];
                if(surplus > 0) {
                    idolRequired += surplus;
                }
            }
            if(PlayArea.resourcesIn[5] >= idolRequired) {
                choiceArea[i].choiceManager.EnableChoices();
                //UI light up the selected choice
            }
        }
        */
    }

    public void RemoveResource(Resource type)
    {
        switch (type)
        {
            case Resource.Money:
                PlayArea.resourcesIn[0]--;
                checkStatus(0);
                break;
            case Resource.Crewmate:
                PlayArea.resourcesIn[1]--;
                checkStatus(1);
                break;
            case Resource.Favour:
                PlayArea.resourcesIn[2]--;
                checkStatus(2);
                break;
            case Resource.Supplies:
                PlayArea.resourcesIn[3]--;
                checkStatus(3);
                break;
            case Resource.Omen:
                PlayArea.resourcesIn[4]--;
                checkStatus(4);
                break;
            case Resource.Idol:
                PlayArea.resourcesIn[5]--;
                checkStatus(5);
                break;
        }
        /*
        if (choices[0] == null)
        {
            return;
        }
        for (int i = 0; i < 3; i++)
        {
            int idolRequired = 0;
            for (int j = 0; j < 5; i++)
            {
                int surplus = choices[i].resourcesNeeded[j] - PlayArea.resourcesIn[j];
                if (surplus > 0)
                {
                    idolRequired += surplus;
                }
            }
            if (PlayArea.resourcesIn[5] < idolRequired)
            {
                choiceArea[i].choiceManager.DisableChoices();
                //UI light up the selected choice
            }
        }
        */
    }

    public void ResolveChoice(int choiceNumber)
    {
        choiceNumber = choiceNumber - 1; // Make the index -1 to deal with array numbering
        int idolRequired = 0;
        for (int i = 0; i < 5; i++)
        {
            int difference = resourcesIn[i] - requirements[choiceNumber].resourcesNeeded[i];
            if (difference > 0)
            {
                for (int j = 0; j < difference; j++)
                {
                    hand.AddResources(i);
                }
            } 
            else if (difference < 0)
            {
                idolRequired -= difference;
            }
            resourcesIn[i] = 0;
            checkStatus(i);
        }

        int idolDifference = resourcesIn[5] - requirements[choiceNumber].resourcesNeeded[5];
        if (idolDifference > 0)
        {
            for (int j = 0; j < idolDifference; j++)
            {
                hand.AddResources(5);
            }
        }

        resourcesIn[5] = 0;
        checkStatus(5);
    }
}
