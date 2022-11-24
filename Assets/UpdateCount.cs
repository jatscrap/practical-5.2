using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCount : MonoBehaviour
{
    public int count = 0;
    public GameObject countText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         int bulletCount = textCount.GetComponent<FPSController>().ammoCount;
         Text text = GetComponent<Text>();
         text.text = bulletCount.ToString(); 
    }
}
