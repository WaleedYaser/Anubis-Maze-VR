using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    // Create a boolean value called "opening" that can be checked in Update() 

    public GameObject message;

    public bool locked = true;
    public bool opening = false;

    public AudioClip door_open_sound;
    public AudioClip door_locked_sound;

    public float y_opened;
    public float opening_time;
    private float _time = 0f;

    private bool _raised = false;
    private Vector3 _target_position;
    private Vector3 _current_position;
    private Vector3 _message_position;

    private AudioSource _sound_source;

    private void Start()
    {
        _target_position = new Vector3(0f, y_opened, 0f);
        _current_position = gameObject.transform.localPosition;
        _message_position = transform.position - Vector3.forward;
        _sound_source = GetComponent<AudioSource>();
    }

    void Update() {
        // If the door is opening and it is not fully raised
        // Animate the door raising up
        if (opening && !_raised)
        {
            _time += Time.deltaTime;
            gameObject.transform.localPosition = Vector3.Lerp(_current_position,
                                                         _target_position,
                                                         _time / opening_time);
        }

        if (gameObject.transform.position == _target_position)
        {
            _raised = true;
            _time = 0f;
        }
    }

    public void OnDoorClicked() {
        // If the door is clicked and unlocked
        // Set the "opening" boolean to true
        // (optionally) Else
        // Play a sound to indicate the door is locked

        if (!locked)
        {
            opening = true;
            _sound_source.clip = door_open_sound;
            _sound_source.Play();
        }
        else
        {
            GameObject instant_message = GameObject.Instantiate(message, _message_position, Quaternion.identity);
            Destroy(instant_message, 1f);

            _sound_source.clip = door_locked_sound;
            _sound_source.Play();
        }
    }

    public void Unlock()
    {
        // You'll need to set "locked" to false here
        locked = false;
    }
}
