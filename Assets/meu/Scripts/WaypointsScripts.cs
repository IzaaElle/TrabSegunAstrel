using UnityEngine;

public class WaypointsScripts : MonoBehaviour
{
    int estouAquiPonto = 0;
    public GameObject[] pontosWay;
    public Link[] coneccoes;
    public GrathScript graph = new GrathScript();

    [SerializeField] private float velo = 5f;

    private void Start()
    {
        if(pontosWay.Length > 0)
        {
            foreach (GameObject waypoint in pontosWay) graph.AdicionarNode(waypoint);

            foreach (Link link in coneccoes)
            {
                graph.AdicionarLinha(link.no1, link.no2);

                if (link.direcao == Link.Direction.BiDrecao)
                    graph.AdicionarLinha(link.no2, link.no1);
            }
        }
        
        
    }


















}
