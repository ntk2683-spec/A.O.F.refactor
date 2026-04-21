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
    public float speed; // Dùng cho Projectile hoặc Dash
    public GameObject Prefab; // Hiệu ứng hình ảnh
    // [Header("Danh sách hành động")]
    // [Tooltip("Kỹ năng này sẽ thực hiện những hành động nào? (Lướt, Bắn, Nổ...)")]
    // public List<SkillAction> actions;
    public abstract void Execute(GameObject user, Vector3 targetPos, SkillDataSO data);
    // {
    //     // if (actions == null || actions.Count == 0) return;

    //     // foreach (var action in actions)
    //     // {
    //     //     action.Execute(user, targetPos, this);
    //     // }
    // }
}