using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    [Header("Elements")]
    private Player player;

    [Header("Setting")]
    [SerializeField] private float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();

        if(player == null)
        {
          Debug.LogWarning("Não há nenhum jogador, destruindo inimigos");
          Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;

        Vector2 targetPosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime;

        transform.position = targetPosition;
    }


}
