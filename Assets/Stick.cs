using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public GameObject Player;
    public bool stick = false;
    public float maxDistance = 25f;
    private float distance;
    public Vector3 HandDis;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        distance = Vector3.Distance(transform.position, Player.transform.position);
        //Debug.Log(distance);
        if(distance < maxDistance)
        {
            stick = true;
        }
        if(stick)
        {
            transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y,Player.transform.position.z) - HandDis;
        }
        
    }

}
