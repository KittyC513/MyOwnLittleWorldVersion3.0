using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

  

    //public float speed; //character move speed


    //private bool isWalking = false;


  
    //public Actionpoint actionPoint;

    //bool hitBoundary = false;
    //GameObject[] walls;


    // Start is called before the first frame update
    void Start()
    {


      




    }


  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)|| Input.GetMouseButton(1))
        {
          

        }
        //Move(5);
        
    }

   





    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag==("Walls"))
        {
            hitBoundary = true;
            Move(0);;
            animator.SetBool("isWalking", false);
        }
        else
        {
            hitBoundary = false;
        }
        
    }*/
}
