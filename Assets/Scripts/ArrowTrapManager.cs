using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrapManager : MonoBehaviour
{
    [Tooltip("ON: Spawneja una fletxa d'un forat random a cada spawn; OFF: Spawneja una fletxa a tots els forats")]
    public bool oneArrowSpawned;
    public float timeBetweenArrows;
    public float arrowSpeed;

    public GameObject[] arrowSpawnPoints;
    public GameObject arrowPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ArrowSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ArrowSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenArrows);
            if (oneArrowSpawned)
            {
                Transform spawnPoint = arrowSpawnPoints[Random.Range(0, arrowSpawnPoints.Length)].transform;
                GameObject newArrow = Instantiate(arrowPrefab, spawnPoint.position, spawnPoint.rotation);
                newArrow.GetComponent<ArrowManager>().speed = arrowSpeed;
            }
            else
            {
                foreach(GameObject sp in arrowSpawnPoints)
                {
                    GameObject newArrow = Instantiate(arrowPrefab, sp.transform.position, sp.transform.rotation);
                    newArrow.GetComponent<ArrowManager>().speed = arrowSpeed;
                }
            }
            
        }
    }
}
