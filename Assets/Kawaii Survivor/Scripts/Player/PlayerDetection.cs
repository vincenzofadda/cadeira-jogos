using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerDetection : MonoBehaviour
{

    [Header("Colliders")]
    [SerializeField] private Collider2D playerCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if(!collider.IsTouching(playerCollider))
        {
            return;
        }
        if(collider.TryGetComponent(out Cash cash))
        {
            cash.Collect(GetComponent<Player>());
        }
    }
}
