using UnityEngine;

public class Shot : MonoBehaviour
{
    // params
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float fireRate = 10f;
    [SerializeField] private float nextTimeToFire = 0;
    
    // by player
    [SerializeField] private Camera fpCam;

    // view
    [SerializeField] private ParticleSystem muzzleFlash;
    
    // with targets
    [SerializeField] private GameObject hitEffect;
    
    
    [SerializeField] private float force = 100f;

    private void Update()
    {
        if (!Input.GetButton("Fire1") || !(Time.time >= nextTimeToFire)) return;
        nextTimeToFire = Time.time * 1 / fireRate;
        
        Shoot();
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        
        RaycastHit hit; // where
        
        if (!Physics.Raycast(fpCam.transform.position, fpCam.transform.forward, out hit, range)) return;
        
        Debug.Log(hit.transform.name); // output name of target object
        
        var enemy = hit.transform.GetComponent<Enemy>(); // try object object
        if (enemy != null) enemy.TakeDamage(damage); 

        GameObject spanObject = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(spanObject, 1f);

        if (hit.rigidbody == true) hit.rigidbody.AddForce(hit.normal * -force);
    }
}
