using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt; //trzymanie sie gracza
    private Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    public float AnimationDuration = 3.0f; // czas trwania animacji na wstepie
    private Vector3 animationOffset = new Vector3(0, 5, 5);

    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position; // roznica miedzy graczem a kamera
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = lookAt.position + startOffset;

        //X
        moveVector.x = 0;

        //Y
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

        if (transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            //Animacja początkowa
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / AnimationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }

    }

    public float ShowAnimationDuration()
    {
        return AnimationDuration;
    }

}
