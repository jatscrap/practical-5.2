using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public int ammo;        // Initialise Ammo 
    public AudioClip empty;

    // Start is called before the first frame update
    void Start()
    {
        ammo = 0;          // Set Ammo to 0 at start                                     
    }

    // Update is called once per frame
    void Update()
    {   
        //Check if left mouse button clicked
        if (Input.GetButtonDown("Fire1"))
        {
            // Check if ammo is 0
            if (ammo == 0)
            {
                Debug.Log("You have no Ammo!!!!");
                AudioSource empty = GetComponent<AudioSource>();
                empty.Play();
            }
            else
            {
                ammo -= 1;                                                                     // Reduce Ammo by 1
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));       // Create ray according to central dot
                RaycastHit result;
                Physics.Raycast(ray, out result);
                GameObject g = result.collider.gameObject;                                     // Find gameobject that ray has hit
                if (g.name == "Target")                                                        // Check if gameobject is Target
                {
                    Animation a = g.transform.parent.GetComponent<Animation>();
                    a.Play("LowerBridge");
                }
            }
            
        }
    }

    
    void OnTriggerEnter(Collider other)
    {   
        // Check if Collision is with AmmoBox
        if (other.gameObject.name == "AmmoBox")
        {
            ammo = 20;                          // Set ammo to 20
            other.gameObject.SetActive(false);  // Despawn AmmoBox
        }
        
        
    }

}