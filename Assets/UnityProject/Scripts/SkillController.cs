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
    public void OnSkillButtonClicked(int index)
    {
        CastSkill(index, targetPosition);
    }
    public void CastSkill(int index, Vector3? targetPos = null)
    {
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
        if (skill.manaCost > 0)
        {
            Debug.Log($"💙 Tiêu hao {skill.manaCost} mana");
        }
        Vector3 castPosition = targetPos ?? transform.position;
        skill.Use(gameObject, castPosition);
        skillCooldowns[index] = skill.cooldown;
        Debug.Log($"✓ Tung chiêu: {skill.skillName}");
    }
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
    private void UpdateUI()
    {
        for (int i = 0; i < skillButtons.Length; i++)
        {
            if (skillButtons[i] == null) continue;

            bool isReady = skillCooldowns[i] <= 0;
            skillButtons[i].interactable = isReady;
        }
    }
    public bool IsSkillReady(int index)
    {
        return index >= 0 && index < skillCooldowns.Count && skillCooldowns[index] <= 0;
    }
    public float GetSkillCooldown(int index)
    {
        if (index < 0 || index >= skillCooldowns.Count)
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
    public void SetTargetPosition(Vector3 pos)
    {
        targetPosition = pos;
    }
    public void UseSkill(int index, Vector3 targetPos)
    {
        CastSkill(index, targetPos);
    }
}