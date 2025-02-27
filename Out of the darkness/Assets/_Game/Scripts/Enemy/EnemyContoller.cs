using UnityEngine;

public class EnemyContoller : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private int attackDamage;
    [SerializeField] private GameObject player;
    
    private Rigidbody2D _rb;
    private Vector3 _playerPosition;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _playerPosition = player.transform.position;
        MoveToPlayer();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        AttackPlayer(other);
    }
    
    private void MoveToPlayer()
    {
        _rb.MovePosition(_playerPosition * movementSpeed * Time.deltaTime);
    }
    
    private void AttackPlayer(Collider2D collidingTarget)
    {
        var collidingPlayer = collidingTarget.GetComponent<PlayerCondition>();
        if (collidingPlayer != null)
        {
            collidingPlayer.TakeDamage(attackDamage);
        }
    }
}
