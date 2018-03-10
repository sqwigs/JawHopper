using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ProceduralPlatforms : MonoBehaviour {

    [Header("Platform Prefab")]
    public Transform platformPrefab;

    [Space]
    [Header("Generation Options")]
    [Range(1,2)]
    public float minWidth;
    [Range(2,10f)]
    public float maxWidth;
    [Range(10,20)]
    public float roomWidth;
    [Range(1,2)]
    public float heightMinDensity;
    [Range(2,10)]
    public float heightMaxDensity;
    [Range(5,10)]
    public int platformsPerGeneration;

    private float latestHeight;

	void Start ()
    {
        // if maxWidth > roomWidth, it isn't anymore
        maxWidth = maxWidth > roomWidth ? roomWidth : maxWidth;

        // if minWidth > maxWidth, it isn't anymore
        minWidth = minWidth > maxWidth ? maxWidth : minWidth;

        // if heightMinDensity > heightMaxDensity, it isn't anymore
        heightMinDensity = heightMinDensity > heightMaxDensity ? heightMaxDensity : heightMinDensity;

        latestHeight = 0f;
        GeneratePlatforms(false);
	}

    public void GeneratePlatforms(bool Inspector)
    {
        //latestHeight = Inspector ? 0 : latestHeight;
        for (int generated = 0; generated < platformsPerGeneration; generated++)
        {
            Vector3 scale = new Vector3(Random.Range(minWidth, maxWidth), 1f ,1f);
            float x = Random.Range(0f, roomWidth);
            float xDiff = x + scale.x;
            if (xDiff > roomWidth)
                x -= (xDiff - roomWidth);
            latestHeight = latestHeight + Random.Range(heightMinDensity, heightMaxDensity);
            Vector3 position = new Vector3(x, latestHeight, 0f);
            Transform p = Instantiate(platformPrefab);
            p.localScale = scale;
            p.position = position;
        }
    }
}

[CustomEditor(typeof(ProceduralPlatforms))]
public class TMapInspector : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate"))
        {
            ProceduralPlatforms platforms = (ProceduralPlatforms)target;
            platforms.GeneratePlatforms(true);
        }
    }
}
