using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    //6 resources for Money, crewmate, favour, supplies, omen, idol 
    public static int[] resourcesIn = new int[6];
    [HideInInspector] List<Requirement> choices;
    public List<ChoiceArea> choiceArea;
    public List<GameObject> resourceCards;
    public List<Sprite> numbers;
    // TODO: Implement Drag and Drop Feature

    private void Start() // TODO: May want to change this depending on how many resources they want to start with
    { 
        for (int i = 0; i < 6; i++)
        {
            resourcesIn[i] = 0;
        }

        choices = new List<Requirement>();
    }

    public void UpdateEvent(Event newEvent) 
    {
        choices[0] = newEvent.eventData.firstChoice.requirement;
        choices[1] = newEvent.eventData.secondChoice.requirement;
        choices[2] = newEvent.eventData.thirdChoice.requirement;
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
        } else
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

    private void ResolveChoice()
    {

    }
}
