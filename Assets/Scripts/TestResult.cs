using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestResult : MonoBehaviour
{
    public int result;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = this.GetComponent<Text>();
        GenerateResult();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void GenerateResult()
    {
        result = Random.Range(65, 80);
        score.text = "Your test result is   " + result;

    }
}
