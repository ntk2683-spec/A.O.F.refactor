using UnityEngine;
public class UltiBullet : BulletBase
{
    [SerializeField] private float knockbackForce = 10f;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == shooter) return;
        base.OnTriggerEnter2D(collision);
        EnemyBase enemy = collision.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                Vector2 knockbackDir = (enemy.transform.position - transform.position).normalized;
                enemyRb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }
}