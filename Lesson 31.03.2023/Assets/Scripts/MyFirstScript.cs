using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    public GameObject game0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        game0.transform.Rotate(new Vector3(x:0f , y:30f, z:0f)*Time.deltaTime);
    }
}
