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
        float angleStep = 360f / bulletCount;
        float angle = 0f; 
        for (int i = 0; i < bulletCount; i++)
        {
            float dirX = Mathf.Cos(angle * Mathf.Deg2Rad);
            float dirY = Mathf.Sin(angle * Mathf.Deg2Rad);
            Vector2 dir = new Vector2(dirX, dirY).normalized;
            Quaternion rot = Quaternion.Euler(0, 0, angle);
            GameObject bullet = Instantiate(data.Prefab, user.transform.position, rot);
            BulletBase bulletScript = bullet.GetComponent<BulletBase>();
            if (bulletScript != null)
            {
                bulletScript.Init(dir, (int)data.damage, user);
            } 
            angle += angleStep;
        }
    }
}