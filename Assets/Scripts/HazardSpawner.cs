using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    [SerializeField] private GameObject DebrisPrefab;
    [SerializeField, Range(0f, 300f)] private float SpawnDelay;
    [SerializeField, Range(0, 10)] private int StartingDebris;
    [SerializeField] private float ScreenSizeX, ScreenSizeY;

    protected void Start()
    {
        for (int i = 0; i < StartingDebris; i++)
        {
            StartCoroutine(SpawnDebris());
        }
    }

    public IEnumerator SpawnDebris()
    {
        // Choose the side the debris comes from
        int direction = Random.Range(0, 4);
        Vector3 location = Vector3.zero;

        // Top is 0, Right is 1, Bottom is 2, Left is 3
        if (direction == 0)
        {
            location = new Vector3(Random.Range(-ScreenSizeX, ScreenSizeX), ScreenSizeY, 0);
        } 
        else if (direction == 1)
        {
            location = new Vector3(ScreenSizeX, Random.Range(-ScreenSizeY, ScreenSizeY), 0);
        }
        else if (direction == 2)
        {
            location = new Vector3(Random.Range(-ScreenSizeX, ScreenSizeX), -ScreenSizeY, 0);
        }
        else
        {
            location = new Vector3(-ScreenSizeX, Random.Range(-ScreenSizeY, ScreenSizeY), 0);
        }

        Instantiate(DebrisPrefab, location, Quaternion.identity);

        yield return new WaitForSeconds(SpawnDelay);

        StartCoroutine(SpawnDebris());
    }
    
}
