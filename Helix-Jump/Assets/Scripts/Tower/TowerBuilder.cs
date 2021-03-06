using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int levelCount;
    [SerializeField] private int aditionalScale;
    [SerializeField] private GameObject beam;
    [SerializeField] private SpawnPlatform spawnPlatform;
    [SerializeField] private FinishPlatform finish;
    [SerializeField] private Platform[] platform;

    private float startBeamHight;
    private float beamHight => levelCount / 2f + startBeamHight / 2f + aditionalScale/2f;

    private void Awake()
    {
        startBeamHight = beam.transform.localScale.y;
        Build();
    }
    private void Build()
    {
        GameObject beam = Instantiate(this.beam, transform);
        beam.transform.localScale = new Vector3(1, beamHight, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beamHight - aditionalScale;

        SpawnPlatform(spawnPlatform, ref spawnPosition, beam.transform);

        for (int i = 0; i < levelCount; i++)
        {
            SpawnPlatform(platform[Random.Range(0, platform.Length)], ref spawnPosition, beam.transform);
        }

        SpawnPlatform(finish, ref spawnPosition, beam.transform);
    }
    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= startBeamHight;
    }
}
