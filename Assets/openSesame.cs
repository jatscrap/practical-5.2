using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openSesame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       

    }
    //this function needs to be outside update because it is a separate event handler
    //this function takes a Collider object as a parameter rather than a Collision, because no physical collision takes place
    void OnTriggerEnter(Collider other) { //allows us to detect when 2 colliders intersect
       GameObject parent = transform.parent.gameObject;       
       Animation animation = parent.GetComponent<Animation>();       
       animation.Play("OpenDoor");   
       AudioSource open = GetComponent<AudioSource>();
       open.Play();
     } 
}
