using UnityEngine;

public class Ui : MonoBehaviour
{
    private void Start()
    {
        Deck.ShowEvent += ShowEvent;
    }

    private void ShowEvent(Event eventToShow)
    {

    }
}
