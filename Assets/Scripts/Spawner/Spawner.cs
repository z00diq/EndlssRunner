using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private bool _isOpposite;
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnDelay;

    private float elapsedTime = 0;

    private void Start()
    {
        Initialize(_enemyPrefabs);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= _spawnDelay)
        {
            if (!TryGetObject(out GameObject enemy))
                return;

            elapsedTime = 0;
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);

            SetEnemy(enemy,_spawnPoints[spawnPointIndex].position);
        }
    }

    private void SetEnemy(GameObject enemy,Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;

        if (_isOpposite)
            enemy.GetComponent<SpriteRenderer>().flipY = true;
        else
            enemy.GetComponent<EnemyMover>().SetNotOppositeEnemy();
        
    }

}
