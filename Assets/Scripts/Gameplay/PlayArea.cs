using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    //6 resources for Money, crewmate, favour, supplies, omen, idol 
    public static int[] resourcesIn = new int[6];
    [HideInInspector] List<Requirement> choices;
    public List<ChoiceArea> choiceArea;
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
    public void AddResources(Resource resourceToAdd)
    {
        switch (resourceToAdd)
        {
            case Resource.Money:
                PlayArea.resourcesIn[0]++;
                break;
            case Resource.Crewmate:
                PlayArea.resourcesIn[1]++;
                break;
            case Resource.Favour:
                PlayArea.resourcesIn[2]++;
                break;
            case Resource.Supplies:
                PlayArea.resourcesIn[3]++;
                break;
            case Resource.Omen:
                PlayArea.resourcesIn[4]++;
                break;
            case Resource.Idol:
                PlayArea.resourcesIn[5]++;
                break;
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
        
 
        Debug.Log("tets");
    }

    private void ResolveChoice()
    {

    }
}
