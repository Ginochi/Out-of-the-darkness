using UnityEngine;

public class EnemyContoller : MonoBehaviour
{
    [SerializeField] private int movementSpeed;
    
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

    private void MoveToPlayer()
    {
        _rb.MovePosition(_player.transform.position * movementSpeed * Time.deltaTime);
    }
}
