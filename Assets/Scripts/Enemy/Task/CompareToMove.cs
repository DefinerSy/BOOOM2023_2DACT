using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CompareToMove :EnemyAction
{
    public GameObject target;
    public SharedFloat distance;
    public float maxDistance;
    public float moveSpeed;
    
    public override void OnStart()
    {
        Animator.Play("Walk");
    }

    public override TaskStatus OnUpdate()
    {
        if(Vector2.Distance(transform.position, target.transform.position) > maxDistance)
        {
            return TaskStatus.Failure;
        }

        if (Vector2.Distance(transform.position,target.transform.position)<distance.Value)
        {
            return TaskStatus.Success;
        }
        transform.localScale = target.transform.position.x > transform.position.x ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
        gameObject.transform.position = Vector2.MoveTowards(transform.position,
            new Vector2(target.transform.position.x,transform.position.y), moveSpeed * Time.deltaTime);
        return TaskStatus.Running;
    }
    
    
}
