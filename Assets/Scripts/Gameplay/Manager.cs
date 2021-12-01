using UnityEngine;

public class Manager : MonoBehaviour
{
    public Event eventOnDisplay;
    public bool canDrawCard; // State where the card is shown face down
    public bool canFlipCard; // State where the card is flipped
    public delegate void GameEvent();
    public static event GameEvent GenerateDeck;
    public static event GameEvent DrawCard;
    public static event GameEvent FlipCard;
    public delegate void IndexEvent(int index);
    public static event IndexEvent ChooseChoice;
    private void Start()
    {
        Deck.DrawReady += AllowDrawing;
        Deck.DrawNotReady += StopDrawing;
        Deck.ChoiceReady += AllowFlipping;
        Deck.ChoiceNotReady += StopFlipping;

        ChoiceManager.MakeChoice += SelectChoice;
        canDrawCard = false;
        canFlipCard = false;

        // Generate and shuffle the deck
        GenerateDeck();

        // Game can start now
        canDrawCard = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDrawCard)
        {
            DrawCard();
        } 
        else if (Input.GetKeyDown(KeyCode.Space) && canFlipCard)
        {
            // TODO: Flips open the card and reveals choices
            FlipCard();
        }
    }

    public void SelectChoice(int choice) // TODO
    {
        // TODO: Check to see if area has required resources
        ChooseChoice(choice);
    }

    private void AllowDrawing()
    {
        canDrawCard = true;
    }

    private void StopDrawing()
    {
        canDrawCard = false;
    }

    private void AllowFlipping()
    {
        canFlipCard = true;
    }

    private void StopFlipping()
    {
        canFlipCard = false;
    }
}
