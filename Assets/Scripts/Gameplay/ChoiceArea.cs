using UnityEngine;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))]
public class ChoiceArea : MonoBehaviour
{
    public int index; // 1, 2 or 3
    public ChoiceManager choiceManager;
    public TMP_Text choiceDesc;
    public TMP_Text resultDesc;
    private void OnMouseDown()
    {
        if (choiceManager.isActive)
        {
            choiceManager.GetChoiceInput(index);
        }
    }
}
