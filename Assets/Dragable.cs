using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Dragable : MonoBehaviour
{
    public float distance = 200f;
    private Camera cam;
    private Rigidbody2D _thisRigid2D;
 
    public void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry drag = new EventTrigger.Entry();
        EventTrigger.Entry drop = new EventTrigger.Entry();
        drag.eventID = EventTriggerType.Drag;
        drop.eventID = EventTriggerType.Drop;
        drag.callback.AddListener((data) => { OnDrag((PointerEventData)data); });
        drop.callback.AddListener((data) => { OnDrop((PointerEventData)data); });
        trigger.triggers.Add(drag);
        trigger.triggers.Add(drop);

        cam = Camera.main;
        _thisRigid2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData data)
    {
        _thisRigid2D.simulated = true;
    }

    public void OnDrag(PointerEventData data)
    {
        Vector3 point = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
        transform.position = point;
        _thisRigid2D.simulated = false;

        GetComponent<Stick>().stick = false;
    }

    
}


              
              

