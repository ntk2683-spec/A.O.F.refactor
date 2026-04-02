using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Skill ", menuName="Stats/SkillData")]
public class SkillDataSO : ScriptableObject
{
    [Header("Thông tin cơ bản")]
    public string skillName;
    public float cooldown;
    public float manaCost;
    [Header("Thông số kỹ thuật")]
    public float damage;
    public float range;
    public float speed; // Dùng cho Projectile hoặc Dash
    public GameObject vfxPrefab; // Hiệu ứng hình ảnh
    [Header("Danh sách hành động")]
    [Tooltip("Kỹ năng này sẽ thực hiện những hành động nào? (Lướt, Bắn, Nổ...)")]
    public List<SkillAction> actions;
    public void Use(GameObject user, Vector3 targetPos)
    {
        if (actions == null || actions.Count == 0) return;

        foreach (var action in actions)
        {
            action.Execute(user, targetPos, this);
        }
    }
}