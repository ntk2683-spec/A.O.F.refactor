using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Character ", menuName="Stats/CharacterData")]
public class CharacterDataSO : ScriptableObject
{
    [Header("Info")]
    public string characterName;
    [Header("Visual")]
    public Sprite sprite;
    public RuntimeAnimatorController animator;
    [Header("Stats")]
    public List<StatValue> stats;
    //[Header("Combat")]
    //public AttackData attackData;
}