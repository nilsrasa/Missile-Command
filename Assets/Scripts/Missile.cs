using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour, IPoolable
{
    public bool isCounter;
    public float speed;
    public GameObject blastPref;
    public float blastRadius;
    public int points;
    private Vector3 _target;
    public Vector3 target{
        set {
            _target = value;
            transform.LookAt(_target);
            rigidBody.velocity = transform.forward * speed;
        }
    }
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCounter){
            if (Vector3.Distance(transform.position, _target) <= speed * Time.deltaTime){
                Destroy();
            }
        }
    }

    public void OnCreate()
    {
        Debug.Log(gameObject.name + " was created");
        rigidBody = GetComponent<Rigidbody>();
    }

    public virtual void Destroy()
    {
        gameObject.SetActive(false);
        PoolMan.Instance.ReuseObject(blastPref, transform.position, Quaternion.identity)
            .GameObject.GetComponent<Blast>()
            .blastRadius = blastRadius;
    }

    public virtual void OnReuse()
    {
        Debug.Log(gameObject.name + " was reused");
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.velocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision other)
    {
        if (!isCounter){
            string tag = other.gameObject.tag;
            if (tag.Equals("City")){
                other.gameObject.GetComponent<City>().Destroy();
            } else if (tag.Equals("Blast") || tag.Equals("Missile")){
                if (GameEvents.missileDestroyed != null){
                    GameEvents.missileDestroyed(points);
                }
            }
        }
        Destroy();
    }
}
