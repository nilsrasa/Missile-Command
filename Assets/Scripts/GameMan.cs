using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMan : MonoBehaviour
{
    public GameObject missile;
    public int missilePoolSize;
    public GameObject blast;
    public City[] cities;
    public Vector4 bounds;
    private int lives;
    private PoolMan poolManager;
    // Start is called before the first frame update
    void Start()
    {
        lives = cities.Length;

        foreach (City city in cities)
        {
            city.OnDestroyed += CityDestroyed;
        }

        //Instantiate pools
        PoolMan.Instance.CreatePool(missile, missilePoolSize);
        PoolMan.Instance.CreatePool(blast, missilePoolSize+lives);
        //Start spawning missiles
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CityDestroyed(){
        lives--;
        Debug.Log("City was destroyed, "+lives+" remaining");
    }

    Vector3 RandomTarget(){
        //TODO: could be changed to only choose non destroyed cities
        return cities[Random.Range(0, cities.Length)].transform.position;
    }

    IEnumerator spawn(){
        while(true){
            yield return new WaitForSeconds(2);
            //Picks a random spawn position along the top
            Vector3 pos = Vector3.up * bounds.z + Vector3.right * Random.Range(bounds.x, bounds.y);
            //Picks random target
            Vector3 dest = RandomTarget();
            //Finds the angle direction between the position and the target
            Quaternion dir = Quaternion.LookRotation((dest - pos).normalized);

            Debug.Log("Pos: "+pos+", Dest: "+dest+" dir: "+dir);
            //Spawn an object from the pool
            PoolMan.Instance.ReuseObject(missile, pos, dir);
        }
    }
}
