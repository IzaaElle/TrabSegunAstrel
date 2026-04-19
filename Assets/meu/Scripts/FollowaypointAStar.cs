using UnityEngine;

public class FollowaypointAStar : MonoBehaviour
{
    public WaypointsScripts manager;

    Transform target;
    GameObject[] waypoints;
    GameObject currentWaypoints;
    GrathScript graph;

    float speed = 5.0f;
    float accuracy = 5.0f;
    float rotSpeed = 2.0f;
    int currentWaypointIndex = 0;

    private void Start()
    {
        waypoints = manager.pontosWay;
        graph = manager.graph;
        currentWaypoints = waypoints[0];

        Invoke(nameof(GoToFactory), 2.0f);
    }



    /*                                  VER DEPOIS PQ TA ERRADO ASS. CAIO, VUGO ZEZÉ
    void Update()
    {
        // não existe caminho ou já chegou ao destino
        if (graph.GetPath().Count == 0 || currentWaypointIndex == graph.GetPath().Count) return;

        // se chegou ao destino, pega o próximo waypoint
        if (Vector3.Distance(graph.GetPath()[currentWaypointIndex].
            GetWaypointId().transform.position, transform.position) < accuracy)
        {
            currentWaypoint = graph.GetPath()[currentWaypointIndex].GetWaypointId();
            currentWaypointIndex++;
        }

        // se não chegou, continua indo para o waypoint olhando para ele
        if (currentWaypointIndex < graph.GetPath().Count)
        {
            target = graph.GetPath()[currentWaypointIndex].GetWaypointId().transform;
            Vector3 lookAtTarget = new Vector3(target.position.x, transform.position.y, target.position.z);
            Vector3 direction = lookAtTarget - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                Time.deltaTime * rotSpeed);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    */

    public void GoToStart()
    {
        graph.aEstrela(currentWaypoints, waypoints[0]);
        currentWaypointIndex = 0;
    }

    public void GoToFactory()
    {
        graph.aEstrela(currentWaypoints, waypoints[19]);
        currentWaypointIndex = 0;
    }




}
