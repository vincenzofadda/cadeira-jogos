using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{

    [Header("Components")]
    private EnemyMovement movement;

    [Header("Elements")]
    private Player player;

    [Header("Spawn Sequence Related")]
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private SpriteRenderer spawnIndicator;
    private bool hasSpawned;

    [Header("Effects")]
    [SerializeField] private ParticleSystem deathParticles;

    [Header("Attack")]
    [SerializeField] private int damage;
    [SerializeField] private float attackFrequency;
    [SerializeField] private float playerDetectionRadius;
    private float attackDelay;
    private float attackTimer;

    [Header("DEBUG")]
    [SerializeField] private bool gizmos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponent<EnemyMovement>();

        player = FindFirstObjectByType<Player>();

        if(player == null)
        {
            Debug.LogWarning("Player não detectado, destruindo inimigos..");
            Destroy(gameObject);
        }

        startSpawnSequence();

        attackDelay = 1f / attackFrequency;
    }

    private void startSpawnSequence()
    {
        SetRenderersVisibility(false);


        Vector3 targetScale = spawnIndicator.transform.localScale * 1.2f;
        LeanTween.scale(spawnIndicator.gameObject, targetScale, .3f).setLoopPingPong(4).setOnComplete(SpawnSequenceCompleted);

    }

    private void SpawnSequenceCompleted()
    {
        SetRenderersVisibility(true);
        hasSpawned = true;

        movement.storePlayer(player);
    }

    private void SetRenderersVisibility(bool visibility)
    {
        renderer.enabled = visibility;
        spawnIndicator.enabled =  !visibility;
    }

    // Update is called once per frame
    void Update()
    {
        if(attackTimer >= attackDelay)
            TryAttack();   
        else
            Wait();     
    }

    private void Wait()
    {
        attackTimer += Time.deltaTime; 
    }

    private void TryAttack()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if(distanceToPlayer <= playerDetectionRadius)
        {
            Attack();
            
        }
    }

    private void Attack()
    {
        attackTimer = 0;
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
