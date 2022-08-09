using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExitWindow : MonoBehaviour
{
    public GameObject Window;
    // Start is called before the first frame update
    void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry click = new EventTrigger.Entry();
        click.eventID = EventTriggerType.PointerClick;
        click.callback.AddListener((data) => { OnClick((PointerEventData)data); });
        trigger.triggers.Add(click);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick(PointerEventData data)
    {
        Window.SetActive(false);
    }
}
