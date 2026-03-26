using UnityEngine;
using UnityEngine.UI;
public class ChooseCharacterUI : MonoBehaviour
{
    public Button characterBtn1;
    public Button characterBtn2;
    public Button characterBtn3;
    public Button ConfirmBtn;
    public CharacterStatSO character1;
    public CharacterStatSO character2;
    public CharacterStatSO character3;
    void Start()
    {
        characterBtn1.onClick.AddListener(() => SelectCharacter(character1));
        characterBtn2.onClick.AddListener(() => SelectCharacter(character2));
        characterBtn3.onClick.AddListener(() => SelectCharacter(character3));
        ConfirmBtn.onClick.AddListener(ConfirmCharacter);
    }
    void SelectCharacter(CharacterStatSO character)
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