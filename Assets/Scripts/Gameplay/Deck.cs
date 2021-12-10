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
    [HideInInspector] public Queue<Event> drawPile = new Queue<Event>();
    [HideInInspector] public List<Event> discardPile;
    public Manager manager;
    public PlayArea playArea;
    public Hand hand;
    public delegate void UiEvent(Event eventToDisplay);
    public static event UiEvent ShowEvent;
    public static event UiEvent FlipEvent;
    public delegate void UiDisplay();
    public static event UiDisplay UiShuffleDeck;
    public static event UiDisplay UiSelectedChoice;
    public static event UiDisplay PlaceInEvent;

    public void GenerateDeck()
    {
        // TODO: Select number of cards from the piles and add it to the discard pile
        // Shuffle and add Positive Events
        var count = positiveEvents.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i) 
        {
            var r = Random.Range(i, count);
            var tmp = positiveEvents[i];
            positiveEvents[i] = positiveEvents[r];
            positiveEvents[r] = tmp;
        }

        for (int i = 0; i < numberOfPostiveEvents; i++)
        {
            discardPile.Add(positiveEvents[i]);
        }

        // Shuffle and add Negative Events
        count = negativeEvents.Count;
        last = count - 1;
        for (var i = 0; i < last; ++i) 
        {
            var r = Random.Range(i, count);
            var tmp = negativeEvents[i];
            negativeEvents[i] = negativeEvents[r];
            negativeEvents[r] = tmp;
        }

        for (int i = 0; i < numberOfNegativeEvents; i++)
        {
            discardPile.Add(negativeEvents[i]);
        }

        // Shuffle and add Neutral Events
        count = neutralEvents.Count;
        last = count - 1;
        for (var i = 0; i < last; ++i) 
        {
            var r = Random.Range(i, count);
            var tmp = neutralEvents[i];
            neutralEvents[i] = neutralEvents[r];
            neutralEvents[r] = tmp;
        }

        for (int i = 0; i < numberOfNeutralEvents; i++)
        {
            discardPile.Add(neutralEvents[i]);
        }

        // Shuffle the Discard Deck
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
        playArea.UpdateEvent(eventShown);

        // Animation of drawing card
        // ShowEvent(currEvent);
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
        if (eventShown.numberOfChoices < index)
        {
            return;
        }

        // Get the choice made
        Choice choice = null;
        switch (index)
        {
            case 0:
            choice = eventShown.firstChoice;
            break;
            case 1:
            choice = eventShown.secondChoice;
            break;
            case 2:
            choice = eventShown.thirdChoice;
            break;
        }

        Result result = choice.result;

        hand.ResolveChoice(choice); // Change resources in hand

        // TODO: Animation of putting it in

        if (result.isCardToAddPresent) // Put in the card in the discard pile if it exists
        {
            int num = Random.Range(0, result.cardsToAdd.Count);
            Event eventToAdd = result.cardsToAdd[num];
            discardPile.Add(eventToAdd);

            PlaceInEvent();
        }

        // Check if you need to return the card back to the deck
        if (eventShown.throwSameCardBack)
        {
            discardPile.Add(eventShown);
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
    Method to quickly shuffle list
    */
    private void ShuffleDiscardPile() 
    {
        var count = discardPile.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i) 
        {
            var r = Random.Range(i, count);
            var tmp = discardPile[i];
            discardPile[i] = discardPile[r];
            discardPile[r] = tmp;
        }
    }
}
