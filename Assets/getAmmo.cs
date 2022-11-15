using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getAmmo : MonoBehaviour
{
    public GameObject AmmoBox; 
    //public AudioClip empty;
    public AudioClip load;
    int ammoCount = 0; //ammo count variable
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    Ray ray =  Camera.main.ViewportPointToRay(new Vector3(0.5f ,0.5f ,0.0f));
    RaycastHit result; 
    Physics.Raycast(ray, out result);
    GameObject g = result.collider.gameObject;
    Animation a = g.transform.parent.GetComponent<Animation>();
    a.Play("LowerBridge");
    //RaycastHit hitInfo;
    //Ray ray =  Camera.main.ViewportPointToRay(new Vector3(0.5f ,0.5f ,0.0f));
    //bool hit = Physics.Raycast(ray, out hitInfo);
    
    if (Input.GetButtonDown("Fire1")) {
        ammoCount--;
    }

    if (result.collider.gameObject.name == "Target") {
        print (result.collider.gameObject.transform.parent.name);

    } 
    
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "AmmoBox") { //if the object being collided with is "AmmoBox"
            other.gameObject.SetActive(false); //hide AmmoBox
            AudioSource load = GetComponent<AudioSource>();
            load.Play();
            ammoCount = 20; //set ammoCount to 20 when the box is picked up
            Debug.Log("hello"); //make sure the collider is bigger than the table so a collision is detected
        }
    }

   

}
