using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Elements")]
    private Player player;
    
    [Header("Spawn Sequence Related")]
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private SpriteRenderer spawnIndicator;
    
    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float playerDetectionRadius;

    [Header("Effects")]
    [SerializeField] private ParticleSystem deathParticles;

    [Header("DEBUG")]
    [SerializeField] private bool gizmos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        player = FindFirstObjectByType<Player>();

        if(player == null)
        {
            Debug.LogWarning("Player não detectado, destruindo inimigos..");
        }

        renderer.enabled = false;
        spawnIndicator.enabled =  true;
    }

    // Update is called once per frame
    void Update()
    {
       FollowPlayer();
       TryAttack();
    }

    private void FollowPlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;

       Vector2 targetPosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime; 

       transform.position = targetPosition;
    }

    private void TryAttack()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if(distanceToPlayer <= playerDetectionRadius)
        {
            Death();
            
        }
    }

    private void Death()
    {
        deathParticles.transform.SetParent(null);
        deathParticles.Play();
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        if(!gizmos)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerDetectionRadius);
    }
}
