using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    //5 resources for Money, crewmate, favour, supplies, idol 
    public static int[] resourcesIn = new int[5];
    // TODO: Implement Drag and Drop Feature

    private void Start()
    { 
        for(int i = 0; i < 5; i++)
        {
            resourcesIn[i] = 0;
        }
    }

    /*
    Static Method to add resources
    */
    public static void AddResources(Resource resourceToAdd)
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
            case Resource.Idol:
                PlayArea.resourcesIn[4]++;
                break;
        }
        /* checks the three events
        int idolRequired = 0;
        for(int i = 0; i<4; i++) {
            int surplus = choice.Requirement.resourcesNeeded[i] - PlayArea.resourcesIn[i];
            if(surplus > 0) {
                idolRequired += surplus;
            }
        }
        if(PlayArea.resourcesIn[4] >= idolRequired) {
            //UI light up the selected choice
        }
        //repeat for the three events
        */
        Debug.Log("tets");
    }

    private void ResolveChoice()
    {

    }
}
