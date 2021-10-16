using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public Rigidbody2D boxTemplates;
    private float boxTemplateHeight = 7f;
    private float boxTemplateWidth = 15f;

    private List<GameObject> spawnedBox;

    private void Start()
    {
        spawnedBox = new List<GameObject>(0);

        //GenerateBox for Problem 6
        int boxCount = Random.Range(5, 10);
        for (int i = 0; i <= boxCount; i++)
        {
            float posX = Random.Range(-boxTemplateWidth / 2, boxTemplateWidth / 2);
            float posY = Random.Range(-boxTemplateHeight / 2, boxTemplateHeight / 2);
            SpawnBox(posX, posY);
        }
    }

    private void SpawnBox(float posX, float posY)
    {
        GameObject newBox = Instantiate(boxTemplates.gameObject, transform);
        newBox.transform.position = new Vector2(posX, posY);
        spawnedBox.Add(newBox);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position + new Vector3(boxTemplateWidth / 2, boxTemplateHeight / 2, 0), transform.position + new Vector3(boxTemplateWidth / 2, -boxTemplateHeight / 2, 0), Color.green);
        Debug.DrawLine(transform.position + new Vector3(-boxTemplateWidth / 2, boxTemplateHeight / 2, 0), transform.position + new Vector3(-boxTemplateWidth / 2, -boxTemplateHeight / 2, 0), Color.green);
        Debug.DrawLine(transform.position + new Vector3(boxTemplateWidth / 2, boxTemplateHeight / 2), transform.position + new Vector3(-boxTemplateWidth / 2, boxTemplateHeight / 2), Color.green);
        Debug.DrawLine(transform.position + new Vector3(boxTemplateWidth / 2, -boxTemplateHeight / 2), transform.position + new Vector3(-boxTemplateWidth / 2, -boxTemplateHeight / 2), Color.green);
    }
}
