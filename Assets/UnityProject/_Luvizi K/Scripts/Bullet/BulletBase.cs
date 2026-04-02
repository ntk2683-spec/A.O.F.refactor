using UnityEngine;
public class BulletBase : MonoBehaviour
{
    [Header("Bullet Stats")]
    [SerializeField] protected float moveSpeed = 25f;
    [SerializeField] protected float maxRange = 10f;
    protected Vector2 direction;
    [SerializeField] protected int damage;
    protected GameObject shooter;
    protected Vector3 startPosition;
    public virtual void Init(Vector2 dir, int dmg, GameObject shooterObj)
    {
        direction = dir.normalized;
        damage = dmg;
        shooter = shooterObj;
        startPosition = transform.position;
    }
    protected virtual void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        float currentDistance = Vector2.Distance(transform.position, startPosition);
        if (currentDistance >= maxRange)
        {
            Destroy(gameObject);
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == shooter) return;
        PlayerBase player = collision.GetComponent<PlayerBase>();
        EnemyBase enemy = collision.GetComponent<EnemyBase>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}