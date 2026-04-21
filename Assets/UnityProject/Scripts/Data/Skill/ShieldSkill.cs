using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "ShieldSkill", menuName = "SkillData/Shield")]
public class ShieldSkill : SkillDataSO
{
    public override void Execute(GameObject user, Vector3 targetPos, SkillDataSO data)
    {
        if (data == null) return;
        Vector3 spawnPosition = user.transform.position;
        GameObject shieldInstance = Instantiate(data.Prefab, spawnPosition, Quaternion.identity, user.transform);
        Destroy(shieldInstance, data.cooldown);
    }
}