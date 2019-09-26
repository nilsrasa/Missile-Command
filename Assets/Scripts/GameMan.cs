using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMan : MonoBehaviour
{
    public GameObject missile;
    public int missilePoolSize;
    public City[] cities;
    private PoolMan poolManager;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate pools
        PoolMan.Instance.CreatePool(missile, missilePoolSize);
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawn(){
        while(true){
            yield return new WaitForSeconds(2);
            PoolMan.Instance.ReuseObject(missile, Vector3.up*10, Quaternion.identity);
        }
    }
}
