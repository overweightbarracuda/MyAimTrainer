using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gunScript : MonoBehaviour
{
    private float range = 50f;
    private LineRenderer bullet;
    private Vector3 origin;
    private Vector3 endPoint;
    public float maxBulletSpread = 15.0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        bullet = this.gameObject.AddComponent<LineRenderer>();
        bullet.startWidth = 0.2f;
        bullet.endWidth = 0.2f;
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            //Debug.Log("Fire button was pressed");
            StartCoroutine("FireButtonPressed");
        }
        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            //Debug.Log("Fire button was released");
            StopCoroutine("FireButtonPressed");
        }
    }
    IEnumerator FireButtonPressed() 
    {
        while (true) {
            fire();
            StartCoroutine("laserBeam");
            yield return new WaitForSeconds(0.5f);
        }
    }
    void fire()
    {
        //Debug.Log("Fire() " + Time.timeSinceLevelLoad);
        RaycastHit hit;
        Vector3 fireDirection = transform.forward;

        Quaternion fireRotation = Quaternion.LookRotation(fireDirection);

        Quaternion randomRotation = Random.rotation;

        fireRotation = Quaternion.RotateTowards(fireRotation, randomRotation, Random.Range(0.0f, maxBulletSpread));

        Ray ray = new Ray(this.transform.position, fireRotation*Vector3.forward);

        if(Physics.Raycast(ray, out hit, range))
        {
            if(hit.collider.tag == "Enemy")
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                enemy.health -= 50;
                Debug.Log("enemy hit");
            }
        }
    }
    IEnumerator laserBeam()
    {
        //Debug.Log("LaserBeam() " + Time.timeSinceLevelLoad);
        Vector3 laserDirection = transform.forward;

        Quaternion laserRotation = Quaternion.LookRotation(laserDirection);

        Quaternion randomRotation = Random.rotation;


        laserRotation = Quaternion.RotateTowards(laserRotation, randomRotation, Random.Range(0.0f, maxBulletSpread));
        origin = this.transform.position +this.transform.forward * 0.5f;
        bullet.SetPosition(0, origin);
        endPoint = origin + (laserRotation*Vector3.forward) * range * this.transform.lossyScale.z;
        bullet.SetPosition(1, endPoint);
        bullet.enabled = true;
        yield return new WaitForSeconds(0.1f);
        bullet.enabled = false;

    }
}
