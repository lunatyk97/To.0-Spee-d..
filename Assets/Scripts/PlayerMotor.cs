using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMotor : MonoBehaviour
{
    public GameObject FireObject;
    
    private CharacterController controller;
    private Vector3 moveVector;

    public float baseSpeed = 5.0f;
    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private float animationDuration = 3.0f;
    private float startTime;

    private bool isDead = false;
  

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GamePause>().setUnPause();
        Cursor.visible = false;
        animationDuration = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMotor>().ShowAnimationDuration();
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
        FireObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        if(Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * baseSpeed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        //X - prawo lewo
        moveVector.x = Input.GetAxis("Horizontal") * speed * 0.7f;

        //Y - gora dol
        moveVector.y = verticalVelocity;

        //Z - przod tyl
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }

    public void SetSpeed(float modifier)
    {
        //speed += modifier;
        //speed += Mathf.Pow(-(10 / (modifier)), 2) / 20;
        speed = baseSpeed * 2f + (-(1 / modifier) * 10) + modifier / 5;
        Debug.Log("speed " + speed);
    }

    //obsługa kolizji
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if (hit.point.z > transform.position.z + (controller.radius / 2)) //dzielenie usprawnia kolizje
        // controller.radius może być zastąpione przez 0.1
        if(hit.point.z > transform.position.z + 0.1 && hit.gameObject.tag == "Killer")
        {
            Death();
        }

        if (hit.point.z > transform.position.z + 0.1 && hit.gameObject.tag == "Killer")
        {
            Death();
        }


        if (hit.gameObject.tag == "WallKiller")
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("dead");
        isDead = true;
        FireObject.SetActive(true);
        GetComponent<Score>().OnDeath();
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GamePause>().setDeath();
        Cursor.visible = true;
    }

}
