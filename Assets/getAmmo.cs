using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getAmmo : MonoBehaviour
{
    public GameObject AmmoBox; 
    public AudioClip empty; //sound for no ammo
    public AudioClip load; //sound for pick up ammo
    public AudioClip gunshot; //sound for shoot ammo
    public AudioSource gunsound; //gunsound variable to be changed depending on audio clip to be played
    public int ammoCount = 0; //ammo count variable

    // Start is called before the first frame update
    void Start()
    {
        ammoCount = 0;
        gunsound = GetComponent<AudioSource>(); //gunsound is the AudioSource variable
    }

    // Update is called once per frame
    void Update()
    {

    if (Input.GetButtonDown("Fire1")) {
        if (ammoCount == 0) 
        {
            gunsound.clip = empty;
            gunsound.Play();
        }
        else 
        {     Debug.Log("hello");
            ammoCount -= 1;
            gunsound.clip = gunshot; //set the specific gunsound clip to be played to "gunshot"
            gunsound.Play(); //play gunsound (gunshot
            Ray ray =  Camera.main.ViewportPointToRay(new Vector3(0.5f ,0.5f ,0.0f));
            RaycastHit result; 
            Physics.Raycast(ray, out result);
            GameObject g = result.collider.gameObject;
            if (g.name == "Target") 
            {
                //print (result.collider.gameObject.transform.parent.name);
                Animation a = g.transform.parent.GetComponent<Animation>();
                a.Play("LowerBridge");
            }
        }
      }  
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "AmmoBox") 
        { //if the object being collided with is "AmmoBox"
            ammoCount = 20;
            other.gameObject.SetActive(false); //hide AmmoBox
            gunsound.clip = load;
            gunsound.Play(); //play load sound effect
            Debug.Log("hello"); //make sure the collider is bigger than the table so a collision is detected
        }
    }
}