using UnityEngine;

public class ResourceCard : MonoBehaviour
{
    public Resource type;
    private Vector3 dragOffset;
    private Camera sceneCamera;
    private GameObject playArea;
    private BoxCollider2D selfCollider;
    private void Awake()
    {
        selfCollider = GetComponent<BoxCollider2D>();

        sceneCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playArea = GameObject.FindGameObjectWithTag("PlayArea");
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
        if(playArea.GetComponent<BoxCollider2D>().bounds.Intersects(selfCollider.bounds))
        {
            playArea.GetComponent<PlayArea>().AddResources(type);
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
