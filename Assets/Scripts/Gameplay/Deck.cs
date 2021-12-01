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
    private void Start()
    {
        Manager.GenerateDeck += GenerateDeck;
        Manager.ReshuffleDeck += ReshuffleDeck;
        Manager.DrawCard += DrawCard;
    }

    private void GenerateDeck()
    {

    }

    private void ReshuffleDeck()
    {
        Deck.DeckNotReady(); // Stop inputs by player just in case

    }
    
    public void DrawCard()
    {
        Deck.DeckNotReady(); // Stop inputs by player

        // TODO: Animation of putting the card in Discard Pile

        

        Deck.DeckReady(); // Continue playing the game
    }

    public void ResolveEvent(int choiceTaken)
    {
        int index = choiceTaken - 1;
        List<Choice> choices = eventShown.eventData.choices;
        
        // Check if there is no choice at that slot and do nothing
        if (choices.Count < index)
        {
            return;
        }

        
    }
}
