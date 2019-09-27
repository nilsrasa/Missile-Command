using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMan : MonoBehaviour
{
    public GameObject counterMissile;
    public int counterMissilePoolSize;
    public GameObject missile;
    public int missilePoolSize;
    public GameObject blast;
    public City[] cities;
    public Vector4 bounds;
    private int lives, score;
    private PoolMan poolManager;
    // Start is called before the first frame update
    void Start()
    {
        lives = cities.Length;

        GameEvents.cityDestroyed += CityDestroyed;
        GameEvents.missileDestroyed += MissileDestroyed;

        //Instantiate pools
        PoolMan.Instance.CreatePool(counterMissile, counterMissilePoolSize);
        PoolMan.Instance.CreatePool(missile, missilePoolSize);
        PoolMan.Instance.CreatePool(blast, missilePoolSize+lives);
        //Start spawning missiles
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CityDestroyed(City city){
        lives--;
        Debug.Log("City was destroyed, "+lives+" remaining");
    }

    void MissileDestroyed(int points){
        score += points;
        if (GameEvents.uiScore != null){
            GameEvents.uiScore(score);
        }
    }

    Vector3 RandomTarget(){
        //TODO: could be changed to only choose non destroyed cities
        return cities[Random.Range(0, cities.Length)].transform.position;
    }

    public void SpawnCounterMissile(Vector3 target){
        PoolMan.Instance.ReuseObject(counterMissile, Vector3.up, Quaternion.identity)
                .GameObject.GetComponent<Missile>()
                .target = target;
    }

    IEnumerator spawn(){
        while(true){
            yield return new WaitForSeconds(2);
            //Picks a random spawn position along the top
            Vector3 pos = Vector3.up * bounds.z + Vector3.right * Random.Range(bounds.x, bounds.y);

            //Spawn an object from the pool
            PoolMan.Instance.ReuseObject(missile, pos, Quaternion.identity)
                .GameObject.GetComponent<Missile>()
                .target = RandomTarget();
        }
    }
}
