using System.Collections;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    public GameObject cardBack;
    private bool isCardBackActive;
    private float x = 0, y = 1, z = 0;
    private int timer;
    private SpriteRenderer spriteRenderer;
    public float delay;
    public Transform offScreenPosition;
    public Transform onScreenPosition;
    private bool moveIn;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveIn = false;
        Deck.FlipEvent += StartFlip;
        Deck.DrawEvent += DrawCardUi;
        isCardBackActive = false;
    }

    // Moving the card on screen
    private void Update()
    {
        if (moveIn)
        {
            transform.position = Vector2.MoveTowards(transform.position, onScreenPosition.position, 10 * Time.deltaTime);
        }
    }

    public void DrawCardUi(Event currEvent)
    {
        StartCoroutine(MoveDeckUi());
    }

    private IEnumerator MoveDeckUi()
    {
        moveIn = true;
        Debug.Log("test");
        yield return new WaitForSeconds(delay);
        moveIn = false;
        Debug.Log("end");
    }

    public void StartFlip(Event currEvent)
    {
        spriteRenderer.sprite = currEvent.cardImage;
        StartCoroutine(CalculateFlip());
    }

    private void Flip()
    {
        if (isCardBackActive)
        {
            cardBack.SetActive(false);
            isCardBackActive = false;
        }
        else
        {
            cardBack.SetActive(true);
            isCardBackActive = true;
        }
    }

    private IEnumerator CalculateFlip()
    {
        for (int i = 0; i< 180; i++)
        {
            yield return new WaitForSeconds(0.001f);
            transform.Rotate(new Vector3(x, y ,z));
            timer++;

            if (timer == 90 || timer == -90)
            {
                Flip();
            }
        }
    }
}
