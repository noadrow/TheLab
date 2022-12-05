using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DictionaryDrawer;
//using SerializableDictionary;

//public class CustomDictionary : SerializableDictionary<string, int> { }
public class Computer_Window : MonoBehaviour
{
    
    //public IDictionary<string,int> Orders = new Dictionary<string,int>();    
    //public CustomDictionary Orders = new CustomDictionary();
    public int Bank;
    
    void Start()
    {
        AddOrder("LB",1);

    }

    public void AddOrder(string order_name, int price)
    {
        Orders.Add(new KeyValuePair<string,int>(order_name,price));
        foreach (KeyValuePair<string,int> order in Orders)
        {
            Debug.Log("Key = {0}, Value = {1}"+order.Key+order.Value);
        }  
    }

    public void RemoveOrder(string order_name)
    {
        Orders.Remove(order_name);
        Bank += Orders[order_name];
    }

    void Update()
    {

    }
}
