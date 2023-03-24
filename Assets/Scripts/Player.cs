using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;


public class Player : MonoBehaviour
{
    public string mentalStates = "normal";
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


    private void Start()
    {
        curValue = testResult.result;
        mentalHealth.SetValue(curValue);
        value = curValue;
        dataCount = GetComponent<DataCount>();


    }

    private void Update()
    {
        if(endings == 1 && curValue >=80)
        {
            ending1.SetActive(true);
            UIs.SetActive(false);
        }

        if (endings == 2 || endings == 3)
        {
            if (curValue < 70 && curValue >= 50)
            {
                ending2.SetActive(true);
                UIs.SetActive(false);
            }

        }

        if (endings == 3 && curValue >=80)
        {
            ending3.SetActive(true);
            UIs.SetActive(false);
        }

        if (endings == 4 && curValue < 50)
        {
            ending4.SetActive(true);
            UIs.SetActive(false);
        }

    }


    public void AddMentalHealth(double amount)
    {

        value += (int)amount;

        mentalHealth.SetValue(value);
        value = curValue;

    }

    public void Endings(double amount)
    {
        endings += (int)amount;
    }

    public void DidSleep(double amount)
    {
        sleepTime += (int)amount;

    }


    public void MinusMentalHealth(double amount)
    {

        value -= (int)amount;

        mentalHealth.SetValue(value);
        value = curValue;

    }
    public bool didCorrect(string makingSelection)
    {
        return mentalStates == makingSelection;
    }
    void OnEnable()
    {
        // Make the functions available to Lua: (Replace these lines with your own.)
        Lua.RegisterFunction(nameof(didCorrect), this, SymbolExtensions.GetMethodInfo(() => didCorrect(string.Empty)));
        Lua.RegisterFunction(nameof(AddMentalHealth), this, SymbolExtensions.GetMethodInfo(() => AddMentalHealth((double)0)));
        Lua.RegisterFunction(nameof(MinusMentalHealth), this, SymbolExtensions.GetMethodInfo(() => MinusMentalHealth((double)0)));
        Lua.RegisterFunction(nameof(DidSleep), this, SymbolExtensions.GetMethodInfo(() => DidSleep((double)0)));
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
