using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwareness : MonoBehaviour
{
    public bool IsEnemyAware { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance;

    private Transform _player;

    private void Awake()
    {
        _player = FindAnyObjectByType<PlayerMovement>().transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerPosition = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerPosition.normalized;

        if (enemyToPlayerPosition.magnitude <= _playerAwarenessDistance)
        {
            IsEnemyAware = true;
        }
        else
        {
            IsEnemyAware = false;
        }
    }
}
