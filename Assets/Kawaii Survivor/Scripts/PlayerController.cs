using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rig;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rig = GetComponent<Rigidbody2D>();
      rig.linearVelocity = Vector2.right;
    }

    // Update is called once per frame
    void Update()
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

        rig.linearVelocity = new Vector2(moveX, moveY); // Aplica a velocidade ao Rigidbody2D
    }
}
