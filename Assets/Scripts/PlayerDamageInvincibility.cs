using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageInvincibility : MonoBehaviour
{
    [SerializeField]
    private float _invincibilityDuration;

    private InvincibilityController controller;

    private void Awake()
    {
        controller = GetComponent<InvincibilityController>();
    }
    public void StartInvencibility()
    {
        controller.StartInvencibility(_invincibilityDuration);
    }
}
