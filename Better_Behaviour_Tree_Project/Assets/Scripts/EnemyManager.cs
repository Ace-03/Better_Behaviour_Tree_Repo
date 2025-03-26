using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private int _healthpoints;
    public bool _isCrate;

    private void Awake()
    {
        _healthpoints = 30;
    }

    public bool TakeHit()
    {
        _healthpoints -= 10;
        bool isDead = _healthpoints <= 0;
        if (isDead) _Die();
        return isDead;
    }

    private void _Die()
    {
        //if (gameObject != null)
        {
            Destroy(gameObject);
        }
        
    }
}