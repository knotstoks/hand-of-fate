using UnityEngine;

[CreateAssetMenu]
public class Choice : ScriptableObject
{
    public string choiceName;
    public Requirement requirement;
    public Result result;
}
