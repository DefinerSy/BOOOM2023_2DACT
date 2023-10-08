using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private int m_currentAttack = 0;
    private float m_timeSinceAttack = 0.0f;
    private PlayerMovement PlayerMovement;
    
    [Header("攻击间隔")] 
    [SerializeField] private float _attackCd;
    [SerializeField] public bool _isAttacking;

    [Header("攻击硬直")] 
    [SerializeField] private float _attackRecoveryTime;
    [SerializeField] private bool _isrecovery = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        PlayerMovement = this?.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        Attack();
        AttackRecovery();
        m_timeSinceAttack += Time.deltaTime;
        if (m_timeSinceAttack > 1.0f)
            m_currentAttack = 1;
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J) && m_timeSinceAttack > _attackCd && !Input.GetKey(KeyCode.Semicolon))
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

    public void AttackRecovery()
    {
        if (_isrecovery || _isAttacking)
        {
            PlayerMovement._moveInput.x = 0;
        }
        
    }
    public void AttackRecoveryTime()
    {
        if (PlayerMovement != null)
        {
            _isrecovery = true;
            _isAttacking = true;
            //PlayerMovement.enabled = false;
            Invoke("AttackRecoveryOver", _attackRecoveryTime);
        }
    }

    public void AttackRecoveryOver()
    {
        _isrecovery = false;
    }

    public void AttackOver()
    {
        _isAttacking = false;
    }
}