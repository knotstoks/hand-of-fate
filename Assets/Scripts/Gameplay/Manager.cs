using UnityEngine;

public class Manager : MonoBehaviour
{
    public Event eventOnDisplay;
    public bool canDrawCard; // State where the card is shown face down
    public bool canFlipCard; // State where the card is flipped
    public delegate void GameEvent();
    public static event GameEvent GenerateDeck;
    public static event GameEvent ReshuffleDeck;
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

        // TODO: Generate and shuffle the deck


        // TODO: Add deck to the draw pile

        // Game can start now
        canDrawCard = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !canDrawCard)
        {
            DrawCard();
        } 
        else if (Input.GetKeyDown(KeyCode.Space) && !canFlipCard)
        {
            
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
