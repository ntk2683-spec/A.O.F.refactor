using UnityEngine;
using UnityEngine.UI;
public class ChooseSpecialSkillUI : MonoBehaviour
{
    [Header("Buttons")]
    public Button skillBtn1;
    public Button skillBtn2;
    public Button skillBtn3;
    public Button confirmButton;
    [Header("Skill Data")]
    public SkillDataSO skill1;
    public SkillDataSO skill2;
    public SkillDataSO skill3;
    [Header("Guide Text")]
    public GameObject textSkill1;
    public GameObject textSkill2;
    public GameObject textSkill3;
    private SkillDataSO[] selectedSkills = new SkillDataSO[3];
    private int currentStep = 0;
    private SkillDataSO currentSelectedSkill = null;
    void Start()
    {
        skillBtn1.onClick.AddListener(() => SelectSkill(skill1));
        skillBtn2.onClick.AddListener(() => SelectSkill(skill2));
        skillBtn3.onClick.AddListener(() => SelectSkill(skill3));
        confirmButton.onClick.AddListener(ConfirmSelection);
        UpdateUI();
    }
    void SelectSkill(SkillDataSO skill)
    {
        currentSelectedSkill = skill;
    }
    void ConfirmSelection()
    {
        if (currentSelectedSkill == null)
        {
            return;
        }
        selectedSkills[currentStep] = currentSelectedSkill;
        DisableSelectedButton(currentSelectedSkill);
        currentSelectedSkill = null;
        currentStep++;
        if (currentStep >= 3)
        {
            GameManager.Instance.selectedSkills = selectedSkills;
            GameManager.Instance.ReturnToMenu();
        }
        UpdateUI();
    }
    void DisableSelectedButton(SkillDataSO skill)
    {
        if (skill == skill1) skillBtn1.gameObject.SetActive(false);
        else if (skill == skill2) skillBtn2.gameObject.SetActive(false);
        else if (skill == skill3) skillBtn3.gameObject.SetActive(false);
    }
    void UpdateUI()
    {
        textSkill1.SetActive(currentStep == 0);
        textSkill2.SetActive(currentStep == 1);
        textSkill3.SetActive(currentStep == 2);
    }
}