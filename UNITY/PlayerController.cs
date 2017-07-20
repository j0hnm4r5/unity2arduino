using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  // create public variables accessible via the inspector
  public GameObject bulletPrefab;
  public Transform bulletSpawn;


  void Update()
  {

    // move the player with the Arrow Keys
    var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
    var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

    transform.Rotate(0, x, 0);
    transform.Translate(0, 0, z);

    // shoot with the Space Bar
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Fire();
    }

  }

  void Fire()
  {
    // Create the Bullet from the Bullet Prefab
    var bullet = (GameObject)Instantiate(
      bulletPrefab,
      bulletSpawn.position,
      bulletSpawn.rotation
    );

    // Add velocity to the bullet
    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

    // Destroy the bullet after 2 seconds
    Destroy(bullet, 2.0f);
  }
}
