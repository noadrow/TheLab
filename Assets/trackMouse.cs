using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trackMouse : MonoBehaviour
{
    public RawImage spray;
    public float distance = 200f;
    public float color_alpha = 0f;
    private Camera cam;
    public float height;
    private Vector3 track_position;
    public float full_spray = 0f;
    public float high_edge = 50f;
    public float low_edge = 0f;
    private int hight_pass = 0;
    private int low_pass = 0;
    public GameObject entered_plate;

    public string inventory_to_add = "";

    // Start is called before the first frame update
    void Start()
    {
        Color currColor = spray.color;
        currColor.a = color_alpha;
        spray.color = currColor;  

        cam = Camera.main;    
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 point = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
        if (transform.position.y<low_edge)
        {
            Debug.Log("pass_low");
            low_pass = 1;
            
        }
        if(transform.position.y>high_edge)
        {
            Debug.Log("pass_high");
            hight_pass = 1;
        }
        if ((hight_pass + low_pass) == 2)
        {
            hight_pass = 0;
            low_pass = 0;
            if (color_alpha<1f)
            {
                color_alpha += 0.1f;
                Color currColor = spray.color;
                currColor.a = color_alpha;
                spray.color = currColor;  
            }
            else
            {
                entered_plate.GetComponent<Inventory>().inventory_has = inventory_to_add;
            }
        }

        transform.position = new Vector3(transform.position.x, point.y - height, transform.position.z);
    }
}
