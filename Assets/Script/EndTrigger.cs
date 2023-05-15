using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("1");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("2");
            SceneManager.LoadScene("Game_over");
        }
    }
}