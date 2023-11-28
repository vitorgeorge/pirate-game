using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    public static float _spawnTime;

    [SerializeField]
    private float _timeUntilSpawn;
    // Start is called before the first frame update
    void Awake()
    {
        SetTimeSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if( _timeUntilSpawn <= 0)
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity );
            SetTimeSpawn();
        }
    }
    
    private void SetTimeSpawn()
    {
        _timeUntilSpawn = MenuController._enemySpawnRate;
    }
}
