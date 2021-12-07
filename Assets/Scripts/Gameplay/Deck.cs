using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [Header("Number of Events")]
    public int numberOfPostiveEvents;
    public int numberOfNegativeEvents;
    public int numberOfNeutralEvents;
    [Space(20)]
    [Header("Events")]
    public List<Event> positiveEvents;
    public List<Event> negativeEvents;
    public List<Event> neutralEvents;
    public List<Event> sagas;
    [HideInInspector] public Event eventShown;
    [HideInInspector] public Queue<Event> drawPile;
    [HideInInspector] public List<Event> discardPile;
    public Manager manager;
    public PlayArea playArea;
    public Hand hand;
    public delegate void UiEvent(Event eventToDisplay);
    public static event UiEvent ShowEvent;
    public static event UiEvent FlipEvent;
    public static event UiEvent PlaceInEvent;
    public delegate void UiDiplay();
    public static event UiDiplay UiShuffleDeck;
    public static event UiDiplay UiSelectedChoice;

    public void GenerateDeck()
    {
        // TODO: Select number of cards from the piles and add it to the discard pile

        ReshuffleDeck();
    }

    public void ReshuffleDeck()
    {
        manager.StopDrawing(); // Stop inputs by player just in case
        manager.StopFlipping();

        ShuffleDiscardPile();
        for (int i = 0; i < discardPile.Count; i++)
        {
            drawPile.Enqueue(discardPile[i]);
        }
        discardPile.Clear();

        manager.AllowDrawing(); // Allow inputs by player
        manager.AllowDrawing();
    }
    
    public void DrawCard()
    {
        manager.StopDrawing(); // Stop drawing input by player
        manager.StopFlipping();

        Event currEvent = drawPile.Dequeue();
        eventShown = currEvent;

        // Animation of drawing card
        ShowEvent(currEvent);
    }

    public void FlipCard()
    {
        manager.StopFlipping();
        FlipEvent(eventShown);
    }

    public void ResolveEvent(int choiceTaken)
    {
        int index = choiceTaken - 1;
        // Check if there is no choice at that slot and if so do nothing
        if (eventShown.eventData.numberOfChoices < index)
        {
            return;
        }

        // Get the choice made
        Choice choice = null;
        switch (index)
        {
            case 0:
            choice = eventShown.eventData.firstChoice;
            break;
            case 1:
            choice = eventShown.eventData.secondChoice;
            break;
            case 2:
            choice = eventShown.eventData.thirdChoice;
            break;
        }

        Result result = choice.result;

        hand.ResolveChoice(choice); // Change resources in hand

        // TODO: Animation of putting it in

        if (result.isCardToAddPresent) // Put in the card in the discard pile if it exists
        {
            discardPile.Add(result.cardToAdd);
            PlaceInEvent(result.cardToAdd);
        }

        discardPile.Add(eventShown); // Discard the card
        eventShown = null; // Clear the current event

        // TODO: Clear resources from Play Area

        if (drawPile.Count == 0)
        {
            ReshuffleDeck();
            UiShuffleDeck();
        }

        UiSelectedChoice();
    }

    /*
    TODO: Static method to move the resource back to hand if resource goes out of bounds
    */
    public static void ReturnResource()
    {
        
    }

    /*
    Method to quickly shuffle list
    */
    private void ShuffleDiscardPile() {
        var count = discardPile.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i) {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = discardPile[i];
            discardPile[i] = discardPile[r];
            discardPile[r] = tmp;
        }
    }
}
