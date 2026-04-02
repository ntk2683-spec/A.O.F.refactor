using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public CharacterDataSO selectedCharacter;
    public SkillDataSO[] selectedSkills = new SkillDataSO[3];

    [Header("UI Thông báo")]
    [SerializeField] private GameObject noCharacterObj;  // Object thông báo chưa chọn nhân vật
    [SerializeField] private GameObject noSkillsObj;     // Object thông báo chưa chọn skill
    [SerializeField] private GameObject noBothObj;       // Object thông báo chưa chọn cả 2

    void Awake()
    { 
        if (Instance == null) 
        { 
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        HideAllWarnings();
    }

    private void HideAllWarnings()
    {
        if (noCharacterObj != null) noCharacterObj.SetActive(false);
        if (noSkillsObj != null) noSkillsObj.SetActive(false);
        if (noBothObj != null) noBothObj.SetActive(false);
    }

    /// <summary>
    /// Tìm lại object reference từ scene hiện tại (vì GameManager persist qua scenes)
    /// </summary>
    private void RefreshObjectReferences()
    {
        if (noCharacterObj == null)
            noCharacterObj = GameObject.Find("NoCharacter");
        if (noSkillsObj == null)
            noSkillsObj = GameObject.Find("NoSkill");
        if (noBothObj == null)
            noBothObj = GameObject.Find("NoBoth");
    }

    private void ShowWarning(GameObject warningObj, float duration = 2f)
    {
        if (warningObj == null) return;
        
        StopCoroutine(HideWarningAfterDelay(warningObj, duration));
        warningObj.SetActive(true);
        StartCoroutine(HideWarningAfterDelay(warningObj, duration));
    }

    private IEnumerator HideWarningAfterDelay(GameObject warningObj, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (warningObj != null)
            warningObj.SetActive(false);
    }

    private bool ValidateSelection()
    {
        bool hasCharacter = selectedCharacter != null;
        bool hasAllSkills = selectedSkills[0] != null && selectedSkills[1] != null && selectedSkills[2] != null;

        if (!hasCharacter && !hasAllSkills)
        {
            ShowWarning(noBothObj);
            return false;
        }

        if (!hasCharacter)
        {
            ShowWarning(noCharacterObj);
            return false;
        }

        if (!hasAllSkills)
        {
            ShowWarning(noSkillsObj);
            return false;
        }

        return true;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReturnToMenu()
    {
        LoadScene("MainMenu");
    }

    public void StartGame()
    {
        RefreshObjectReferences();
        if (ValidateSelection())
        {
            LoadScene("World");
        }
    }

    public void ChooseCharacter()
    {
        LoadScene("ChooseCharacter");
    }

    public void ChooseSpecialSkill()
    {
        LoadScene("ChooseSpecialSkill");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void WinGame()
    {
        LoadScene("WinGame");
    }
}