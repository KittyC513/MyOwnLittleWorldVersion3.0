using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFunction : MonoBehaviour
{
    public GameObject laptop;
    public GameObject laptopUI;
    public GameObject sleepUI;
    public DateCount dateCount;
    //public Actionpoint actionPoint;

    public GameObject bottomBar;

    public GameObject bed;
    public Player player;


    public Vector3 target;

    public Animator animator;
    public GameObject Player;

    Vector3 laptopPos;
    Vector3 bedPos;

    public bool goSleep;
    DataCount dataCount;




    // Start is called before the first frame update
    void Start()
    {

        target = Player.transform.position; // original position

        animator = Player.GetComponent<Animator>();
        laptopPos = laptop.transform.position;
        bedPos = bed.transform.position;
        player = GetComponent<Player>();
        dataCount = GetComponent<DataCount>();




        //walls = GameObject.FindGameObjectsWithTag("Walls");
    }



    // Update is called once per frame


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // position to the mouse

        RaycastHit2D hit2d = Physics2D.GetRayIntersection(ray);

        //if mouse-left button is pressed, it will raycast a position from mouse to detect if the mouse is clicking an object
        if (Input.GetMouseButtonDown(0))
        {

            if (hit2d.collider != null && hit2d.collider.gameObject.tag == "Laptop")
            {

                target = laptopPos;
                target.z = Player.transform.position.z; // 2d dimension


            }


            if (hit2d.collider != null && hit2d.collider.gameObject.tag == "Bed")
            {

                target = bedPos;
                target.z = Player.transform.position.z; // 2d dimension
                Sleep();
               
            }
            
        }
        Move(5);
    }


    void Move(float speed)
    {
        animator.SetBool("isWalking", true);
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, target, speed * Time.deltaTime);
        if (Player.transform.position == target)
        {
            animator.SetBool("isWalking", false);
        }
    }


    void Sleep()
    {

        sleepUI.SetActive(true);
        player.sleepTime =0;
        dataCount.PassAday();

    }


    public void TurnOffSleepUI()
    {
        sleepUI.SetActive(false);
    }

    public void TurnOnSleepUI()
    {
        sleepUI.SetActive(true);
    }


}


            
        

    
    


        



