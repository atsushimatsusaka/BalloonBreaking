using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    private float timer = 0f;
    private float geneDuration = 0.75f;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject genePointObj;
    private Vector3 genePoint;
    private float genePointY = -3f;
    [SerializeField] private List<Transform> basicPoint = new List<Transform>();

    void Start()
    {
        for (int i = 0; i < basicPoint.Count; i++)
        {
            basicPoint[i].gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > geneDuration)
        {
            timer = 0f;
            Generate();
            //Debug.Log("gene");
        }
    }

    private void Generate()
    {
        var ran = Random.Range(1,3);
        if (ran%2==0)
        {
            genePoint = genePointObj.transform.position;
            genePoint = new Vector3(genePoint.x, genePointY, genePoint.z);
            //Debug.Log("randomPoint");
        }
        else
        {
            var num = Random.Range(0,basicPoint.Count);
            genePoint = basicPoint[num].position;
            genePoint = new Vector3(genePoint.x, genePointY, genePoint.z);
            //Debug.Log("basicPoint");
        }
        Instantiate(prefab, genePoint, prefab.transform.rotation);
    }
}
