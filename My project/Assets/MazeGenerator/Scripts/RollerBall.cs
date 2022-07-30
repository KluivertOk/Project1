using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

//<summary>
//Ball movement controlls and simple third-person-style camera
//</summary>
public class RollerBall : MonoBehaviour {

public GameObject ViewCamera = null;
	public AudioClip JumpSound = null;
	public AudioClip CoinSound = null;
	public TextMeshProUGUI scoreText;

	private Rigidbody mRigidBody = null;
	private int score;
	private AudioSource PlayAudio = null;

	void Start()
	{
		mRigidBody = GetComponent<Rigidbody>();
		PlayAudio = GetComponent<AudioSource>();
		score = 0;
		UpdateScore(0);
		
	}

	void FixedUpdate()
	{
		if (mRigidBody != null)
		{
			if (Input.GetButton("Horizontal"))
			{
				mRigidBody.AddTorque(Vector3.back * Input.GetAxis("Horizontal") * 50);
			}
			if (Input.GetButton("Vertical"))
			{
				mRigidBody.AddTorque(Vector3.right * Input.GetAxis("Vertical") * 50);
			}
			if (Input.GetButtonDown("Jump"))
			{
				{
					PlayAudio.PlayOneShot(JumpSound);
				}
				mRigidBody.AddForce(Vector3.up * 50);
			}

		}
		if (ViewCamera != null)
		{
			Vector3 direction = (Vector3.up * 2 + Vector3.back) * 2;
			RaycastHit hit;
			Debug.DrawLine(transform.position, transform.position + direction, Color.red);
			if (Physics.Linecast(transform.position, transform.position + direction, out hit))
			{
				ViewCamera.transform.position = hit.point;
			}
			else
			{
				ViewCamera.transform.position = transform.position + direction;
			}
			ViewCamera.transform.LookAt(transform.position);
		}
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Coin"))
		{
			PlayAudio.PlayOneShot(CoinSound, 1.0f);
			Destroy(other.gameObject);
			UpdateScore(1);
		}
	}

	void UpdateScore(int scoreAdd)
	{
		score += scoreAdd;
		scoreText.text = "Score: " + score;
	}

}
