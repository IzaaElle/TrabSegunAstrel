using System.Collections.Generic;
using UnityEngine;

public class NodeScript
{
    public List<EdgeScript> edges = new List<EdgeScript>();
    public NodeScript caminho = null;
    GameObject idCaminho;
    public float fCusto, gCusto, hCusto;
    public NodeScript pai;

    public NodeScript(GameObject idQualquer)
    {
        this.idCaminho = idQualquer;
        caminho = null;
    }

    public GameObject getIdCaminho()
    {
        return idCaminho;
    }

}
