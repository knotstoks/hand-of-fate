using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    public bool isActive;
    public delegate void ClickEvent(int index);
    public static event ClickEvent MakeChoice;

    public void Start()
    {
        Deck.ChoiceReady += EnableChoices;
        Deck.ChoiceNotReady += DisableChoices;
    }

    private void EnableChoices()
    {
        isActive = true;
    }

    private void DisableChoices()
    {
        isActive = false;
    }

    public void GetChoiceInput(int index)
    {
        MakeChoice(index);
    }
}
