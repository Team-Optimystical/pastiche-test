using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
  public float lifetime;

  void Start()
  {
    Destroy(gameObject, lifetime);
  }
	void FixedUpdate()
	{
		Transform t = this.GetComponent<Transform> ();
		SpriteRenderer s = this.GetComponent<SpriteRenderer> ();
		t.localScale *= 1.05f;
		s.color -= new Color (0f,0f,0f,0.05f);
	}	
}
