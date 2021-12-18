using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AirFishLab.ScrollingList;

public class SelectAndRemove : MonoBehaviour
{
    [SerializeField]
    private CircularScrollingList _list;

    public void GetSelectedContentID(int selectedContentID)
    {
        
        Debug.Log(_list.listBank.GetListContent(selectedContentID));
        Debug.Log("Selected content ID: " + selectedContentID);
    }
}
