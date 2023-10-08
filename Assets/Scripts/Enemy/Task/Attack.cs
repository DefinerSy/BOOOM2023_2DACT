using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class Attack : EnemyAction
{
    public override TaskStatus OnUpdate()
    {
        Animator.Play("Attack");
        return TaskStatus.Success;
    }
}
