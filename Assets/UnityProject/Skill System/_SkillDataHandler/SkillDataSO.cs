using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Skill ", menuName="Stats/SkillData")]
public abstract class SkillDataSO : ScriptableObject
{
    [Header("Thông tin cơ bản")]
    public string skillName;
    [Header("Thông số kỹ thuật")]
    public float manaCost;
    public float cooldown;
    public float damage;
    public float range;
    public float speed;
    public float duration;
    [Header("Prefab kỹ năng")]
    public GameObject Prefab;
    public abstract void Execute(GameObject user, Vector3 targetPos, SkillDataSO data);
}