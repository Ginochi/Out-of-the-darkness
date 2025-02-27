using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    [SerializeField] private int maxHealth;

    private int _currentHealth;
    private bool _isDead;
    
    void Start()
    {
        _isDead = false;
    }
    
    public void TakeDamage(int damage)
    {
        if (_isDead) return;
        
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _isDead = true;
        }
    }
}
