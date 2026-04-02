using UnityEngine;
using UnityEngine.UI;
public class WorldUI : MonoBehaviour
{
    public Button ReturnToMenuBtn;
    void Start()
    {
        ReturnToMenuBtn.onClick.AddListener(GameManager.Instance.ReturnToMenu);
    }
}