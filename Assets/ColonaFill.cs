using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColonaFill : MonoBehaviour
{
    //public GameObject Bottle;
    public Animator animator;
    public float decrase_range = 10;

    // Start is called before the first frame update
    void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry click = new EventTrigger.Entry();
        click.eventID = EventTriggerType.PointerClick;
        click.callback.AddListener((data) => { OnClick((PointerEventData)data); });
        trigger.triggers.Add(click);

        //animator = Bottle.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick(PointerEventData data)
    {
        float current  = animator.GetFloat("BottleLevel");
        animator.SetFloat("BottleLevel",current-decrase_range);
    }
}
