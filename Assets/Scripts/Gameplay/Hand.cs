using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [Header("Prefabs for Resource Cards")]
    public List<ResourceCard> resourceCards;
    public Resource[] hand = new Resource[15];
    
    private void Start()
    {
        Deck.AddResources += AddResources;
    }

    /*
    Adds resources to the Player's Hand
    */
    private void AddResources(List<Resource> resources) // TODO
    {

        // TODO: Animation for adding resources
    }
}
