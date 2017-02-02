using UnityEngine;

public class Mover : MonoBehaviour
{
  public float speed = -5f;
	public float speedInc = -0.1f;

  private Rigidbody rb;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
    rb.velocity = transform.forward * (speed + speedInc * Time.time);
  }
}
