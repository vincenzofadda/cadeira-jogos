using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [Header(" Elements ")]
    private Rigidbody2D rig;
    private Collider2D collider;
    private RangeWeapon rangeWeapon;

    [Header(" Settings ")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private LayerMask enemyMask;
    private int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Configure(RangeWeapon rangeWeapon)
    {
        this.rangeWeapon = rangeWeapon;
    }
    public void Shoot(int damage, Vector2 direction)
    {
        Invoke("Release", 1);

        this.damage = damage;

        transform.right = direction;
        rig.linearVelocity = direction * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //if (target != null)
        //    return;

        if(IsInLayerMask(collider.gameObject.layer, enemyMask))
        {

            Attack(collider.GetComponent<Enemy>());
            Destroy(gameObject);
            //target = collider.GetComponent<Enemy>();

            //CancelInvoke();

            //Attack(target);
            //Release();
        }
    }

    private void Attack(Enemy enemy)
    {
        enemy.TakeDamage(damage);
    }

    private bool IsInLayerMask(int layer, LayerMask layerMask)
    {
        return (layerMask.value & (1 << layer)) != 0;
    }
}
