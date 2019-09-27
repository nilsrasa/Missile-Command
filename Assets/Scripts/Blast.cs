using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour, IPoolable
{
    public Vector3 startScale;
    private float _blastRadius;
    public float blastRadius{
        set {
            _blastRadius = value;
            _speed = _blastRadius - startScale.x;
         }
    }
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < _blastRadius)
            transform.localScale += Vector3.one * _speed * Time.deltaTime;
        else
            Destroy();
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
        transform.localScale = startScale;
    }

    public void OnCreate()
    {
        Debug.Log(gameObject.name + " was created");
    }

    public void OnReuse()
    {
        Debug.Log(gameObject.name + " was reused");
    }
}
