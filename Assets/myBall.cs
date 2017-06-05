using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myBall : MonoBehaviour {

	AudioSource audio;
	private Rigidbody rb;
	public float speed;
	private Vector3 lastV;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3 (Random.value, Random.value, Random.value) * speed;
		lastV = rb.velocity;
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = rb.velocity;
		rb.velocity = v / v.magnitude * speed;
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("collision enter");
		Vector3 v = lastV;
//		print ("velocity = " + v);
		Vector3 n, p;
		foreach (ContactPoint contact in collision.contacts)
		{
			Debug.DrawRay(contact.point, contact.normal, Color.white);

			n = contact.normal;
			p = contact.point;

//			print ("contact normal = " + n);
//			print ("contact point = " + p);


			Vector3 s = -Vector3.Dot (v, n) / n.sqrMagnitude * n;
//			print (" v = " + v);
//			print (" s = " + s);

			Vector3 q = v + s;
//			print (" q = " + q);

			Vector3 r = 2 * q - v;
//			print (" r = " + r);
			rb.velocity = r;
			lastV = rb.velocity;
		}

		if (collision.gameObject.CompareTag ("Player")) {
//			print ("Player Hit");
			collision.gameObject.GetComponent<PlayerHit>().Hit();
		}

		if (collision.relativeVelocity.magnitude > 2)
			audio.Play();
	}
}
