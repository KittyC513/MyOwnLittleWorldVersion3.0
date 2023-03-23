using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;


public class Player : MonoBehaviour
{
    public string mentalStates = "normal";
    public int value;

    public bool didCorrect(string makingSelection)
    {
        return mentalStates == makingSelection;
    }


    public void AddMentalHealth(double amount)
    {
        value += (int)amount;
    }


    void OnEnable()
    {
        // Make the functions available to Lua: (Replace these lines with your own.)
        Lua.RegisterFunction(nameof(didCorrect), this, SymbolExtensions.GetMethodInfo(() => didCorrect(string.Empty)));
        Lua.RegisterFunction(nameof(AddMentalHealth), this, SymbolExtensions.GetMethodInfo(() => AddMentalHealth((double)0)));
    }

    void OnDisable()
    {
        // Remove the functions from Lua: (Replace these lines with your own.)
        Lua.UnregisterFunction(nameof(didCorrect));
        Lua.UnregisterFunction(nameof(AddMentalHealth));
    }

}
