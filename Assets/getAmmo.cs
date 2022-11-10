using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getAmmo : MonoBehaviour
{
    public GameObject AmmoBox; 
    int ammoCount = 0; //ammo count variable
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      RaycastHit hitInfo;
    Ray ray =  Camera.main.ViewportPointToRay(new Vector3(0.5f ,0.5f ,0.0f));
    bool hit = Physics.Raycast(ray, out hitInfo);
    if (Input.GetButtonDown("Fire1")) {
        ammoCount--;
    }

    if (hitInfo.collider.gameObject.name == "Target") {
        print (hitInfo.collider.gameObject.transform.parent.name);

    } 
    
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "AmmoBox") { //if the object being collided with is "AmmoBox"
            other.gameObject.SetActive(false); //hide AmmoBox
            ammoCount = 20; //set ammoCount to 20 when the box is picked up
            Debug.Log("hello"); //make sure the collider is bigger than the table so a collision is detected
        }
        //AmmoBox = GameObject.Find("AmmoBox"); 
        //AmmoBox.SetActive(false);
    }

   

}
