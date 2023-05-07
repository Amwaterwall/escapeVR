using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public float attackRange = 2f;
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
        soundPlayer.PlayOneShot(deathSound);
        hitParticles.SetActive(true);
        Destroy(gameObject, 4f);

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
