using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    public bool isActive;
    public delegate void ClickEvent(int index);
    public static event ClickEvent MakeChoice;

    public void Start()
    {

    }

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
        MakeChoice(index);
    }
}
