using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ChoiceArea : MonoBehaviour
{
    public int index;
    public ChoiceManager choiceManager;
    private void OnMouseDown()
    {
        if (choiceManager.isActive)
        {
            choiceManager.GetChoiceInput(index);
        }
    }
}
