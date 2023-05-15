using UnityEngine;
using Zinnia.Visual;
using TMPro;

public class Player : MonoBehaviour
{
    public float defaultHealth = 200f;
    public CameraColorOverlay hitFader;
    public CameraColorOverlay startFader;
    public int score;
    public TextMeshPro scoreText;
    public GameObject healthBar;
    public AudioSource soundPlayer;
    public AudioClip hitSound;
    public AudioClip deathSound;

    public float currentHealth;

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = score.ToString("D9");
    }

    public void ResetPlayer()
    {
        startFader.Blink();
        score = 0;
        currentHealth = defaultHealth;
        UpdateScore(0);
        healthBar.transform.localScale = Vector3.one;

        foreach(Enemy enemy in FindObjectsOfType<Enemy>())
        {
            Destroy(enemy.gameObject);
        }
    }

    public void TakeDamge(float damge)
    {
        currentHealth -= damge;

        healthBar.transform.localScale = new Vector3(Mathf.InverseLerp(0, defaultHealth, currentHealth), 1f, 1f);

        if(currentHealth > 0)
        {
            hitFader.Blink();
            soundPlayer.PlayOneShot(hitSound);
        }
        else
        {
            soundPlayer.PlayOneShot(deathSound);
            ResetPlayer();
        }
    }

    private void Start()
    {
        ResetPlayer();
    }
}

