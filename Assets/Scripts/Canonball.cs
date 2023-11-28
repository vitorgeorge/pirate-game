using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canonball : MonoBehaviour
{

    private Camera _camera;

    private int _shotsReceived;

    private bool _shoted = false;


    public Sprite _damagedShip;
    private void Awake()
    {
        _camera = Camera.main;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            GameController._killCount++;
            collision.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = _damagedShip;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        DestroyWhenOffScreen();
    }

    private void DestroyWhenOffScreen()
    {

            Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

            if (screenPosition.x < 0 || screenPosition.x > _camera.pixelWidth || screenPosition.y < 0 || screenPosition.y > _camera.pixelHeight)
            {
                Destroy(gameObject);
            }
        
    }
}
