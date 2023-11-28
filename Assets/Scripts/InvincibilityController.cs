using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private HealthController healthController;

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
    }

    public void StartInvencibility(float duration)
    {
        StartCoroutine(InvincibilityCoroutine(duration));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration)
    {
        healthController.IsInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        healthController.IsInvincible = false;
    }
}
