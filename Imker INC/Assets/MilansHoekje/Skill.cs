using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill")]
public class Skill : ScriptableObject 
{
    public enum SkillType
    {
        Speed,
        Coin,
        Experience 
    }

    public SkillType Type;

    public int amount;

}
