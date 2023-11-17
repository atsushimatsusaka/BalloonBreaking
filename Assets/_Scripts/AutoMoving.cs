
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AutoMoving : MonoBehaviour
{
    private float timer = 0f;
    private float duration = 0.4f;
    private NavMeshAgent agent;
    private Vector3 destination;
    private Transform destPointParent;
    [SerializeField] private Transform destPoint;
    [SerializeField] private Vector2 rotRange = new Vector2(60f,280f);

    void Start()
    {
        destPointParent = destPoint.parent;
        agent = GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > duration)
        {
            //目的地を変える //親オブジェクトを一定範囲に回転
            var y = Random.Range(rotRange.x, rotRange.y);
            destPointParent.localEulerAngles = new Vector3(0f, y, 0f);

            timer = 0f;
            //Debug.Log("gene");
        }

        //目的地に向かう
        destination = destPoint.position;
        agent.destination = destination;
    }
}