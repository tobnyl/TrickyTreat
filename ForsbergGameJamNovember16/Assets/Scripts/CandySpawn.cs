using UnityEngine;
using System.Collections;


public class CandySpawn : MonoBehaviour
{
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;


    public GameObject[] Hazards;


    void Start()
    {
        StartCoroutine(SpawnWaves());
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (!UIManager.IsGameOver)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                int randomIndex = Random.Range(0, Hazards.Length);
                var ranomdRotationZ = Random.Range(-45f, 45f);
             

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = transform.rotation;
                
                var hazard = Instantiate(Hazards[randomIndex], transform.position + spawnPosition, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f))) as GameObject;
                var rigidBody = hazard.GetComponent<Rigidbody>();
                rigidBody.AddForce(hazard.transform.right * Random.Range(GameManager.Instance.SpawnForceRange.x, GameManager.Instance.SpawnForceRange.y));


                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}



