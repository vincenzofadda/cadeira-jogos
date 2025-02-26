using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Elements")]
    private Player player;
    private Animator animator; 

    [Header("Settings")]
    [SerializeField] private float moveSpeed;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(player != null)
            FollowPlayer();
    }

    public void storePlayer(Player player)
    {
        this.player = player;
    }

    private void FollowPlayer()
    {
        // Verifica se o inimigo está se movendo
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // Calcula a nova posição
        Vector2 targetPosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime;

        // Muda a posição do inimigo
        transform.position = targetPosition;

        // Atualiza o parâmetro "isWalking" baseado no movimento
        bool isWalking = direction.magnitude > 0;
        animator.SetBool("isWalking", isWalking);

         // Lógica para inverter o sprite conforme a direção do inimigo
        if (direction.x > 0)
            transform.localScale = new Vector3(1, 1, 1);  // Sprite virado para a direita
        else if (direction.x < 0)
            transform.localScale = new Vector3(-1, 1, 1); // Sprite virado para a esquerda
    }
}
