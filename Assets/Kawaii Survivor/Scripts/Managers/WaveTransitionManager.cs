using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using NaughtyAttributes;

using Random = UnityEngine.Random;

public class WaveTransitionManager : MonoBehaviour, IGameStateListener
{

    [Header("Elements")]
    [SerializeField] private PlayerStatsManager playerStatsManager;
    [SerializeField] private UpgradeContainer[] upgradeContainers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStateChangedCallback(GameState gameState)
   {
    switch(gameState)
    {
        case GameState.WAVETRANSITION:
            ConfigureUpgradeContainers();
            break;
    }
   }

[Button]
   private void ConfigureUpgradeContainers()
   {
        for(int i = 0; i < upgradeContainers.Length; i++)
        {

            int randomIndex = Random.Range(0, Enum.GetValues(typeof(Stat)).Length);
            Stat stat = (Stat)Enum.GetValues(typeof(Stat)).GetValue(randomIndex);

            string randomStatString = Enums.FormatStatName(stat);

            string buttonString;
            Action action = GetActionToPerform(stat, out buttonString);

            upgradeContainers[i].Configure(null, randomStatString, buttonString);

            upgradeContainers[i].Button.onClick.RemoveAllListeners();
            upgradeContainers[i].Button.onClick.AddListener(() => action?.Invoke());

            upgradeContainers[i].Button.onClick.AddListener(() => BonusSelectedCallback());
        }
   }

   private void BonusSelectedCallback()
   {
    GameManager.instance.WaveCompletedCallback();
   }

   private Action GetActionToPerform(Stat stat, out string buttonString)
   {

    buttonString = "";
    float value;
    value = Random.Range(1, 10);
    buttonString = "+" + value.ToString() + "%";

    switch(stat)
    {
      case Stat.Attack:
        value = Random.Range(1, 10);

        break;

      case Stat.AttackSpeed:
        value = Random.Range(5, 20);

        break;
      
      case Stat.MaxHealth:
        value = Random.Range(1, 15);
        buttonString = "+" + value;
        break;

      default:
        return () => Debug.Log("Stat invalido");
    }

    return () => playerStatsManager.AddPlayerStat(stat, value);
   }
}
