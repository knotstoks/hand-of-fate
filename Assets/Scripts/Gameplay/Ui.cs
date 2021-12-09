using UnityEngine;

public class Ui : MonoBehaviour
{
    private void Start()
    {
        Deck.ShowEvent += ShowEvent;
        Deck.FlipEvent += FlipEvent;
        Deck.UiShuffleDeck += ShuffleDeck;
        Deck.UiSelectedChoice += SelectedChoice;
        Deck.PlaceInEvent += PlaceInCard;
    }

    private void ShowEvent(Event eventToShow)
    {

    }

    private void FlipEvent(Event eventToFlip)
    {

    }

    private void ShuffleDeck()
    {

    }
    
    private void SelectedChoice()
    {

    }

    private void PlaceInCard()
    {

    }
}
