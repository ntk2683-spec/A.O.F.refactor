// CharacterStatSO.cs
using UnityEngine;
[CreateAssetMenu(menuName="Stats/CharacterStat")]
public class CharacterStatSO : ScriptableObject
{
    public string characterName;
    public float maxHP;
    public float maxMP;
    public float ATK;
    public float DEF;
    public float SPD;
    public float attackCooldown; // thời gian chờ giữa hai đòn đánh cơ bản
}