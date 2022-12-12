using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer_Window : MonoBehaviour
{
    public List<string> Orders_Name = new List<string>();
    public List<int> Orders_Price = new List<int>();
    public int Bank_Balance;
    
    void Start()
    {

    }

    public void AddOrder(string name, int price)
    {
        Orders_Name.Add(name);
        Orders_Price.Add(price);
        for(var i = 0; i < Orders_Name.Count; i ++)
        {
            Debug.Log("Key = {0}, Value = {1}"+Orders_Name[i]+Orders_Price[i]);
        }
    }

    public void RemoveOrder(string name)
    {
        int index = Orders_Name.FindIndex(a => a.Contains(name));
        Bank_Balance += Orders_Price[index];
        Orders_Name.RemoveAt(index);
        Orders_Price.RemoveAt(index);
    }

    void Update()
    {

    }
}
