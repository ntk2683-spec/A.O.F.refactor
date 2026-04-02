using UnityEngine;
public class Enemy1 : EnemyBase
{
    [SerializeField] private float attackRange = 1.2f;
    protected override void Update()
    {
        base.Update();
        Attack();
    }
    public override void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Vector2.Distance(transform.position, player.transform.position) <= attackRange)
            {
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }
}