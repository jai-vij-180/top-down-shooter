using UnityEngine;
using System.Collections;

/// <summary>
/// Everything related to controlling the character goes here, NOTHING ELSE, unless its using the API of something else.
/// </summary>
public class CharacterController2D : MonoBehaviour
{
    [Header("Controller Settings")]
    public float FireRate = 0.05f;
    public float WalkSpeed = 5f;
    float coolDown;
    [Header("References-Manual-Please Drag")]
    public Transform BulletSpawnTransform;
    public GameObject bulletPrefab;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FireIfApplicable();
    }

    void FireIfApplicable()
    {
        
        if (Time.time >= coolDown)
        {
            if (Input.GetMouseButton(0))
            {
                SpawnBullet();

                coolDown = Time.time + FireRate;
            }
        }
    }

    private void SpawnBullet()
    {
        var NewSpawnedBullet = Instantiate(bulletPrefab, BulletSpawnTransform.position, BulletSpawnTransform.transform.rotation) as GameObject;
        NewSpawnedBullet.GetComponent<BulletController>().InitBullet(); //Activate bullets functionailty by using bullets API, after that its upto bullet to handle itself. 
    }




    void FixedUpdate()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * WalkSpeed);

    }
}
