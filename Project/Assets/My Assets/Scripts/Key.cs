using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    public GameObject player_items;
    public GameObject particles_collect;

	public void OnKeyClicked()
	{
        player_items.SendMessage("Got_key");
        gameObject.SetActive(false);
        GameObject instance_particle = GameObject.Instantiate(particles_collect, transform.position, Quaternion.identity);
        GameObject.Destroy(instance_particle, 1);
    }

}
