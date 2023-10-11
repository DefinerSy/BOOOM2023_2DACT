using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Move : EnemyAction
{
    public GameObject patrolPoint;
    public float moveSpeed;
    private Collider2D collider2D;
    public float distance=0.1f;
    //public SharedBool isFoundPlayer=false;
    private AnimatorStateInfo stateInfo;
     public override void OnAwake()
    {
        base.OnAwake();
        collider2D = gameObject.GetComponentInChildren<Collider2D>();
    }
    public override void OnStart()
    {
        Animator.Play("Walk");
    }
    

    public override TaskStatus OnUpdate()
    {
        var position = gameObject.transform.position;
        var transformPosition = new Vector2(patrolPoint.transform.position.x,gameObject.transform.position.y);
        stateInfo=Animator.GetCurrentAnimatorStateInfo(0);
        if (((transformPosition.x > transform.position.x&&transform.localScale.x>0)||(transformPosition.x<transform.position.x&&transform.localScale.x<0))&&!stateInfo.IsName("Turn"))
        {
            Animator.Play("Turn");
        }

        if (stateInfo.IsName("Turn")&&stateInfo.normalizedTime<=0.99f)
        {
            return TaskStatus.Running;
        }
        if(stateInfo.normalizedTime>0.99f&&stateInfo.IsName("Turn"))
        {
            transform.localScale = transformPosition.x > transform.position.x ? 
                new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
            Animator.Play("Walk");
        }
        position = Vector2.MoveTowards(position,
            transformPosition, moveSpeed * Time.deltaTime);
        gameObject.transform.position = position;
        return Vector2.Distance(position, transformPosition) < distance ? TaskStatus.Success : TaskStatus.Running;
        
    }
    
}
