using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject bulletSpawnPoint;
    public bool canFire;
    public float rateOfFire;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawnPoint = transform.GetChild(0).gameObject;
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        fireShot();
    }

    public void fireShot()
    {
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            StartCoroutine(FireRate());
        }
         
        IEnumerator FireRate()
        {
            canFire = false;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            yield return new WaitForSeconds(rateOfFire);
            canFire = true;
        }
            
    }
}
