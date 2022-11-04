using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject target;
    private float spawnRangeX = 4;
    private float bottomY = 3.39f;
    private float topY = 7.88f;
    private float negSpawnPosZ = 8.66f;
    private float posSpawnPosZ = 15.65f;
    private float InstatiationTimer = 0.45f;

    public float totalSpawned;

    GameObject[] targets;

    void Start() {
        totalSpawned = 0;
    }

    void Update() {
        InstatiationTimer -= Time.deltaTime;

        targets = GameObject.FindGameObjectsWithTag("Selectable");;
        int numberOfTargets = targets.Length;

        //if(InstatiationTimer <= 0) {
            //if(numberOfTargets < 5) {
                //spawnTarget();
                //InstatiationTimer = 0.45f;
            //}
        //}
        if(numberOfTargets == 1) {
            spawnTarget(1);
        }

        if (numberOfTargets == 0) {
            spawnTarget(2);
        }
    }

    public void spawnTarget(int num) {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(bottomY, topY), Random.Range(negSpawnPosZ, posSpawnPosZ));
        int i = 0;
        while (i < num) {
            Instantiate(target, spawnPos, target.transform.rotation);
            i++;
        }

        totalSpawned += num;
    }

    public void DestroyTargets() {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Selectable");
        foreach(GameObject target in targets) {
            GameObject.Destroy(target);
        }
    }
}
