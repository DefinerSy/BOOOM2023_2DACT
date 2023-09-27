using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private int m_currentAttack = 0;
    private float m_timeSinceAttack = 0.0f;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
        m_timeSinceAttack += Time.deltaTime;
        if (m_timeSinceAttack > 1.0f)
            m_currentAttack = 1;
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            m_currentAttack++;

            // Loop back to one after third attack
            if (m_currentAttack > 3)
                m_currentAttack = 1;

            // Reset Attack combo if time since last attack is too large
            if (m_timeSinceAttack > 1.0f)
                m_currentAttack = 1;

            // Call one of three attack animations "Attack1", "Attack2", "Attack3"
            anim.SetTrigger("Attack" + m_currentAttack);

            // Reset timer
            m_timeSinceAttack = 0.0f;
        }
    }
}
