using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IPlayerStatsDepedency
{

  [Header(" Elements ")]
  [SerializeField] private Slider healthSlider;
  [SerializeField] private TextMeshProUGUI healthText;
  [SerializeField] private PlayerHealth playerHealth;

  [Header(" Settings ")]
  [SerializeField] private int baseMaxHealth;
  private int maxHealth;
  private int health;

  public event Action<int, int> OnHealthChanged;

  void Start()
  {

  }

  public void TakeDamage(int damage)
  {
    int realDamage = Mathf.Min(damage, health);
    health -= realDamage;

    UpdateUI();

    if (health <= 0)
    {
      PassAway();
    }
  }

  private void PassAway()
  {
    GameManager.instance.SetGameState(GameState.GAMEOVER);
  }

  private void UpdateUI()
  {
    float healthBarValue = (float)health / maxHealth;
    healthSlider.value = healthBarValue;
    healthText.text = health + " / " + maxHealth;
  }

  public void UpdateStats(PlayerStatsManager playerStatsManager)
  {
    float addedHealth = playerStatsManager.GetStatValue(Stat.MaxHealth);
    maxHealth = baseMaxHealth + (int)addedHealth;
    maxHealth = Mathf.Max(maxHealth, 1);

    health = maxHealth;
    UpdateUI();
  }
}
