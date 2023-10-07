using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class EnemyCondition : Conditional
{
    protected Rigidbody2D rigidbody2D;
    protected Animator Animator;
    protected Character Character;
    
    public override void OnAwake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Character = GetComponent<Character>();
    }
}
