using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    Character _character;
    [SerializeField] private ParticleSystem hit;
    private void Start()
    {
        _character = GetComponentInParent<Character>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            EnermyCharacter character = other.GetComponent<EnermyCharacter>();
            if (character != null)
            {
                character.EnemyHurt(_character._attackDamage);
                hit.Play();
            }
        }
    }
}
