using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [HideInInspector] public Event eventOnDisplay;
    public bool canDrawCard; // State where the card is shown face down
    public bool canFlipCard; // State where the card is flipped
    public Deck deck;
    public Image readyImage; // Green for can draw, blue for cna flip, black for disabled
    private void Start()
    {
        canDrawCard = false;
        canFlipCard = false;

        // Generate and shuffle the deck
        deck.GenerateDeck();

        // Game can start now
        AllowDrawing();
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

    public void SelectChoice(int choice)
    {
        deck.ResolveEvent(choice);
    }

    public void AllowDrawing()
    {
        canDrawCard = true;
        readyImage.color = Color.green;
    }

    public void StopDrawing()
    {
        canDrawCard = false;
        readyImage.color = Color.blue;
    }

    public void AllowFlipping()
    {
        canFlipCard = true;
    }

    public void StopFlipping()
    {
        canFlipCard = false;
        readyImage.color = Color.black;
    }
}
