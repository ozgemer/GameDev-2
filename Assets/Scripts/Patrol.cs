using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject rangePrefab;
    [SerializeField] GameObject activeRangePrefab;

    private GameObject range;
    private GameObject rangeActive;
    private NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex = 0;
    bool chase = false;
    [SerializeField] public float radiusRange = 8f;
    Vector3 target;

    private void Awake()
    {
        range = Instantiate(rangePrefab, transform.position, Quaternion.identity, transform);
        rangeActive = Instantiate(activeRangePrefab, transform.position, Quaternion.identity, transform);
        range.transform.Rotate(90f, 0, 0, Space.Self);
        rangeActive.transform.Rotate(90f, 0, 0, Space.Self);
        rangeActive.SetActive(false);
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        UpdateDestination();
    }

    private void Update()
    {
        if (!chase)
        {
            if (!player.transform.Find("Sneak(Clone)") && Vector3.Distance(transform.position, player.transform.position) < radiusRange)
                StartCoroutine(ChasePlayer());
            else if (Vector3.Distance(transform.position, target) < 1)
            {
                IterateWaypointIndex();
                UpdateDestination();
            }
        }
    }

    private void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    private void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
            waypointIndex = 0;
    }

    IEnumerator ChasePlayer()
    {
        chase = true;
        rangeActive.SetActive(true);
        range.SetActive(false);
        agent.SetDestination(player.transform.position);
        yield return new WaitForSeconds(3);
        rangeActive.SetActive(false);
        range.SetActive(true);
        chase = false;
        agent.SetDestination(target);
    }
}
