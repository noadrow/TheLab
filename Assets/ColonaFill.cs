using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ColonaFill : MonoBehaviour
{
    //public GameObject Bottle;
    public Animator animator_bottle;
    public Button _button;
    private float current;
    public float decrase_range = 10;
    public string ID;
    public GameObject filterwindow;
    public float Delay = 10;

    // Start is called before the first frame update
    void Start()
    {
        current =  animator_bottle.GetFloat("BottleLevel");
        _button.onClick.AddListener(() => { OnClick();});
    }

    // Update is called once per frame
    void Update()
    {
        if(current<=0)
        {
            _button.interactable = false;
        }
        else
        {
            _button.interactable = true;
        }

        //if(filterwindow.GetComponent<FilterState>().cleansequence==cleansequence)
    }

    void OnClick()
    {
        current  = animator_bottle.GetFloat("BottleLevel");
        animator_bottle.SetFloat("BottleLevel",current-decrase_range);
        filterwindow.GetComponent<FilterState>().cleansequence += ID;
        filterwindow.GetComponent<FilterState>().cleansequence += "_";

    }
}
