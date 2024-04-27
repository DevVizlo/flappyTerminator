using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody2D))]
public class ShootToPlayer : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _detectionDistance;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _recharge;

    private Rigidbody2D _rigidbody2D;
    private ObjectPool<GameObject> _pool;

    private float _flightBoundarynd = -2;
    private int _poolCapacity = 1;
    private int _poolMaxSize = 3;

    private float _nextActionTime = 0f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _pool = new ObjectPool<GameObject>(
        createFunc: () => Instantiate(_prefab),
        actionOnGet: (obj) => ActionOnGet(obj),
        actionOnRelease: (obj) => obj.SetActive(false),
        actionOnDestroy: (obj) => Destroy(obj),
        collectionCheck: true,
        defaultCapacity: _poolCapacity,
        maxSize: _poolMaxSize);
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rigidbody2D.position, Vector2.left, _detectionDistance, _layerMask);

        if (hit.collider != null)
        {
            if (Time.time >= _nextActionTime)
                StartCoroutine(CouldDown());
        }

    }

    public void PoolRelease(GameObject rocket)
    {
            _pool.Release(rocket.gameObject);
            Debug.Log("Ѕуба лох");
    }

    private void ActionOnGet(GameObject rocket)
    {
        rocket.transform.position = transform.position;
        rocket.gameObject.SetActive(true);
    }
 
    private IEnumerator CouldDown()
    {
        _nextActionTime = Time.time + _recharge;

        _pool.Get();
        yield return new WaitForSeconds(.1f);
    }
}