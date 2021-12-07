using UnityEngine;

public class Manager : MonoBehaviour
{
    public Event eventOnDisplay;
    public bool canDrawCard; // State where the card is shown face down
    public bool canFlipCard; // State where the card is flipped
    public Deck deck;
    private void Start()
    {
        ChoiceManager.MakeChoice += SelectChoice;
        canDrawCard = false;
        canFlipCard = false;

        // Generate and shuffle the deck
        deck.GenerateDeck();

        // Game can start now
        canDrawCard = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDrawCard)
        {
            deck.DrawCard();
        } 
        else if (Input.GetKeyDown(KeyCode.Space) && canFlipCard)
        {
            // TODO: Flips open the card and reveals choices
            deck.FlipCard();
        }
    }

    public void SelectChoice(int choice) // TODO
    {
        // TODO: Check to see if area has required resources
        deck.ResolveEvent(choice);
    }

    public void AllowDrawing()
    {
        canDrawCard = true;
    }

    public void StopDrawing()
    {
        canDrawCard = false;
    }

    public void AllowFlipping()
    {
        canFlipCard = true;
    }

    public void StopFlipping()
    {
        canFlipCard = false;
    }
}
