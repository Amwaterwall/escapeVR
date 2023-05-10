using UnityEngine;

public class Handgun : MonoBehaviour
{   
    public GameObject barrel;

    // public GameObject handgun;
    public GameObject trigger;
    public GameObject hitParticle;
    public GameObject shotParticle;
    public float defaultRotation = 0f;
    public float maxRotation = 30f;

    public AudioSource soundPlayer;

    public void RotateTrigger(float val)
    {
        float actualRotation = maxRotation * val;

        trigger.transform.localEulerAngles = new Vector3(defaultRotation + actualRotation, 
        trigger.transform.localEulerAngles.y, trigger.transform.localEulerAngles.z);
    }
    public void Shoot()
    {
        soundPlayer.Stop();
        soundPlayer.Play();
        GameObject muzzleFlash = Instantiate(shotParticle, barrel.transform);
        muzzleFlash.transform.SetParent(null);
        Destroy(muzzleFlash, 0.5f);
        if(Physics.Raycast(barrel.transform.position, 
        barrel.transform.forward, out RaycastHit hitData, 200f))
        {
            GameObject hitEffect = Instantiate(hitParticle);
            hitEffect.transform.position = hitData.point;
            Destroy(hitEffect, 1f);


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
