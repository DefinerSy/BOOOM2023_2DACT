using QFSW.QC;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class EnermyCharacter : Character
{
    [Header("架势条")]
    [SerializeField] float _maxPosture;
    [SerializeField] float _currentPosture;
    private Animator _animator;
    private Behaviour _behaviour;
    protected override void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        base.Start();
        _currentPosture = _maxPosture;
        _behaviour=GetComponentInParent<Behaviour>();
    }
    
    
    
    [Command]
    public void EnemyHurt(int Damage)
    {
        _animator.Play("Hurt");
    }

    protected override void CharacterDie()
    {
        base.CharacterDie();
        _animator.Play("Die");
        _behaviour.enabled = false;
    }
    
    
}
