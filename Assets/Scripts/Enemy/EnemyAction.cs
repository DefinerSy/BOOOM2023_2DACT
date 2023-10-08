using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class EnemyAction : Action
{
    protected Rigidbody2D rigidbody2D;
    protected Animator Animator;
    protected Character Character;

    public override void OnAwake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = gameObject.GetComponentInChildren<Animator>();
        Character = GetComponent<Character>();
    }

}
