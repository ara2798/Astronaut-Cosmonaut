using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    private bool onClick;
    public float rayLength = 5.0f;
    Vector3 mouseVector;
    Vector3 rayDirection;
    LineRenderer aimRay;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        aimRay = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                onClick = true;
                aimRay.enabled = true;
            }
            if (onClick)
            {
                aimRay.SetPosition(0, transform.position);
                mouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseVector.z = 0.0f;
                rayDirection = transform.position - mouseVector;
                rayDirection.Normalize();
                rayDirection *= rayLength;
                aimRay.SetPosition(1, transform.position + rayDirection);
            }
            if (Input.GetMouseButtonUp(0))
            {
                onClick = false;
                aimRay.enabled = false;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet bulletScript = bulletObject.GetComponent<Bullet>();
        bulletScript.Launch(rayDirection, 200);
    }

}
