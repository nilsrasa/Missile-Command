using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour, IPoolable
{
    private bool hasThrust;
    public float speed;
    public GameObject blastPref;
    public float blastRadius;

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
        PoolMan.Instance.ReuseObject(blastPref, transform.position, Quaternion.identity)
            .GameObject.GetComponent<Blast>()
            .blastRadius = blastRadius;

    }

    public void OnReuse()
    {
        Debug.Log(gameObject.name + " was reused");
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("City")){
            other.gameObject.GetComponent<City>().Destroy();
        }
        Destroy();
    }
}
