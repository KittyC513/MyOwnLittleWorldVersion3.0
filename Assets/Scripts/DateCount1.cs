using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DateCount1 : MonoBehaviour
{
    public int dayValue = 1;
    Text date;

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        date = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        date.text = "DAY " + dayValue;
    }


    public void PassADay(int value)
    {
        dayValue += value;
        date.text = "DAY " + dayValue;

    }
}
