using UnityEngine;

public class DropManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Cash cashPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void Awake()
    {
        Enemy.onDeath += EnemyDeathCallback;
    }

    private void OnDestroy()
    {
        Enemy.onDeath += EnemyDeathCallback;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnemyDeathCallback(Vector2 enemyPosition)
    {
        Instantiate(cashPrefab, enemyPosition, Quaternion.identity, transform);
    }
}
