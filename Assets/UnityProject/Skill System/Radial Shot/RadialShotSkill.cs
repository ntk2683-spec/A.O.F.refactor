using UnityEngine;
[CreateAssetMenu(fileName = "RadialShotSkill", menuName = "SkillData/RadialShot")]
public class RadialShotSkill : SkillDataSO
{
    [SerializeField] private int bulletCount = 12;
    public override void Execute(GameObject user, Vector3 targetPos, SkillDataSO data)
    {
        if (data == null || data.Prefab == null) return;
        
        CastRadialShot(user, data);
    } 
    private void CastRadialShot(GameObject user, SkillDataSO data)
    {

    }
}