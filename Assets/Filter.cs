using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Filter : MonoBehaviour
{
    public string inventory_need;
    public string inventory_has;

    public GameObject filterwindow;

    public int stage = 0;
    public bool take_able = false;
    public string to_add = "";
    public float timer = -1; 

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<OpenWindow>().elutable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(inventory_has=="")
        {
            GetComponent<OpenWindow>().elutable = false;

        }
        //loop through timers and create new plate when finished
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer > -1)
        {
            
            //collisioned.SetActive(true);
            timer = -1;
            if(stage<3)
            {
                stage += 1;
            }
            else
            {
                Debug.Log("release plate");
            }

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //need to iterate each inventory_need element by the same order ? flag
        if(collision.gameObject.tag == "Draggable")
        {
            Inventory Collision_Inventory = collision.gameObject.GetComponent<Inventory>();
            string Collision_has = Collision_Inventory.inventory_has;
            if(inventory_need==Collision_has && stage == 0)
            {
                //inventory_need = Regex.Replace(inventory_need, Collision_has, "");
                inventory_has = Collision_has;
                filterwindow.GetComponent<FilterState>().inventory_has = inventory_has;
                GetComponent<OpenWindow>().elutable = true;
                Destroy(collision.gameObject);
                stage += 1;
            }       
        }
    }
}
