using UnityEngine;
using System.Collections;



public class murderbotarmcontroller : MonoBehaviour  {

    public Animator animator;
    public GameObject arm;
    public Rigidbody2D body;
    public bool previousdirection;
    public murderbotcontroller armcontroller;
    public GameObject armcontrol;
    private Vector3 armstartposition;

    void Start()
    {
        animator.SetInteger("Direction", 4);
        armstartposition = arm.transform.position;
    }
    void Update()
    {
        arm.transform.position = armcontrol.transform.position;
        //arm straight right
        if ((Input.GetKey(KeyCode.RightArrow)) || armcontroller.armdirection == 4)
        {
            animator.SetInteger("Direction", 4);
            previousdirection = true;
        }
        
        //arm straight left
        if ((Input.GetKey(KeyCode.LeftArrow)) || armcontroller.armdirection == 5)
        {
            animator.SetInteger("Direction", 5);
            previousdirection = false;
           
        }

        //arm up and right
        if (((Input.GetKey(KeyCode.UpArrow))) && previousdirection == true)
        {
            animator.SetInteger("Direction", 3);
        }
        //arm down and right
        if (((Input.GetKey(KeyCode.DownArrow))) && previousdirection == true)
        {
            animator.SetInteger("Direction", 0);
        }
        //arm down and left
        if (((Input.GetKey(KeyCode.UpArrow))) && previousdirection == false)
        {
            animator.SetInteger("Direction", 2);
        }
        //arm down and left
        if (((Input.GetKey(KeyCode.DownArrow))) && previousdirection == false)
        {
            animator.SetInteger("Direction", 1);
        }



    }

}
