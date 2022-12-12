using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class deliver : MonoBehaviour
{
    public string inventory_has = "";
    public GameObject collisioned;
    public GameObject computer_window;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Draggable")
        {
            Inventory Collision_Inventory = collision.gameObject.GetComponent<Inventory>();
            string Collision_has = Collision_Inventory.inventory_has;
            inventory_has = Collision_Inventory.inventory_has;
            collisioned = collision.gameObject;
            collision.gameObject.SetActive(false);
            CheckInOrder(Collision_has);

        }
    }

    void CheckInOrder(string collisioned)
    { 
        List<string> orders_name = computer_window.GetComponent<Computer_Window>().Orders_Name;
        List<int> orders_value = computer_window.GetComponent<Computer_Window>().Orders_Price;
        
        foreach(var name in new List<string>(orders_name))
        {
            if(name==collisioned)
            {
                computer_window.GetComponent<Computer_Window>().RemoveOrder(name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
