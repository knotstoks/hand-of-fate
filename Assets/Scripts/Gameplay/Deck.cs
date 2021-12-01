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
    public static event DeckEvent DeckReady;
    public static event DeckEvent DeckNotReady;
    public delegate void PlayerEvent(List<Resource> resources);
    public static event PlayerEvent AddResources;
    private void Start()
    {
        Manager.GenerateDeck += GenerateDeck;
        Manager.ReshuffleDeck += ReshuffleDeck;
        Manager.DrawCard += DrawCard;
        Manager.ChooseChoice += ResolveEvent;
    }

    private void GenerateDeck() // TODO
    {

    }

    private void ReshuffleDeck() // TODO
    {
        Deck.DeckNotReady(); // Stop inputs by player just in case
        

        Deck.DeckReady(); // Allow inputs by player
    }
    
    public void DrawCard() // TODO
    {
        Deck.DeckNotReady(); // Stop inputs by player just in case

        

        

        Deck.DeckReady(); // Continue playing the game
    }

    public void ResolveEvent(int choiceTaken)
    {
        Deck.DeckNotReady();
        int index = choiceTaken - 1;
        // Check if there is no choice at that slot and if so do nothing
        if (eventShown.eventData.numberOfChoices < index)
        {
            return;
        }

        discardPile.Add(eventShown);
        eventShown = null; // Clear the current event
        // TODO: Animation of card going off screen

        if (drawPile.Count == 0)
        {
            ReshuffleDeck();
            // TODO: Reshuffle Deck animation
        }
        else
        {
            DrawCard();
        }
    }

    public void GivePlayer(Result result)
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
}
