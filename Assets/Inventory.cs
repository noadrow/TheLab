using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Inventory : MonoBehaviour
{
    public string inventory_need = "";
    public string inventory_has = "";
    public bool take_able = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inventory_need=="")
        {
            take_able = true;
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Draggable")
        {
            Inventory Collision_Inventory = collision.gameObject.GetComponent<Inventory>();
            string Collision_has = Collision_Inventory.inventory_has;
            if(Collision_has == inventory_need)
            {
                if(Collision_Inventory.take_able)
                {
                    inventory_need = Regex.Replace(inventory_need, Collision_has, "");
                    inventory_has += Collision_has;
                    Destroy(collision.gameObject);
                    Debug.Log(collision.gameObject);

                }
            }
        }
    }

    
}
