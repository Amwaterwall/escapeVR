using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public float attackRange = 1.5f;
    public AudioSource soundPlayer;
    public AudioClip deathSound;
    public AudioClip attackSound;
    public AudioClip[] breathSounds;
    public GameObject hitParticles;

    private Player target;

    public void Kill()
    {
        GetComponent<Collider>().enabled = false;
        target.UpdateScore(1);
        animator.SetBool("Dying", true);
        Destroy(gameObject, 4f);
        soundPlayer.PlayOneShot(deathSound);
        hitParticles.SetActive(true);
        

    }

    public void breath()
    {
        int soundIndex = Random.Range(0, breathSounds.Length * 3);
        if (soundIndex < breathSounds.Length)
        {
            soundPlayer.PlayOneShot(breathSounds[soundIndex]);
        }
    }

    public void Attack()
    {
        soundPlayer.PlayOneShot(attackSound);
    }

    public void Hit()
    {
        target.TakeDamge(10f);
        //soundPlayer.PlayOneShot(attackSound);
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
