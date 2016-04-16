using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{

    public float movSpeed = 8.0f;
    public float mouseSensitivity = 5.0f;
    public float upDownRange = 60.0f;
    private float verticalRoation = 0;
    private float verticalVelocity = 0;
    public float jumpSpeed = 5;
    private CharacterController cc;
    private float playerHealth = 100f;
    private float dotDamage = 0f;
    public Text countText;
    public Text enemyText;
    private bool flag = false;
    private bool playing = true;

	// Use this for initialization
	void Start ()
	{
	    Cursor.visible = false;
        cc = GetComponent<CharacterController>();
        SetCountText();
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
    void Update()
    {
        Debug.Log(GameObject.FindGameObjectsWithTag("Dujman").Length);
        if (GameObject.FindGameObjectsWithTag("Dujman").Length == 0)
        {
            playing = false;
            gameManager.TriggerNextLevel();

        }
        if(playing)
        {
            enemyText.text = "Enemies: "+GameObject.FindGameObjectsWithTag("Dujman").Length;
            if (playerHealth > 100)
            {
                playerHealth -= Time.deltaTime*8;
                if (playerHealth < 100)
                    playerHealth = 100;
                SetCountText();
            }
            if (dotDamage > 0)
            {
                dotDamage -= Time.deltaTime*5;
                playerHealth -= Time.deltaTime*5;
                SetCountText();
            }
            if (flag)
            {
                playerHealth -= Time.deltaTime;
                SetCountText();
            }
            float rotationLeftRight = Input.GetAxis("Mouse X")*mouseSensitivity;
            transform.Rotate(0, rotationLeftRight, 0);

            verticalRoation -= Input.GetAxis("Mouse Y")*mouseSensitivity;
            verticalRoation = Mathf.Clamp(verticalRoation, -upDownRange, upDownRange);
            Camera.main.transform.localRotation = Quaternion.Euler(verticalRoation, 0, 0);

            //Movement

            verticalVelocity += Physics.gravity.y*Time.deltaTime;
            float forwardSpeed = Input.GetAxis("Vertical")*movSpeed;
            float sideSpeed = Input.GetAxis("Horizontal")*movSpeed;


            Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

            speed = transform.rotation*speed;
            if (Input.GetButtonDown("Jump") && cc.isGrounded)
            {
                verticalVelocity = jumpSpeed;
            }
            cc.Move(speed*Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.tag == "Dujman")
        {
            playerHealth -= 30;
            dotDamage = 25;
            flag = true;
        }
        SetCountText();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PickUp")
        {
            playerHealth += 40;
            flag = false;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Health: " + Mathf.Ceil(playerHealth);
        if (playerHealth <= 0)
        {
            countText.text = "DEAD";
            playing = false;
            gameManager.TriggerGameOver(false);
        }
    }
}
