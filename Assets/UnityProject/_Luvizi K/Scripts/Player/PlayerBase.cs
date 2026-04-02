using UnityEngine;
public class PlayerBase : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int maxHP = 100;
    [SerializeField] private int maxMP = 50;
    [SerializeField] private int attack = 10;
    [SerializeField] private int defense = 5;
    [SerializeField] private float speed = 3f;
    public int CurrentHP { get; private set; }
    public int CurrentMP { get; private set; }
    public int ATK => attack;
    public int DEF => defense;
    public float SPD => speed;
    protected virtual void Awake()
    {
        CurrentHP = maxHP;
        CurrentMP = maxMP;
    }
    public virtual void TakeDamage(int damage)
    {
        int finalDamage = Mathf.Max(damage - DEF, 1);
        CurrentHP -= finalDamage;
        CurrentHP = Mathf.Max(CurrentHP, 0);
        if (CurrentHP <= 0)
        {
            Die();
        }
    }
    // public virtual void RestoreHP(int amount)
    // {
    //     CurrentHP += amount;
    //     CurrentHP = Mathf.Min(CurrentHP, maxHP);
    // }
    // public virtual void RestoreMP(int amount)
    // {
    //     CurrentMP += amount;
    //     CurrentMP = Mathf.Min(CurrentMP, maxMP);
    // }
    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} đã chết!");
    }
    // public void AddStat(string stat, int amount)
    // {
    //     switch (stat.ToUpper())
    //     {
    //         case "HP":
    //             maxHP += amount;
    //             break;
    //         case "MP":
    //             maxMP += amount;
    //             break;
    //         case "ATK":
    //             attack += amount;
    //             break;
    //         case "DEF":
    //             defense += amount;
    //             break;
    //         case "SPD":
    //             speed += amount;
    //             break;
    //         default:
    //             Debug.LogWarning("Stat không tồn tại: " + stat);
    //             break;
    //     }
    // }
}