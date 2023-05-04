using UnityEngine;

public class Handgun : MonoBehaviour
{   
    public GameObject barrel;

    // public GameObject handgun;
    public GameObject trigger;
    public float defaultRotation = 0f;
    public float maxRotation = 30f;

    public void RotateTrigger(float val)
    {
        float actualRotation = maxRotation * val;

        trigger.transform.localEulerAngles = new Vector3(defaultRotation + actualRotation, 
        trigger.transform.localEulerAngles.y, trigger.transform.localEulerAngles.z);
    }
    public void Shoot()
    {
        if(Physics.Raycast(barrel.transform.position, 
        barrel.transform.forward, out RaycastHit hitData, 100f))
        {
            Enemy hitEnemy = hitData.transform.GetComponent<Enemy>();
            
            //if(hitData.transform.tag == "Enemy")
            if(hitEnemy != null)
            {
                // Destroy(hitData.transform.gameObject);
                hitEnemy.Kill();
            }
        }
    }
}
