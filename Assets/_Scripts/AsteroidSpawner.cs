using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] asteroidsPrefab;
    [SerializeField] GameObject[] spawnersPos;

    [SerializeField] float spawnRateMin = 10f;
    [SerializeField] float spawnRateMax = 40f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            var spawnerChildIndex = Mathf.RoundToInt(Random.Range(0f, spawnersPos.Length - 1));
            var spawnerChild = spawnersPos[spawnerChildIndex];
            var asteroidIndex = Mathf.RoundToInt(Random.Range(0f, asteroidsPrefab.Length - 1));
            var asteroid = asteroidsPrefab[asteroidIndex];
            Vector2 spawnPos;

            if (spawnerChild.transform.position.x == 0f)
            {
                spawnPos = new Vector2(Random.Range(-9f, 9f), spawnerChild.transform.position.y);
            }
            else
            {
                spawnPos = new Vector2(spawnerChild.transform.position.x, Random.Range(-5f, 5f));
            }

            var asteroidGO = Instantiate(asteroid, spawnPos, Quaternion.identity) as GameObject;

            yield return new WaitForSeconds(Random.Range(spawnRateMin, spawnRateMax));
        }
    }
}
