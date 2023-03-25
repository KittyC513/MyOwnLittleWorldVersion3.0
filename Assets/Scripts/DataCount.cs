using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataCount : MonoBehaviour
{

    public Text date;
    public int dateCount = 1;


    // Start is called before the first frame update
    void Start()
    {

        date = GetComponent<Text>();
        date.text = "DAY" + dateCount;



    }

    // Update is called once per frame
    void Update()
    {
        

    }


    public void PassAday()
    {
            dateCount += 1;
            date.text = "DAY" + dateCount;
            Debug.Log("date:" + dateCount);

    }
}
