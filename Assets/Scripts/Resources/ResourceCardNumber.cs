using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCardNumber : MonoBehaviour
{
    public SpriteRenderer image;

    public void Replace(Sprite image)
    {
        this.image.sprite = image;
    }
}
