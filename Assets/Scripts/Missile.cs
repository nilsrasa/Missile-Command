using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour, IPoolable
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCreate()
    {
        Debug.Log(gameObject.name + " was created");
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }

    public void OnReuse()
    {
        Debug.Log(gameObject.name + " was reused");
    }
}
