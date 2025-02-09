using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
  [Header(" Elements ")]
  [SerializeField] private Slider healthSlider;
  [SerializeField] private TextMeshProUGUI healthText;
  [SerializeField] private PlayerHealth playerHealth;

  void Start()
  {
    playerHealth.OnHealthChanged += UpdateUI;
  }

  private void UpdateUI(int health, int maxHealth)
  {
    float healthBarValue = (float)health / maxHealth;
    healthSlider.value = healthBarValue;
    healthText.text = health + " / " + maxHealth;
  }
}
