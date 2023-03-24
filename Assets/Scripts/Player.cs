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

    public bool goToSleep;

    public DataCount dataCount;
    public GameObject sleepUI;

    private void Start()
    {
        curValue = testResult.result;
        mentalHealth.SetValue(curValue);
        value = curValue;
        dataCount = GetComponent<DataCount>();


    }

    private void Update()
    {
        if (goToSleep && dataCount!=null)
        {
            dataCount.PassOneDAY();
            sleepUI.SetActive(false);
            goToSleep = false;

        }
    }


    public void AddMentalHealth(double amount)
    {

        value += (int)amount;

        mentalHealth.SetValue(value);

    }

    public void DidSleep(bool i)
    {
        goToSleep = i;

    }


    public void MinusMentalHealth(double amount)
    {

        value -= (int)amount;

        mentalHealth.SetValue(value);
        Debug.Log(value);
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
        Lua.RegisterFunction(nameof(DidSleep), this, SymbolExtensions.GetMethodInfo(() => DidSleep((bool)false)));
    }

    void OnDisable()
    {
        // Remove the functions from Lua: (Replace these lines with your own.)
        Lua.UnregisterFunction(nameof(didCorrect));
        Lua.UnregisterFunction(nameof(AddMentalHealth));
        Lua.UnregisterFunction(nameof(MinusMentalHealth));
        Lua.UnregisterFunction(nameof(DidSleep));
    }



}
