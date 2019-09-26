using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class City : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Missile")){
            other.gameObject.GetComponent<Missile>().Destroy();
            //TODO: show explosion
            gameObject.SetActive(false);
        }
    }
}
