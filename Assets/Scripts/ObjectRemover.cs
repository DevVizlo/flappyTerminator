using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private EnemyBullerGenerator _poolEnemyBullets;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out EnemyBirdAttack enemy))
        {
            _pool.PutEnemy(enemy);
        }

        if (other.TryGetComponent(out EnemyRocket rocket))
        {
            _poolEnemyBullets.PutBullet(rocket);
        }
    }
}
