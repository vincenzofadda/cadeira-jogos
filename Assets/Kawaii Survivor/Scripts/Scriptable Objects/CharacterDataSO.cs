using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.Search;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Data", menuName = "SO/ New Character Data", order = 0)]
public class CharacterDataSO : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }

    [SerializeField] private float attack;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float maxHealth;

    public Dictionary<Stat, float> BaseStats 
    { 
      get
      {
        return new Dictionary<Stat, float>
        {
          {Stat.Attack, attack},
          {Stat.AttackSpeed, attackSpeed},
          {Stat.MaxHealth, maxHealth}
        };
      }
      private set { }
    }
}
