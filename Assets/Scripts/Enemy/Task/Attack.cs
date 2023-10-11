using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class Attack : EnemyAction
{
    private AnimatorStateInfo stateInfo;
    
    public override void OnStart()
    {
        base.OnStart();
        Animator.SetBool("isAttack",true);
    }
    public override TaskStatus OnUpdate()
    {
        stateInfo = Animator.GetCurrentAnimatorStateInfo(0);
        Animator.Play("Attack");
        if (stateInfo.normalizedTime > 0.99f&&stateInfo.IsName("Attack"))
        {
            return TaskStatus.Success;
        }
        if(stateInfo.IsName("Hurt"))
        {
            return TaskStatus.Running;
        }

        return TaskStatus.Running;

    }
    
    public override void OnEnd()
    {
        Animator.SetBool("isAttack",false);
    }
}
