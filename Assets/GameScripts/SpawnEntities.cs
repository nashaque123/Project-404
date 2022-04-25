using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEntities : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject JaguarPrefab;
    public GameObject AnteaterPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = Instantiate(PlayerPrefab, new Vector3(-20f, 1f, 20f), Quaternion.identity);
        player.GetComponent<ParentPrefab>().Source = PlayerPrefab;

        GameObject jaguar = Instantiate(JaguarPrefab, new Vector3(-18f, 1f, -70f), Quaternion.identity);
        jaguar.GetComponent<ParentPrefab>().Source = JaguarPrefab;

        GameObject anteater = Instantiate(AnteaterPrefab, new Vector3(20f, 1f, 50f), Quaternion.identity);
        anteater.GetComponent<ParentPrefab>().Source = AnteaterPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        RandomSpawn();
    }

    private void RandomSpawn()
    {
        int rand = Random.Range(0, 600);
        if (rand == 0)
        {
            GameObject jaguar = Instantiate(JaguarPrefab, new Vector3(8f, 1f, 70f), Quaternion.identity);
            jaguar.GetComponent<ParentPrefab>().Source = JaguarPrefab;
        }
        else if (rand == 1)
        {
            GameObject anteater = Instantiate(AnteaterPrefab, new Vector3(20f, 1f, 50f), Quaternion.identity);
            anteater.GetComponent<ParentPrefab>().Source = AnteaterPrefab;
        }
    }
}
