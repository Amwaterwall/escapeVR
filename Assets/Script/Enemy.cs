using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public float attackRange = 1.8f;

    private GameObject target;

    public void Kill()
    {
        animator.SetBool("Dying", true);
        Invoke("DestoryMe", 4f);
    }

    private void DestoryMe()
    {
        Object.Destroy(gameObject);
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        agent.updatePosition = false;
    }

    private void Update()
    {
        bool shouldMove = !animator.GetBool("Dying") && Vector3.Distance(transform.position, target.transform.position) > attackRange;

        animator.SetBool("Moving", shouldMove);
        animator.SetBool("Attacking", !shouldMove);
        agent.destination = shouldMove ? target.transform.position : transform.position;
    }

    private void OnAnimatorMove()
    {
        transform.position = agent.nextPosition;
    }
}
