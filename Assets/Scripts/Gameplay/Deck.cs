using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Queue<Event> drawPile;
    public List<Event> discardPile;
}
