using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]

public class csPlayerCtrl : MonoBehaviour
{

    public float moveSpeed;
    public float jumpSpeed;
    public float gravity = 9.8f;
    private Transform PlayerTransform;
    public Transform CameraTransform;


    private CharacterController controller;
    private Animator anim;

    private Vector3 moveDirection = Vector3.zero;
    private float h;
    private float v;


    void Start()
    {
        PlayerTransform = this.transform;
        CameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        
        StartCoroutine("MoveRoutine");
        StartCoroutine("RotationRoutine");
        StartCoroutine("AnimRoutine");
    }

    void Update()
    {

    }




    IEnumerator RotationRoutine()
    {
        while(true)
        {
            if(h != 0 || v != 0)
            {
                Vector3 rotDirection = new Vector3(h, 0, v);
                PlayerTransform.rotation = Quaternion.LookRotation(CameraTransform.rotation * rotDirection);
            }

            yield return null;
        }
    }

    IEnumerator MoveRoutine()
    {
        while (true)
        {
            if (controller.isGrounded)
            {
            
                h = Input.GetAxis("Horizontal");
                v = Input.GetAxis("Vertical");

                moveDirection = new Vector3(h, 0, v);
                moveDirection = CameraTransform.rotation * moveDirection * moveSpeed;

                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                }

            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
 

            yield return null;
        }
    }


    IEnumerator AnimRoutine()
    {
        while (true)
        {
            Vector3 moveValue = new Vector3(h, 0, v);
            float KeyValue = moveValue.sqrMagnitude;
            

            if (KeyValue != 0)
            {
                anim.SetFloat("Walk", 0.3f);
            }
            else
            {
                anim.SetFloat("Walk", 0f);
            }
  
            yield return null;
        }
    }
}

