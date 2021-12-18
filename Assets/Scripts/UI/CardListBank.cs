using AirFishLab.ScrollingList;
using UnityEngine;
using UnityEngine.UI;

public class CardListBank : BaseListBank
{
    [SerializeField]
    private Image[] _contents;

    public override object GetListContent(int index)
    {
        return _contents[index];
    }

    public override int GetListLength()
    {
        return _contents.Length;
    }

    public void GetSelectedContentID(int selectedContentID)
    {
        
        //Debug.Log(_contents[selectedContentID]);
        _contents = RemoveIndices(_contents, selectedContentID);
    }

    private Image[] RemoveIndices(Image[] IndicesArray, int RemoveAt)
    {
        Image[] newIndicesArray = new Image[IndicesArray.Length - 1];

        int i = 0;
        int j = 0;
        while (i < IndicesArray.Length)
        {
            if (i != RemoveAt)
            {
                newIndicesArray[j] = IndicesArray[i];
                j++;
            }

            i++;
        }

        return newIndicesArray;
    }
}
