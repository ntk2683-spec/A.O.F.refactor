using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SkillController : MonoBehaviour
{
    [Header("UI Buttons")]
    [SerializeField] private Button[] skillButtons = new Button[3];

    private SkillDataSO[] skills;
    private Dictionary<int, float> skillCooldowns = new Dictionary<int, float>();

    private PlayerController player;

    private void Start()
    {
        player = GetComponent<PlayerController>();

        if (GameManager.Instance != null)
        {
            skills = GameManager.Instance.selectedSkills;
        }

        InitializeUI();
        InitializeCooldowns();
    }

    private void Update()
    {
        UpdateCooldowns();
        UpdateUI();
    }

    // ================= INIT =================

    private void InitializeUI()
    {
        if (skillButtons == null) return;

        for (int i = 0; i < skillButtons.Length; i++)
        {
            int index = i;

            if (skillButtons[i] != null)
            {
                skillButtons[i].onClick.AddListener(() => OnSkillButtonClicked(index));
            }
        }
    }

    private void InitializeCooldowns()
    {
        if (skills == null) return;

        for (int i = 0; i < skills.Length; i++)
        {
            skillCooldowns[i] = 0f;
        }
    }

    // ================= INPUT =================

    public void OnSkillButtonClicked(int index)
    {
        CastSkill(index);
    }

    public void CastSkill(int index)
    {
        // ===== Validate =====
        if (skills == null || index < 0 || index >= skills.Length)
        {
            Debug.LogWarning($"Skill index {index} không hợp lệ!");
            return;
        }

        SkillDataSO skill = skills[index];

        if (skill == null)
        {
            Debug.LogWarning($"Skill tại vị trí {index} chưa được chọn!");
            return;
        }

        if (skillCooldowns[index] > 0)
        {
            Debug.Log($"⏳ {skill.skillName} đang cooldown: {skillCooldowns[index]:F1}s");
            return;
        }

        // ===== Lấy hướng từ Player =====
        Vector2 inputDir = Vector2.zero;

        if (player != null)
        {
            inputDir = new Vector2(player.joystick.Horizontal, player.joystick.Vertical);

            if (inputDir == Vector2.zero)
            {
                inputDir = player.GetLastNonZeroMovement();
            }
        }

        // ===== Cast Skill =====
        skill.Execute(gameObject, inputDir, skill);

        // ===== Set Cooldown =====
        skillCooldowns[index] = skill.cooldown;

        Debug.Log($"✓ Tung chiêu: {skill.skillName}");
    }

    // ================= UPDATE =================

    private void UpdateCooldowns()
    {
        if (skills == null) return;

        for (int i = 0; i < skills.Length; i++)
        {
            if (skillCooldowns[i] > 0)
            {
                skillCooldowns[i] -= Time.deltaTime;
            }
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < skillButtons.Length; i++)
        {
            if (skillButtons[i] == null) continue;

            bool isReady = skillCooldowns.ContainsKey(i) && skillCooldowns[i] <= 0;
            skillButtons[i].interactable = isReady;
        }
    }

    // ================= API =================

    public bool IsSkillReady(int index)
    {
        return skillCooldowns.ContainsKey(index) && skillCooldowns[index] <= 0;
    }

    public float GetSkillCooldown(int index)
    {
        if (!skillCooldowns.ContainsKey(index))
            return 0f;

        return Mathf.Max(0f, skillCooldowns[index]);
    }

    public SkillDataSO GetSkill(int index)
    {
        if (skills != null && index >= 0 && index < skills.Length)
            return skills[index];

        return null;
    }

    public SkillDataSO[] GetAllSkills()
    {
        return skills;
    }
}