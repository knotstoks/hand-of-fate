using UnityEngine;

public class Manager : MonoBehaviour
{
    public Event eventOnDisplay;
    public bool isGameReady; // Boolean to control any action in the game
    public bool isCardShown;
    public delegate void GameEvent();
    public static event GameEvent GenerateDeck;
    public static event GameEvent ReshuffleDeck;
    public static event GameEvent DrawCard;
    public delegate void IndexEvent(int index);
    public static event IndexEvent ChooseChoice;
    public delegate void PromptEvent();
    public static event PromptEvent WrongResources;
    private void Start()
    {
        Deck.DeckReady += AllowInputs;
        Deck.DeckNotReady += StopInputs;
        ChoiceManager.MakeChoice += SelectChoice;
        isGameReady = false;
        isCardShown = false;

        // TODO: Generate and shuffle the deck


        // TODO: Add deck to the draw pile
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGameReady)
        {
            DrawCard();
        }
    }

    public void SelectChoice(int choice)
    {
        // TODO: Check to see if area has required resources
        ChooseChoice(choice);
    }

    private void AllowInputs()
    {
        isGameReady = true;
    }

    private void StopInputs()
    {
        isGameReady = false;
    }
}
