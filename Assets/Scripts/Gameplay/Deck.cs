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
    public delegate void DeckEvent();
    public static event DeckEvent DrawReady;
    public static event DeckEvent DrawNotReady;
    public static event DeckEvent ChoiceReady;
    public static event DeckEvent ChoiceNotReady;
    public delegate void PlayerEvent(List<Resource> resources);
    public static event PlayerEvent AddResources;
    public delegate void UiEvent(Event eventToDisplay);
    public static event UiEvent ShowEvent;

    private void Start()
    {
        Manager.GenerateDeck += GenerateDeck;
        Manager.ReshuffleDeck += ReshuffleDeck;
        Manager.DrawCard += DrawCard;
        Manager.ChooseChoice += ResolveEvent;
    }

    private void GenerateDeck()
    {
        // TODO: Select number of cards from the piles and add it to the discard pile

        ReshuffleDeck();
    }

    private void ReshuffleDeck()
    {
        Deck.DrawNotReady(); // Stop inputs by player just in case

        ShuffleDiscardPile();
        for (int i = 0; i < discardPile.Count; i++)
        {
            drawPile.Enqueue(discardPile[i]);
        }
        discardPile.Clear();

        Deck.DrawReady(); // Allow inputs by player
    }
    
    public void DrawCard() // TODO
    {
        Deck.DrawNotReady(); // Stop drawing input by player

        // TODO: Animation of drawing card

        Event currEvent = drawPile.Dequeue();
        eventShown = currEvent;
        ShowEvent(currEvent);
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
            case 1:
            choice = eventShown.eventData.firstChoice;
            break;
            case 2:
            choice = eventShown.eventData.secondChoice;
            break;
            case 3:
            choice = eventShown.eventData.thirdChoice;
            break;
        }

        if (drawPile.Count == 0)
        {
            ReshuffleDeck();
            // TODO: Reshuffle Deck animation
        }
        else
        {
            GivePlayer(choice.result);
        }

        discardPile.Add(eventShown); // Discard the card
        eventShown = null; // Clear the current event

        // TODO: Animation of card going off screen
    }

    private void GivePlayer(Result result)
    {
        // Give the resources to the Player
        AddResources(result.resourcesGiven);
        // TODO: Animation for the resources given

        // Check if there is a card to shuffle in
        if (result.isCardToAddPresent)
        {
            discardPile.Add(result.cardToAdd);
            // TODO: Animation for the shuffling of the card
        }
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
