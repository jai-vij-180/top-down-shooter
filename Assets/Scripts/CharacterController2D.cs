using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour {

    public float shootSpeed = 0.05f;
    public float speed = 5f;
    float coolDown;
     public float bulletSpeed = 5000;
    public Transform gun;
    public GameObject bulletPrefab;
    Rigidbody2D rb;
	
	void Start () {
       rb = GetComponent<Rigidbody2D>();
       //gunPoint = new Vector3(gun.transform.position.x, gun.transform.position.y, gun.transform.position.z);
    }
	
    void Update () 
     {
     
         if(Time.time >= coolDown)
         {
             if(Input.GetMouseButton(0))
             {
                 Fire();
             }
         }
     }
 
     void Fire()
     {


         GameObject bPrefab = Instantiate(bulletPrefab, gun.position, Quaternion.identity) as GameObject;

         bPrefab.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
 
         coolDown = Time.time + shootSpeed;
     }
 


    
	void FixedUpdate () {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        rb.AddForce( new Vector3( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed);
  
	}
}
