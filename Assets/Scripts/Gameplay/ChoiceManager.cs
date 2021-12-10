using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    public Manager manager;
    public PlayArea playArea;
    public bool isActive;
    public GameObject[] choiceAreaObjects;
    public ChoiceArea[] choiceAreas = new ChoiceArea[3];

    public void Start()
    {
        // Disable the Choice Areas
        for (int i = 0; i < choiceAreas.Length; i++)
        {
            choiceAreaObjects[i].SetActive(false);
        }
    }
    public void EnableChoices()
    {
        isActive = true;

        for (int i = 0; i < choiceAreas.Length; i++)
        {
            choiceAreaObjects[i].SetActive(true);
        }
    }

    public void DisableChoices()
    {
        isActive = false;

        for (int i = 0; i < choiceAreas.Length; i++)
        {
            choiceAreaObjects[i].SetActive(false);
        }
    }

    public void GetChoiceInput(int index)
    {
        // TODO: Check to see if area has required resources
        playArea.ResolveChoice(index);
        manager.SelectChoice(index);

        DisableChoices();
    }

    public void UpdateVisuals(Event eventShown)
    {
        ChoiceArea firstChoiceArea = choiceAreas[0];
        ChoiceArea secondChoiceArea = choiceAreas[1];
        ChoiceArea thirdChoiceArea = choiceAreas[2];

        int numberOfChoices = eventShown.numberOfChoices;

        // Update texts
        firstChoiceArea.choiceDesc.text = eventShown.firstChoice.choiceDescription;
        firstChoiceArea.resultDesc.text = eventShown.firstChoice.additionalText;
        
        secondChoiceArea.choiceDesc.text = eventShown.secondChoice.choiceDescription;
        secondChoiceArea.resultDesc.text = eventShown.secondChoice.additionalText;

        thirdChoiceArea.choiceDesc.text = eventShown.thirdChoice.choiceDescription;
        thirdChoiceArea.resultDesc.text = eventShown.thirdChoice.additionalText;
        
        // TODO: Update Resources needed
    }
}
