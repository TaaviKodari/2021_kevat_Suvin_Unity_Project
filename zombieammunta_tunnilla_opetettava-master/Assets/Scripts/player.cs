using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float nopeus = 5.0f;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    private float vertikaalinenPyorinta = 0;
    private float horisontaalinenPyorinta = 0;
    private float xRotation = 0f;

    public float hyppyvoima = 0f;
    public float painovoima = 0f;


    private bool isGrounded = true;

    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance,groundMask);
        
        CharacterController hahmokontrolleri = GetComponent<CharacterController>();
        float horizontal = Input.GetAxis("Horizontal") * 5;
        float vertical = Input.GetAxis("Vertical") * 5;
        Vector3 nopeus = new Vector3(horizontal, 0, vertical);

        horisontaalinenPyorinta += Input.GetAxis("Mouse X") * 3;

        transform.localRotation = Quaternion.Euler(0, horisontaalinenPyorinta, 0);

        nopeus = transform.rotation * nopeus;

        //nopeus.y = nopeus.y - painovoima * Time.deltaTime;

        nopeus.y = nopeus.y - painovoima * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("hyppy");

            nopeus.y = nopeus.y + hyppyvoima;
            anim.SetBool("jumpf", true);
           
        }
        else
        {
            anim.SetBool("jumpf", false);
        }
        hahmokontrolleri.Move(nopeus);
      



        if (Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

       
    }


//     void OnCollisionStay()
//    {
//         isGrounded = true;
//    }   

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position,groundDistance);
    }

}


        


