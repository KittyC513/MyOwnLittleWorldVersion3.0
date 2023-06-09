using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public string mentalStates = "normal";
    public string endStates = "normal";
    public int value;

    public MentalHealthBar mentalHealth;
    public TestResult testResult;

    public int maxValue;
    public int curValue;
    public int sleepTime;

    public int endings;


    public DataCount dataCount;
    public GameObject sleepUI;

    public GameObject ending1;
    public GameObject ending2;
    public GameObject ending3;
    public GameObject ending4;
    public GameObject UIs;

    public GameObject increased;
    public GameObject descreased;

    AudioSource increasing;
    AudioSource decreasing;


    private void Start()
    {
        curValue = testResult.result;
        mentalHealth.SetValue(curValue);
        value = curValue;
        dataCount = GetComponent<DataCount>();

        increasing = increased.GetComponent<AudioSource>();
        decreasing = descreased.GetComponent<AudioSource>();


    }

    private void Update()
    {
        if(endings == 1 && curValue >= 80)
        {
            SceneManager.LoadScene(1);
        }

        if (endings == 1 || endings == 2)
        {
            if (curValue < 80 && curValue >= 50)
            {
                SceneManager.LoadScene(2);
            }

        }

        if (endings == 2 && curValue >=80)
        {
            SceneManager.LoadScene(3);
        }

        if (endings == 1 || endings == 2)
        {
            if(curValue < 50)
            {
                SceneManager.LoadScene(4);
            }

        }

    }


    public void AddMentalHealth(double amount)
    {

        value += (int)amount;

        mentalHealth.SetValue(value);
        curValue = value;
        Debug.Log("curValue =" + curValue);
        increasing.Play();

    }

    public void Endings(double amount)
    {
        endings += (int)amount;
        Debug.Log("2");
        Debug.Log("curvalue ="+curValue);


    }

    public void DidSleep(double amount)
    {
        sleepTime += (int)amount;

    }


    public void MinusMentalHealth(double amount)
    {

        value -= (int)amount;

        mentalHealth.SetValue(value);
        curValue = value;
        Debug.Log("curValue = " + curValue);
        decreasing.Play();

    }
    public bool didCorrect(string makingSelection)
    {
        return mentalStates == makingSelection;
    }

    public bool ReachEnd(string endSelection)
    {
        return endStates == endSelection;
    }
    void OnEnable()
    {
        // Make the functions available to Lua: (Replace these lines with your own.)
        Lua.RegisterFunction(nameof(didCorrect), this, SymbolExtensions.GetMethodInfo(() => didCorrect(string.Empty)));
        Lua.RegisterFunction(nameof(AddMentalHealth), this, SymbolExtensions.GetMethodInfo(() => AddMentalHealth((double)0)));
        Lua.RegisterFunction(nameof(MinusMentalHealth), this, SymbolExtensions.GetMethodInfo(() => MinusMentalHealth((double)0)));
        Lua.RegisterFunction(nameof(DidSleep), this, SymbolExtensions.GetMethodInfo(() => DidSleep((double)0)));

        Lua.RegisterFunction(nameof(ReachEnd), this, SymbolExtensions.GetMethodInfo(() => ReachEnd(string.Empty)));
        Lua.RegisterFunction(nameof(Endings), this, SymbolExtensions.GetMethodInfo(() => Endings((double)0)));
    }

    void OnDisable()
    {
        // Remove the functions from Lua: (Replace these lines with your own.)
        Lua.UnregisterFunction(nameof(didCorrect));
        Lua.UnregisterFunction(nameof(AddMentalHealth));
        Lua.UnregisterFunction(nameof(MinusMentalHealth));
        Lua.UnregisterFunction(nameof(DidSleep));
        Lua.UnregisterFunction(nameof(Endings));
    }



}
