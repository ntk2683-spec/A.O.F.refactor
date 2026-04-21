using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Vector2 movement;
    private Vector2 lastNonZeroMovement = Vector2.right;
    private bool isAttacking = false;
    [Header("Input")]
    public Joystick joystick;
    [Header("Scriptable Object")]
    public CharacterDataSO characterData;
    public SkillDataSO[] skillsData;
    [Header("Stats")]
    [SerializeField] private float currentHP;
    [SerializeField] private float currentMP;
    [SerializeField] private float currentATK;
    [SerializeField] private float currentDEF;
    [SerializeField] private float currentSPD;
    [SerializeField] private float currentAttackCooldown;
    private bool isDashing = false;
    public void SetDashing(bool value)
    {
        isDashing = value;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Init();
    }
    public void Init()
    {
        characterData = GameManager.Instance.selectedCharacter;
        skillsData = GameManager.Instance.selectedSkills;
        spriteRenderer.sprite = characterData.sprite;
        animator.runtimeAnimatorController = characterData.animator;
        RefreshStatsDisplay();
    }
    private void RefreshStatsDisplay()
    {
        currentHP = HP;
        currentMP = MP;
        currentATK = ATK;
        currentDEF = DEF;
        currentSPD = SPD;
        currentAttackCooldown = AttackCooldown;
    }
    public float HP => GetStatValue(StatType.maxHP);
    public float MP => GetStatValue(StatType.maxMP);
    public float ATK => GetStatValue(StatType.ATK);
    public float DEF => GetStatValue(StatType.DEF);
    public float SPD => GetStatValue(StatType.SPD);
    public float AttackCooldown => GetStatValue(StatType.attackCooldown);
    private float GetStatValue(StatType statType)
    {
        if (characterData == null || characterData.stats == null)
        {
            return 0;
        }
        foreach (var stat in characterData.stats)
        {
            if (stat.type == statType)
                return stat.value;
        }
        return 0;
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        if (isDashing) return; // 🔥 CHẶN Ở ĐÂY
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;
        movement = new Vector2(moveHorizontal, moveVertical).normalized;
        rb.MovePosition(rb.position + movement * SPD * Time.fixedDeltaTime);
        if (!isAttacking && movement != Vector2.zero)
        {
            FaceDirection(movement);
            lastNonZeroMovement = movement;
        }
        animator.SetBool("isRun", movement != Vector2.zero);
    }
    public Vector2 GetLastNonZeroMovement()
    {
        return lastNonZeroMovement;
    }
    public void FaceDirection(Vector2 dir)
    {
        if (dir.x < 0)
            spriteRenderer.flipX = true;
        else if (dir.x > 0)
            spriteRenderer.flipX = false;
    }
    public void FaceTarget(Vector3 targetPos)
    {
        Vector2 dir = targetPos - transform.position;
        FaceDirection(dir);
    }
}