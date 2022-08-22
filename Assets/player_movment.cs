using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class player_movment : MonoBehaviour
{

    public Rigidbody2D _playerRigidbody;
    public Transform _CameraTransform;
    public Vector3 _CameraDistance;
    public Vector3 __GUIDistance;
    public Transform _GUIrootTrandform;

    private Vector3 playerVelocity;

    public float playerSpeed = 2.0f;

    public bool on_left = false;
    public bool on_right = false;

    public GameObject rightbutton;
    public GameObject leftbutton;

    private void Start()
    {
        EventTrigger trigger_right = rightbutton.GetComponent<EventTrigger>();
        EventTrigger trigger_left = leftbutton.GetComponent<EventTrigger>();

        EventTrigger.Entry entry_on_right = new EventTrigger.Entry();
        EventTrigger.Entry entry_on_left = new EventTrigger.Entry();

        EventTrigger.Entry entry_off_right = new EventTrigger.Entry();
        EventTrigger.Entry entry_off_left = new EventTrigger.Entry();

        entry_on_right.eventID = EventTriggerType.PointerDown;
        entry_on_left.eventID = EventTriggerType.PointerDown;

        entry_off_right.eventID = EventTriggerType.PointerUp;
        entry_off_left.eventID = EventTriggerType.PointerUp;

        entry_on_right.callback.AddListener(
            (eventData) => {OnRight(); }
        );
        entry_on_left.callback.AddListener(
            (eventData) => {OnLeft(); }
        );
        entry_off_right.callback.AddListener(
            (eventData) => {OffRight(); }
        );
        entry_off_left.callback.AddListener(
            (eventData) => {OffLeft(); }
        );

        trigger_right.triggers.Add(entry_on_right);
        trigger_left.triggers.Add(entry_on_left);

        trigger_right.triggers.Add(entry_off_right);
        trigger_left.triggers.Add(entry_off_left);

        _CameraTransform = Camera.main.transform;
        _CameraDistance = _CameraTransform.position - _playerRigidbody.transform.position;
        __GUIDistance = _GUIrootTrandform.position - _playerRigidbody.transform.position;
    }

    void Update()
    {
        _CameraTransform.position = _playerRigidbody.transform.position + _CameraDistance;  
        _GUIrootTrandform.position = _playerRigidbody.transform.position + __GUIDistance;
    }

    public void OnRight()
    {
        _playerRigidbody.velocity = new Vector2(playerSpeed, _playerRigidbody.velocity.y);          

    }

    public void OnLeft()
    {
        _playerRigidbody.velocity = new Vector2(-playerSpeed, _playerRigidbody.velocity.y);              
    }

    public void OffRight()
    {
        _playerRigidbody.velocity = new Vector2(0,0);
    }

    public void OffLeft()
    {
        _playerRigidbody.velocity = new Vector2(0,0);
    }

}
