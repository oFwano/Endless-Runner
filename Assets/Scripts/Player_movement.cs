using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_movement : MonoBehaviour {

	public Animator animator;
	
	public float jumpHeight = 2.5f;
	public float speed = 5.0f;
	public int health = 3;
	public int score;

	public static bool isJumping = false;
	public static bool isCrouching = false;
	
	public Text healthDisplay;
	public Text scoreDisplay;

	public GameObject gameOver;

	private Vector3 scaleChange = new Vector3(0.0f, 1.41f, 0.0f);
	private Vector3 posChange = new Vector3(0.0f, 0.40f, 0.0f);

	private float time_elapsed;


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Ground")
		{
			isJumping = false;
			animator.SetBool("jump", false);

		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.tag == "Ground")
		{
			isJumping = true;
			animator.SetBool("jump", true);

		}
	}

	// Update is called once per frame
	void Update () {
		// animator.SetBool("jump", Input.GetKey("up") || Input.GetKey("space"));

		healthDisplay.text = health.ToString();
		scoreDisplay.text = score.ToString();
		if (health <= 0)
        {
			Input.ResetInputAxes();
			gameOver.SetActive(true);
			Destroy(gameObject);

		}
		
		
		Vector3 vertical = new Vector3(0.0f, 3f, 0.0f);
		Vector3 horizontal = new Vector3(speed, 0.0f, 0.0f);


		if (Input.GetButtonDown("Jump") && isJumping == false && isCrouching == false)
        {
			//animator.SetBool("jump", true);
			Debug.Log("Jump");
			transform.position = transform.position + vertical;
			gameObject.GetComponent<Rigidbody2D>().AddForce(vertical, ForceMode2D.Impulse);
		}


		if (Input.GetKey(KeyCode.DownArrow) && isJumping == false && isCrouching == false)
		{
			isCrouching = true;
			Debug.Log("Crouch down");
			transform.localScale -= scaleChange;
			transform.position -= posChange;


		}

		if (Input.GetKey(KeyCode.DownArrow) == false && isCrouching == true)
		{
			
			Debug.Log("Crouch Up");
			transform.localScale += scaleChange;
			transform.position += posChange;
			isCrouching = false;
		}


		if (time_elapsed <= 0)
		{
			time_elapsed = 0.75f;
			score += 10;
		}

		else
		{
			time_elapsed -= Time.deltaTime;
		}

	}



}
 