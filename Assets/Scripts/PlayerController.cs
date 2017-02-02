using UnityEngine;

[System.Serializable]
public class Boundary
{
  public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
  public float speed;
  public Boundary boundary;

  public GameObject shot;
  public Transform shotSpawn;
  public float fireRate;
  public GameObject sprite;

  private Rigidbody rb;
  private AudioSource asrc;
  private float nextShot = 0.0f;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
    asrc = GetComponent<AudioSource>();
  }

  void Update()
  {
    if (Input.GetButton("Fire1") && Time.time > nextShot)
    {
      nextShot = Time.time + fireRate;
      Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
      asrc.Play();
    }
  }

  void FixedUpdate()
  {
    float moveHorizontal = Input.GetAxis("Horizontal");
	// negative if moving left, positive if moving right.
		if (moveHorizontal > 0) {
			sprite.GetComponent<SpriteRenderer> ().flipX = true;
		} else if (moveHorizontal < 0) {
			sprite.GetComponent<SpriteRenderer> ().flipX = false;
		}
    float moveVertical = Input.GetAxis("Vertical");
    Vector3 movement = new Vector3(moveHorizontal, 5, moveVertical);
    rb.velocity = movement * speed;

    // Prevent ship from going out of bounds.
    rb.position = new Vector3(
      Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
      0,
      Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
    );
  }
}
