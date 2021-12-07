using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    public Manager manager;
    public bool isActive;

    public void EnableChoices()
    {
        isActive = true;
    }

    public void DisableChoices()
    {
        isActive = false;
    }

    public void GetChoiceInput(int index)
    {
        manager.SelectChoice(index);
    }
}
