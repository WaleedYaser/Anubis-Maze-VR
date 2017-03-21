using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock_door : MonoBehaviour {

    public GameObject door;
    public GameObject player_items;
    public GameObject key;
    public GameObject particles_collect;

    private Items _player_items;
    private Door _door;

    public void Start()
    {
        _player_items = player_items.GetComponent<Items>();
        _door = door.GetComponent<Door>();
    }

    public void OnKeyPlaceClicked()
    {
        if (_player_items.has_key && _door.locked)
        {
            _door.locked = false;
            _player_items.has_key = false;

            GameObject instance_particle = GameObject.Instantiate(particles_collect, 
                                                                  key.transform.position, 
                                                                  Quaternion.identity);
            GameObject.Destroy(instance_particle, 1);

            key.SetActive(true);
        }
    }
}
