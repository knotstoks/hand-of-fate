using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    public Manager manager;
    public PlayArea playArea;
    public bool isActive;
    public GameObject[] choiceAreas;

    public void Start()
    {
        // Disable the Choice Areas
        for (int i = 0; i < choiceAreas.Length; i++)
        {
            choiceAreas[i].SetActive(false);
        }
    }
    public void EnableChoices()
    {
        isActive = true;

        for (int i = 0; i < choiceAreas.Length; i++)
        {
            choiceAreas[i].SetActive(true);
        }
    }

    public void DisableChoices()
    {
        isActive = false;

        for (int i = 0; i < choiceAreas.Length; i++)
        {
            choiceAreas[i].SetActive(false);
        }
    }

    public void GetChoiceInput(int index)
    {
        DisableChoices();
        playArea.ResolveChoice(index);
        manager.SelectChoice(index);
    }
}
