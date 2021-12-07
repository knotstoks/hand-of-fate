using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    //5 resources for Money, crewmate, favour, supplies, idol 
    public static int[] resourcesIn = new int[5];
    // TODO: Implement Drag and Drop Feature

    private void Start() // TODO: May want to change this depending on how many resources they want to start with
    { 
        for (int i = 0; i < 5; i++)
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
        /*
        List<Requirement> choices;
        for(int i = 0; i < 3; i++) { 
            int idolRequired = 0;
            for(int j = 0; j < 4; i++) {
                int surplus = choices[i].resourcesNeeded[j] - PlayArea.resourcesIn[j];
                if(surplus > 0) {
                    idolRequired += surplus;
                }
            }
            if(PlayArea.resourcesIn[4] >= idolRequired) {
                //UI light up the selected choice
            }
        }
        */
 
        Debug.Log("tets");
    }

    private void ResolveChoice()
    {

    }
}
