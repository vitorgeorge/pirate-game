using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;

    [SerializeField]
    private float _maximumHealth;

    public Sprite[] _shipState;

    public SpriteRenderer _currentShip;
    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    public bool IsInvincible { get; set; }

    public UnityEvent OnDied;

    public UnityEvent OnDamaged;

    public UnityEvent OnHealthChanged;

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }

        _currentHealth -= damageAmount;

        OnHealthChanged.Invoke();

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
        if(_currentHealth > 70) _currentShip.sprite = _shipState[0];
        if(_currentHealth < 70 && _currentHealth > 30) _currentShip.sprite = _shipState[1];
        if (_currentHealth < 30) _currentShip.sprite = _shipState[2];
        if (_currentHealth == 0)
        {
            _currentShip.sprite = null;
            gameObject.GetComponent<Animator>().enabled = true;
            OnDied.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth == _maximumHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;

        OnHealthChanged.Invoke();

        if (_currentHealth > _maximumHealth)
        {
            _currentHealth = _maximumHealth;
        }
    }
}