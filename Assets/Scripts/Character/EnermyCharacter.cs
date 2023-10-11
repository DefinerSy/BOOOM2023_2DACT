using BehaviorDesigner.Runtime;
using QFSW.QC;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class EnermyCharacter : Character
{
    [Header("架势条")]
    [SerializeField] float _maxPosture;
    [SerializeField] float _currentPosture;
    private Animator _animator;
    private EnemyHPBar _hpBar;
    private BehaviorTree _behaviour;
    private BoxCollider2D _collider2D;
    private Rigidbody2D _rigidbody2D;
    protected override void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        base.Start();
        _currentPosture = _maxPosture;
        _behaviour=GetComponentInParent<BehaviorTree>();
        _hpBar = GetComponentInChildren<EnemyHPBar>();
        _collider2D = GetComponent<BoxCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    
    
    [Command]
    public void EnemyHurt(int Damage)
    {
        Debug.Log("HP:"+_currentHp+"->"+(_currentHp-Damage));
        _animator.Play("Hurt");
        _hpBar.GetHurt(Damage);
        _currentHp -= Damage;
    }

    protected override void CharacterDie()
    {
        if (_currentHp <= 0 && !isDie)
        {
            Debug.Log(_name + "Die");
            isDie = true;
            _animator.Play("Die");
            _behaviour.enabled = false;
            _rigidbody2D.simulated = false;
            _collider2D.enabled = false;
            
        }
        else if(_currentHp>0 && isDie)
        {
            isDie = false;
        }
        
    }
    
    
}
