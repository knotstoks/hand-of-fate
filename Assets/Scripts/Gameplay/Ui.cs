using UnityEngine;

public class Ui : MonoBehaviour
{
    public ChoiceManager choiceManager;
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
        // TODO: Animation of drawing
    }

    private void FlipEvent(Event eventToFlip)
    {
        // TODO: Animation of Flipping

        // Update the display of texts and resources needed and given
        choiceManager.UpdateVisuals(eventToFlip);
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
