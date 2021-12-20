using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public bool open; // Checks to see if player has triggered the treasure chest already

    private void Start()
    {
        open = false;
    }

    private void OnMouseDown()
    {

    }
}
