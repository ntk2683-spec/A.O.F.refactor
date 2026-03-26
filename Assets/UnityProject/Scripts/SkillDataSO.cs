using UnityEngine;
public enum SkillType { Dash, Shield, RadialShot }
[CreateAssetMenu(menuName="Stats/SkillData")]
public class SkillDataSO : ScriptableObject
{
    public string skillName;
    public Sprite icon;
    public SkillType type;
    public float cooldown;
    public GameObject skillPrefab; // Prefab hiệu ứng/đạn nếu cần
}