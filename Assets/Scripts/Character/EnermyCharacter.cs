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
    private BehaviorTree _behaviour;
    protected override void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        base.Start();
        _currentPosture = _maxPosture;
        _behaviour=GetComponentInParent<BehaviorTree>();
    }
    
    
    
    [Command]
    public void EnemyHurt(int Damage)
    {
        _animator.Play("Hurt");
    }

    protected override void CharacterDie()
    {
        if (_currentHp <= 0 && !isDie)
        {
            Debug.Log(_name + "Die");
            isDie = true;
            _animator.Play("Die");
            _behaviour.enabled = false;
        }
        else if(_currentHp>0 && isDie)
        {
            isDie = false;
        }
        
    }
    
    
}
