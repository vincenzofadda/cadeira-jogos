using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rig;
    private Animator animator; 

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>(); 
    }

    private void FixedUpdate()
    {
        float moveX = 0f;
        float moveY = 0f;
        
        if (Input.GetKey(KeyCode.D))
        {
            moveX = speed;
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            moveX = -speed;
        }
        if (Input.GetKey(KeyCode.W)) 
        {
            moveY = speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -speed;
        }

        rig.linearVelocity = new Vector2(moveX, moveY);

        // Define animação de andar
        bool isWalking = moveX != 0 || moveY != 0;
        animator.SetBool("isWalking", isWalking);

        // Ajusta a direção do sprite (Flip)
        if (moveX > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveX < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}
