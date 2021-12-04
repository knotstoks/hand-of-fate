using UnityEngine;

public class ResourceCard : MonoBehaviour
{
    public Resource type;
    private Vector3 dragOffset;
    private Camera sceneCamera;
    private BoxCollider2D playArea;
    private BoxCollider2D selfCollider;
    private void Awake()
    {
        selfCollider = GetComponent<BoxCollider2D>();

        sceneCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playArea = GameObject.FindGameObjectWithTag("PlayArea").GetComponent<BoxCollider2D>();
    }

    private void OnMouseDown()
    {
        dragOffset = transform.position - GetMousePosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePosition() + dragOffset;
    }

    private void OnMouseUpAsButton()
    {
        if(playArea.bounds.Intersects(selfCollider.bounds))
        {
            PlayArea.AddResources(type);
            Destroy(gameObject);
        }

        //Deck.ReturnResource(type);
        Destroy(gameObject);
    }

    private Vector3 GetMousePosition()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
