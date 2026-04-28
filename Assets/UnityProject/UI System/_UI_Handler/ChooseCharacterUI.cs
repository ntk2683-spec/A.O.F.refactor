using UnityEngine;
using UnityEngine.UI;
using System.Text;
public class ChooseCharacterUI : MonoBehaviour
{
    [Header("Buttons")]
    public Button characterBtn1;
    public Button characterBtn2;
    public Button characterBtn3;
    public Button characterBtn4;
    public Button characterBtn5;
    public Button characterBtn6;
    public Button characterBtn7;
    public Button characterBtn8;
    public Button characterBtn9;
    public Button characterBtn10;
    public Button ConfirmBtn;

    [Header("Character Data")]
    public CharacterDataSO character1;
    public CharacterDataSO character2;
    public CharacterDataSO character3;
    public CharacterDataSO character4;
    public CharacterDataSO character5;
    public CharacterDataSO character6;
    public CharacterDataSO character7;
    public CharacterDataSO character8;
    public CharacterDataSO character9;
    public CharacterDataSO character10;
    [Header("UI")]
    public Text statText;
    void Start()
    {
        characterBtn1.onClick.AddListener(() => SelectCharacter(character1));
        characterBtn2.onClick.AddListener(() => SelectCharacter(character2));
        characterBtn3.onClick.AddListener(() => SelectCharacter(character3));
        characterBtn4.onClick.AddListener(() => SelectCharacter(character4));
        characterBtn5.onClick.AddListener(() => SelectCharacter(character5));
        characterBtn6.onClick.AddListener(() => SelectCharacter(character6));
        characterBtn7.onClick.AddListener(() => SelectCharacter(character7));
        characterBtn8.onClick.AddListener(() => SelectCharacter(character8));
        characterBtn9.onClick.AddListener(() => SelectCharacter(character9));
        characterBtn10.onClick.AddListener(() => SelectCharacter(character10));
        ConfirmBtn.onClick.AddListener(ConfirmCharacter);
    }
    void SelectCharacter(CharacterDataSO character)
    {
        GameManager.Instance.selectedCharacter = character;

        ShowStats(character);
    }
    void ShowStats(CharacterDataSO character)
    {
        StringBuilder sb = new StringBuilder();

        foreach (StatValue stat in character.stats)
        {
            sb.AppendLine($"{GetStatName(stat.type)}: {stat.value}");
        }

        statText.text = sb.ToString();
    }
    string GetStatName(StatType type)
    {
        switch (type)
        {
            case StatType.maxHP:
                return "HP";

            case StatType.maxMP:
                return "MP";

            case StatType.ATK:
                return "ATK";

            case StatType.DEF:
                return "DEF";

            case StatType.SPD:
                return "SPD";

            case StatType.attackCooldown:
                return "CLD";

            case StatType.detectRange:
                return "Range";

            default:
                return type.ToString();
        }
    }
    void ConfirmCharacter()
    {
        if (GameManager.Instance.selectedCharacter != null)
        {
            GameManager.Instance.ReturnToMenu();
        }
    }
}