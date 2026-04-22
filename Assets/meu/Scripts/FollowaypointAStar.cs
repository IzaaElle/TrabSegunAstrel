using UnityEngine;
public class FollowaypointAStar : MonoBehaviour
{
    public WaypointsScripts manager;

    Transform target;
    GameObject[] waypoints;
    GameObject currentWaypoints;
    GrathScript graph;

    float speed = 3.0f;
    float accuracy = 1.0f;
    float rotSpeed = 4.0f;
    int currentWaypointIndex = 0;


    private void Start()
    {
        waypoints = manager.pontosWay;
        graph = manager.graph;
        currentWaypoints = waypoints[0];
        
        //Invoke(nameof(GBanho), 2.0f);
    }

    

    /*                                  VER DEPOIS PQ TA ERRADO ASS. CAIO, VUGO ZEZÉ
     *                                  */
    void Update()
    {
        // não existe caminho ou já chegou ao destino
        if (graph.GetPath().Count == 0 || currentWaypointIndex == graph.GetPath().Count) return;

        // se chegou ao destino, pega o próximo waypoint
        if (Vector3.Distance(graph.GetPath()[currentWaypointIndex].
            getIdCaminho().transform.position, transform.position) < accuracy)
        {
            currentWaypoints = graph.GetPath()[currentWaypointIndex].getIdCaminho();
            currentWaypointIndex++;
        }

        // se não chegou, continua indo para o waypoint olhando para ele
        if (currentWaypointIndex < graph.GetPath().Count)
        {
            target = graph.GetPath()[currentWaypointIndex].getIdCaminho().transform;
            Vector3 lookAtTarget = new Vector3(target.position.x, transform.position.y, target.position.z);
            Vector3 direction = lookAtTarget - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                Time.deltaTime * rotSpeed);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    

    //Botoes


    public void GFechar()
    {
        Application.Quit();
    }

    public void GBateria()
    {
        graph.aEstrela(currentWaypoints, waypoints[6]);
        currentWaypointIndex = 0;
    }
    public void Gdormir()
    {
        graph.aEstrela(currentWaypoints, waypoints[13]);
        currentWaypointIndex = 0;
    }
    public void GCozinhar()
    {
        graph.aEstrela(currentWaypoints, waypoints[14]);
        currentWaypointIndex = 0;
    }
    public void GSofa()
    {
        graph.aEstrela(currentWaypoints, waypoints[1]);
        currentWaypointIndex = 0;
    }
    public void GLavarMaos()
    {
        graph.aEstrela(currentWaypoints, waypoints[3]);
        currentWaypointIndex = 0;
    }
    public void GBanho()
    {
        graph.aEstrela(currentWaypoints, waypoints[11]);
        currentWaypointIndex = 0;
    }
    public void GJogar()
    {
        graph.aEstrela(currentWaypoints, waypoints[5]);
        currentWaypointIndex = 0;
    }
    public void GRoupa()
    {
        graph.aEstrela(currentWaypoints, waypoints[8]);
        currentWaypointIndex = 0;        
    }
    public void GTV()
    {
        graph.aEstrela(currentWaypoints, waypoints[15]);
        currentWaypointIndex = 0;
    }
    public void GSairCasa()
    {
        graph.aEstrela(currentWaypoints, waypoints[18]);
        currentWaypointIndex = 0;

    }
    public void GRoupaLavar()
    {
        graph.aEstrela(currentWaypoints, waypoints[9]);
        currentWaypointIndex = 0;
    }
    public void GJantar()
    {
        graph.aEstrela(currentWaypoints, waypoints[16]);
        currentWaypointIndex = 0;
    }


}
