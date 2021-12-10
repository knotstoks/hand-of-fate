using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCardNumber : MonoBehaviour
{
    public SpriteRenderer image;
    public Resource type;
    private Vector3 originalPosition;
    private Vector3 dragOffset;
    private Camera sceneCamera;
    private GameObject hand;
    private PlayArea playArea;
    private BoxCollider2D selfCollider;
    private void Awake()
    {
        selfCollider = GetComponent<BoxCollider2D>();

        sceneCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        hand = GameObject.FindGameObjectWithTag("Hand");
        playArea = GameObject.FindGameObjectWithTag("PlayArea").GetComponent<PlayArea>();
    }

    public void Replace(Sprite image)
    {
        this.image.sprite = image;
    }

    private void OnMouseDown()
    {
        originalPosition = transform.position;
        dragOffset = transform.position - GetMousePosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePosition() + dragOffset;
    }

    private void OnMouseUpAsButton()
    {
        transform.position = originalPosition;
        if (hand.GetComponent<BoxCollider2D>().bounds.Intersects(selfCollider.bounds))
        {
            hand.GetComponent<Hand>().AddResources(type);
            playArea.RemoveResource(type);
        } 
        
                 
    }

    private Vector3 GetMousePosition()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
