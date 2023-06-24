using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniInventory : MonoBehaviour
{
    public List<string> mainInv = new List<string>();

    public void AddItem(string name)
    {
        mainInv.Add(name);
    }

    public void RemoveItem(string name)
    {
        mainInv.Remove(name);
    }

    public bool isGot(string name)
    {
        if (mainInv.Contains(name))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
