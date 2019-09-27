using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class City : MonoBehaviour
{
    public GameObject blastPref;
    public float blastRadius;
    public System.Action OnDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy(){
        //Todo destroy
        gameObject.SetActive(false);
        PoolMan.Instance.ReuseObject(blastPref, transform.position, Quaternion.identity)
            .GameObject.GetComponent<Blast>()
            .blastRadius = blastRadius;
        if (OnDestroyed != null){
            OnDestroyed();
        }
    }
}
