using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Elements")]
    private Player player;
    
    [Header("Settings")]
    [SerializeField] private float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        player = FindFirstObjectByType<Player>();

        if(player == null)
        {
            Debug.LogWarning("Player não detectado, destruindo inimigos..");
        }
    }

    // Update is called once per frame
    void Update()
    {
       Vector2 direction = (player.transform.position - transform.position).normalized;

       Vector2 targetPosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime; 

       transform.position = targetPosition;
    }
}
