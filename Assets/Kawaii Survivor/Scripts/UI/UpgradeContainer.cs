using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeContainer : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI upgradeNameText;
    [SerializeField] private TextMeshProUGUI upgradeValueText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Configure(Sprite icon, string upgradeName, string upgradeValue)
    {
        image.sprite = icon;
        upgradeNameText.text = upgradeName;
        upgradeValueText.text = upgradeValue;
    }

    public Button GetButton()
    {
        return GetButton;
    }
}
