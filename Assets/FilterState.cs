using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterState : MonoBehaviour
{
    public string inventory_has;
    public string inventory_need;
    public string to_add;
    public string cleansequence;
    public string cleansequence_need;
    public GameObject _eppendorf;
    public Transform _canvas;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(cleansequence==cleansequence_need && inventory_has==inventory_need)
        {
            cleansequence = "";
            inventory_has = "";
            GameObject _product = Instantiate(_eppendorf, transform.position, transform.rotation, _canvas);
            _product.GetComponentInChildren<Inventory>().inventory_has = to_add;

        }
    }
}
