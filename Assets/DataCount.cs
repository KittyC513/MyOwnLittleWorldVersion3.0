using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataCount : MonoBehaviour
{
    int curDate = 1;
    Text date;
    public int dateCount = 1;
    ClickFunction clickFunction;
    // Start is called before the first frame update
    void Start()
    {
        date = GetComponent<Text>();
        clickFunction = GetComponent<ClickFunction>();
        
        date.text = "DAY" + dateCount;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PassOneDAY()
    {
        if (clickFunction.goSleep)
        {
            clickFunction.goSleep = false;
            dateCount += 1;
            date.text = "DAY" + dateCount;
        }
    }
}
