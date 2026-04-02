using UnityEngine;
public abstract class SkillAction : ScriptableObject
{
    // Phương thức này sẽ được gọi khi Skill được kích hoạt
    // user: Đối tượng tung chiêu
    // targetPos: Vị trí mục tiêu (nếu có)
    // data: Truyền ngược SkillData vào để lấy các chỉ số (Damage, Speed...)
    public abstract void Execute(GameObject user, Vector3 targetPos, SkillDataSO data);
}