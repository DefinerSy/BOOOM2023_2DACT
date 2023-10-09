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
        var position1 = patrolPoint.transform.position;
        transform.localScale = position1.x > transform.position.x ? 
            new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
        position = Vector2.MoveTowards(position,
            position1, moveSpeed * Time.deltaTime);
        gameObject.transform.position = position;
        // if(isFoundPlayer.Value)
        // {
        //     return TaskStatus.Failure;
        // }
        return Vector2.Distance(position, position1) < distance ? TaskStatus.Success : TaskStatus.Running;
        
    }
    
}
