using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public CharacterStatSO selectedCharacter;
    public SkillDataSO[] selectedSkills = new SkillDataSO[3];
    void Awake()
    { 
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); } 
        else Destroy(gameObject);
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
        LoadScene("World");
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