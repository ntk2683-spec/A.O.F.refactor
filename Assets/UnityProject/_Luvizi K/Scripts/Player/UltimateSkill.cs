using UnityEngine;
public class UltimateSkill : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePos;
    [SerializeField] private int bulletCount = 12;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float cooldown = 5f;
    private float nextCastTime = 0f;
    public void ActivateUltimate()
    {
        if (Time.time < nextCastTime)
        {
            return;
        }
        CastUltimate();
        nextCastTime = Time.time + cooldown;
    }
    private void CastUltimate()
    {
        float angleStep = 360f / bulletCount;
        float angle = 0f;

        for (int i = 0; i < bulletCount; i++)
        {
            float dirX = Mathf.Cos(angle * Mathf.Deg2Rad);
            float dirY = Mathf.Sin(angle * Mathf.Deg2Rad);
            Vector2 dir = new Vector2(dirX, dirY).normalized;
            Quaternion rot = Quaternion.Euler(0, 0, angle);
            GameObject bullet = Instantiate(bulletPrefab, firePos.position, rot);
            BulletBase bulletScript = bullet.GetComponent<BulletBase>();
            if (bulletScript != null)
            {
                int ultiDamage = 50;
                bulletScript.Init(dir, ultiDamage, gameObject);
            }
            angle += angleStep;
        }
    }
    public float GetCooldownRemaining()
    {
        return Mathf.Max(0f, nextCastTime - Time.time);
    }
}