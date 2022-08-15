using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColonaFill : MonoBehaviour
{
    //public GameObject Bottle;
    public Animator animator_bottle;
    public Animator animator_button;
    public float decrase_range = 10;
    public float Timer = 0;
    public float Delay = 10;

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
        Timer += Time.deltaTime;

        if(Timer > Delay)
        {
            animator_button.SetBool("ON",false);
            Timer = 0;
        }
    }

    void OnClick(PointerEventData data)
    {
        
        float current  = animator_bottle.GetFloat("BottleLevel");
        Debug.Log(current);
        animator_bottle.SetFloat("BottleLevel",current-decrase_range);
        animator_button.SetBool("ON",true);

    }
}
