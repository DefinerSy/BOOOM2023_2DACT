using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Character _character;
    private void Awake()
    {
        _character=GetComponentInParent<Character>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHurt character = other.GetComponent<PlayerHurt>();
            if (character != null)
            {
                character.Hurt(_character._attackDamage);
            }
        }
    }
}
