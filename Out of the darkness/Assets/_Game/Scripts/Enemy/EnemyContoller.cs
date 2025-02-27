using UnityEngine;

public class EnemyContoller : MonoBehaviour
{
    [SerializeField] private int movementSpeed;
    [SerializeField] private int attackDamage;
    
    private GameObject _player;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _player = GameObject.FindGameObjectsWithTag("Player")[0];
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveToPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        AttackPlayer(other);
    }
    
    private void MoveToPlayer()
    {
        _rb.MovePosition(_player.transform.position * movementSpeed * Time.deltaTime);
    }
    
    private void AttackPlayer(Collider collidingPlayer)
    {
        var player = collidingPlayer.GetComponent<PlayerCondition>();
        if (player != null)
        {
            player.TakeDamage(attackDamage);
        }
    }
}
