using UnityEngine;
using System;
public abstract class EnemyBase : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] protected int maxHP = 100;
    [SerializeField] protected int currentHP;
    [SerializeField] protected int armor = 0;
    [SerializeField] protected float moveSpeed = 2f;
    [SerializeField] protected float attackCooldown = 2f;
    [SerializeField] protected int attackPower = 10;
    protected float nextAttackTime = 0f;
    protected PlayerControl player;
    public Action OnEnemyDeath;
    protected virtual void Start()
    {
        player = FindAnyObjectByType<PlayerControl>();
        currentHP = maxHP;
    }
    protected virtual void Update()
    {
        if (player != null)
        {
            MoveToPlayer();
        }
    }
    protected virtual void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.transform.position,
            moveSpeed * Time.deltaTime
        );
        FlipEnemy();
    }
    protected void FlipEnemy()
    {
        transform.localScale = new Vector3(
            player.transform.position.x < transform.position.x ? -1 : 1,
            1,
            1
        );
    }
    public virtual void TakeDamage(int damage)
    {
        int finalDamage = Mathf.Max(damage - armor, 1);
        currentHP -= finalDamage;
        if (currentHP <= 0)
        {
            Die();
        }
    }
    public abstract void Attack();
    protected virtual void Die()
    {
        OnEnemyDeath?.Invoke();
        Destroy(gameObject);
    }
}