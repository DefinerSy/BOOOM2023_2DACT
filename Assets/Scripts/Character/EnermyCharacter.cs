using QFSW.QC;
using UnityEngine;

public class EnermyCharacter : Character
{
    [Header("架势条")]
    [SerializeField] float _maxPosture;
    [SerializeField] float _currentPosture;
    private Animator _animator;
    protected override void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        base.Start();
        _currentPosture = _maxPosture;
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
    }
    
    public void DieAnimationEnd()
    {
        Destroy(gameObject);
    }
}
