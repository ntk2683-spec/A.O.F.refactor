using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
public class SkillController : MonoBehaviour
{
    [Header("UI Buttons")]
    [SerializeField] private Button[] skillButtons = new Button[3];
    private SkillDataSO[] skills;
    private Dictionary<int, float> skillCooldowns = new Dictionary<int, float>();
    private Vector3 targetPosition = Vector3.zero;
    private void Start()
    {
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

    /// <summary>
    /// Khởi tạo event click cho button
    /// </summary>
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

    /// <summary>
    /// Khởi tạo cooldown cho tất cả skill
    /// </summary>
    private void InitializeCooldowns()
    {
        if (skills == null) return;

        for (int i = 0; i < skills.Length; i++)
        {
            skillCooldowns[i] = 0f;
        }
    }

    /// <summary>
    /// Sự kiện khi click button skill
    /// </summary>
    public void OnSkillButtonClicked(int index)
    {
        CastSkill(index, targetPosition);
    }

    /// <summary>
    /// Tung chiêu với kiểm tra cooldown
    /// </summary>
    public void CastSkill(int index, Vector3? targetPos = null)
    {
        // Kiểm tra index hợp lệ
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

        // Kiểm tra cooldown
        if (skillCooldowns[index] > 0)
        {
            Debug.Log($"⏳ {skill.skillName} đang cooldown: {skillCooldowns[index]:F1}s");
            return;
        }

        // Kiểm tra mana
        if (skill.manaCost > 0)
        {
            Debug.Log($"💙 Tiêu hao {skill.manaCost} mana");
        }

        // Thực thi skill
        Vector3 castPosition = targetPos ?? transform.position;
        skill.Use(gameObject, castPosition);

        // Áp dụng cooldown
        skillCooldowns[index] = skill.cooldown;
        Debug.Log($"✓ Tung chiêu: {skill.skillName}");
    }

    /// <summary>
    /// Cập nhật cooldown cho tất cả skill
    /// </summary>
    private void UpdateCooldowns()
    {
        for (int i = 0; i < skillCooldowns.Count; i++)
        {
            if (skillCooldowns[i] > 0)
            {
                skillCooldowns[i] -= Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// Cập nhật trạng thái button (khóa/mở) dựa trên cooldown
    /// </summary>
    private void UpdateUI()
    {
        for (int i = 0; i < skillButtons.Length; i++)
        {
            if (skillButtons[i] == null) continue;

            bool isReady = skillCooldowns[i] <= 0;
            skillButtons[i].interactable = isReady;
        }
    }

    /// <summary>
    /// Kiểm tra skill có sẵn sàng không
    /// </summary>
    public bool IsSkillReady(int index)
    {
        return index >= 0 && index < skillCooldowns.Count && skillCooldowns[index] <= 0;
    }

    /// <summary>
    /// Lấy thời gian cooldown còn lại
    /// </summary>
    public float GetSkillCooldown(int index)
    {
        if (index < 0 || index >= skillCooldowns.Count)
            return 0f;
        return Mathf.Max(0f, skillCooldowns[index]);
    }
    /// <summary>
    /// Lấy skill tại vị trí (đọc dữ liệu skill)
    /// </summary>
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
    /// <summary>
    /// Set vị trí target cho skill
    /// </summary>
    public void SetTargetPosition(Vector3 pos)
    {
        targetPosition = pos;
    }

    /// <summary>
    /// Hàm tương thích ngược - sử dụng UseSkill để tung chiêu
    /// </summary>
    public void UseSkill(int index, Vector3 targetPos)
    {
        CastSkill(index, targetPos);
    }
}