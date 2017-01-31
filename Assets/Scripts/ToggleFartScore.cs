using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleFartScore : MonoBehaviour {

	public GameObject fartSprite;
	public GameObject fartScore;
	public GameObject fartText;
	public GameObject background;
	public AudioClip fart1;
	public AudioClip fart2;

	private int delay;
	private float startTime;
	private float endTime;
	private bool waiting;
	private float fartShowTimeStart;
	private bool fartShowing;

	private int fartLength = 2;

	// Use this for initialization
	void Start () {
		waiting = false;
		startTime = Time.time;
		hideFart ();
		fartShowing = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (!waiting) {
			delay = Random.Range (3, 8);
			endTime = startTime + delay;
			waiting = true;

		} else { // if we are waiting, compare time
			if (Time.time >= endTime) {
				// show the score
				showFart ();
				fartShowing = true;

				playFartSound ();

				fartShowTimeStart = Time.time;
				startTime = endTime + fartLength;
				waiting = false;
			}

			if (fartShowing) {
				if (Time.time >= fartShowTimeStart + fartLength) {
					hideFart ();
					fartShowing = false;
				}
			}
		
		}
		
	}

	void hideFart() {
		fartSprite.GetComponent<SpriteRenderer> ().enabled = false;
		fartScore.GetComponent<Text> ().enabled = false;
		fartText.GetComponent<Text> ().enabled = false;
	}
		
	void showFart() {
		fartSprite.GetComponent<SpriteRenderer> ().enabled = true;
		fartScore.GetComponent<Text> ().enabled = true;
		fartText.GetComponent<Text> ().enabled = true;
	}

	void playFartSound() {
		int whichToPlay = Random.Range (1, 3);
		AudioSource source = background.GetComponent<AudioSource> ();
		if (whichToPlay == 1) {
			source.clip = fart1;
		} else {
			source.clip = fart2;
		}
		source.Play ();
	}
}
