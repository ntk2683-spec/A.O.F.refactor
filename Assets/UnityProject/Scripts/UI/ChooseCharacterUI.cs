using UnityEngine;
using UnityEngine.UI;
public class ChooseCharacterUI : MonoBehaviour
{
    public Button characterBtn1;
    public Button characterBtn2;
    public Button characterBtn3;
    public Button ConfirmBtn;
    public CharacterDataSO character1;
    public CharacterDataSO character2;
    public CharacterDataSO character3;
    void Start()
    {
        characterBtn1.onClick.AddListener(() => SelectCharacter(character1));
        characterBtn2.onClick.AddListener(() => SelectCharacter(character2));
        characterBtn3.onClick.AddListener(() => SelectCharacter(character3));
        ConfirmBtn.onClick.AddListener(ConfirmCharacter);
    }
    void SelectCharacter(CharacterDataSO character)
    {
        GameManager.Instance.selectedCharacter = character;
    }
    void ConfirmCharacter()
    {
        if(GameManager.Instance.selectedCharacter != null)
        {
            GameManager.Instance.ReturnToMenu();
        }
    }
}