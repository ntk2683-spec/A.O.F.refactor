using UnityEngine;
using UnityEngine.UI;
public class MainMenuUI : MonoBehaviour
{
    public Button startButton;
    public Button characterButton;
    public Button skillButton;
    public Button quitButton;
    void Start()
    {
        startButton.onClick.AddListener(GameManager.Instance.StartGame);
        characterButton.onClick.AddListener(GameManager.Instance.ChooseCharacter);
        skillButton.onClick.AddListener(GameManager.Instance.ChooseSpecialSkill);
        quitButton.onClick.AddListener(GameManager.Instance.QuitGame);
    }
}