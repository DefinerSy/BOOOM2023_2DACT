using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Move : EnemyAction
{
    public GameObject patrolPoint;
    public float patrolSpeed;
    private Collider2D collider2D;
    public SharedBool isTouchingPlayer=false;
    
     public override void OnAwake()
    {
        base.OnAwake();
        collider2D = gameObject.GetComponentInChildren<Collider2D>();
    }
    public override void OnStart()
    {
        Animator.Play("Walk");
        isTouchingPlayer=false;
    }
    

    public override TaskStatus OnUpdate()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position,
            patrolPoint.transform.position, patrolSpeed * Time.deltaTime);
        if(isTouchingPlayer.Value)
        {
            return TaskStatus.Failure;
        }
        if(Vector2.Distance(gameObject.transform.position, patrolPoint.transform.position) < 0.1f)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Running;
        }
        
    }
    
    public override void OnEnd()
    {
        //Animator.Play("Turn");
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isTouchingPlayer = true;
        }
    }
}
