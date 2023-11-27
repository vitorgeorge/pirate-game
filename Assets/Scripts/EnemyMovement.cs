using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody2D _rigidBody;
    private PlayerAwareness _playerAwareness;
    private Vector2 _targetDirection;


    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerAwareness = GetComponent<PlayerAwareness>();
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (_playerAwareness.IsEnemyAware)
        {
            _targetDirection = _playerAwareness.DirectionToPlayer;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }
    }
    void RotateTowardsTarget()
    {
        if(_targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _rigidBody.SetRotation(rotation);

    }

    void SetVelocity()
    {
        if (_targetDirection == Vector2.zero){
            _rigidBody.velocity = Vector2.zero;
        }
        else
        {
            _rigidBody.velocity = transform.up * _speed;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
