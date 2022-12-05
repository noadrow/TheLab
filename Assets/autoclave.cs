using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class autoclave : MonoBehaviour
{
    public string inventory_need = "";
    public string inventory_has = "";
    public string to_add = "";
    public float timer = -1;
    public GameObject collisioned;

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
            
            if(Collision_has.StartsWith(inventory_need) && Collision_Inventory.take_able)
            {
                    //inventory_need = Regex.Replace(inventory_need, Collision_has, "");
                    //inventory_has = Collision_has;
                    timer = 10;
                    Collision_Inventory.inventory_has += to_add;
                    inventory_has = Collision_Inventory.inventory_has;
                    collisioned = collision.gameObject;
                    collision.gameObject.SetActive(false);

            }
        }
    }

    void Update()
    {
        //loop through timers and create new plate when finished
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer > -1)
        {
            Debug.Log("release plate");
            collisioned.SetActive(true);
            timer = -1;
            inventory_has = "";
        }
    }
}
