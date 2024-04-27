using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private EnemyRocket _prefab;

    private Queue<EnemyRocket> _enemyPool;
   
    private void Awake()
    {
        _enemyPool = new Queue<EnemyRocket>();
    }

    public EnemyRocket GetEnemy()
    {
        if (_enemyPool.Count == 0)
         {
             var enemy = Instantiate(_prefab);

             return enemy;
         }

         return _enemyPool.Dequeue();
    }

    public void PutEnemy(EnemyRocket enemy)
    {
        enemy.gameObject.SetActive(false);
        _enemyPool.Enqueue(enemy);
    }
}
