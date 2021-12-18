using AirFishLab.ScrollingList;
using UnityEngine;
using UnityEngine.UI;

public class CardListBox : ListBox
{
    [SerializeField]
    private Image _contentImage;
    

    protected override void UpdateDisplayContent(object content)
    {

        _contentImage = (Image) content;
    }

    public void RemoveCard()
    {
        Destroy(this);
        //Debug.Log(this);
    }
}