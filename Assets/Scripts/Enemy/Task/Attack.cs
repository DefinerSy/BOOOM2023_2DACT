using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class Attack : EnemyAction
{
    private AnimatorStateInfo stateInfo;
    public override TaskStatus OnUpdate()
    {
        stateInfo = Animator.GetCurrentAnimatorStateInfo(0);
        Animator.Play("Attack");
        if (stateInfo.normalizedTime > 0.99f&&stateInfo.IsName("Attack"))
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Running;
        }

    }
}
