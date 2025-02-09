using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
  [Header(" Settings ")]
  [SerializeField] private int maxHealth;
  private int health;

  public event Action<int, int> OnHealthChanged;

  void Start()
  {
    health = maxHealth;
    OnHealthChanged?.Invoke(health, maxHealth);
  }

  public void TakeDamage(int damage)
  {
    int realDamage = Mathf.Min(damage, health);
    health -= realDamage;

    OnHealthChanged?.Invoke(health, maxHealth);

    if (health <= 0)
    {
      PassAway();
    }
  }

  private void PassAway()
  {
    Debug.Log("Dead");
  }
}
