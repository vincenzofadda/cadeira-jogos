using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class PlayerLevel : MonoBehaviour
{
    [Header("Visuals")]
    private int requiredXp;
    private int currentXp;
    private int level;
    private int levelsEarnedThisWave;

    [Header("Visuals")]
    [SerializeField] private Slider xpBar;
    [SerializeField] private TextMeshProUGUI levelText;

  void Awake()
  {
    Cash.onCollected += CashCollectedCallback;
  }

  void OnDestroy()
  {
    Cash.onCollected -= CashCollectedCallback;
  }
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
    {
        UpdateRequiredXp();
        UpdateVisuals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateRequiredXp()
    {
      requiredXp = (level + 1) * 5;
    }

    private void UpdateVisuals()
    {
      xpBar.value = (float)currentXp / requiredXp;
      levelText.text = "lvl " + (level+1);
    }

    private void CashCollectedCallback(Cash cash)
    {
      currentXp++;

      if(currentXp >=requiredXp)
      {
        LevelUp();

      }
      UpdateVisuals();
    }

    private void LevelUp()
    {
      level++;
      levelsEarnedThisWave++;
      currentXp = 0;
      UpdateRequiredXp();
    }

    public bool HasLeveledUp()
    {
      if(levelsEarnedThisWave > 0)
      {
        levelsEarnedThisWave--;
        return true;
      }
      else
      {
        return false;
      }
    }
}
