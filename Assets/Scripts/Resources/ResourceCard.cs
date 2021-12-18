using UnityEngine;

public class ResourceCard : MonoBehaviour
{
    public Resource type;
    public int handIndex;
    private Vector3 dragOffset;
    private Camera sceneCamera;
    private GameObject playArea;
    private Hand hand;
    private BoxCollider2D selfCollider;
    private void Awake()
    {
        selfCollider = GetComponent<BoxCollider2D>();

        sceneCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playArea = GameObject.FindGameObjectWithTag("PlayArea");
        hand = GameObject.FindGameObjectWithTag("Hand").GetComponent<Hand>();
        PositionCard();
    }

    private void OnMouseDown()
    {
        dragOffset = transform.position - GetMousePosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePosition() + dragOffset;
        transform.localEulerAngles = new Vector3(0f, 0f, 0f);
    }

    private void OnMouseUpAsButton()
    {
        if (playArea.GetComponent<BoxCollider2D>().bounds.Intersects(selfCollider.bounds))
        {
            playArea.GetComponent<PlayArea>().AddResources(type);
            hand.RemoveResource(handIndex, type);
            Destroy(gameObject);
        }

        transform.position = hand.ReturnPosition(handIndex);
        PositionCard();
    }

    private void PositionCard()
    {
        float totalTwist = 40f;
        int numberOfCards = hand.resourceCards.Count;
        float twistPerCard = totalTwist / numberOfCards;
        float startTwist = (totalTwist / 2f);
        float twistForThisCard = startTwist - ((handIndex + 0.5f) * twistPerCard);
        transform.Rotate(0f, 0f, twistForThisCard);
        float scalingFactor = 0.025f;
        float nudgeThisCard = Mathf.Abs(twistForThisCard) * scalingFactor;
        transform.Translate(0f, -nudgeThisCard, 0f);
    }

    private Vector3 GetMousePosition()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
