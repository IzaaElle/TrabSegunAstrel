using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GrathScript
{
    List<EdgeScript> edges = new List<EdgeScript>();
    List<NodeScript> nodes = new List<NodeScript>();
    List<NodeScript> path = new List<NodeScript>();

    public GrathScript() { }


    public void AdicionarNode(GameObject IdQualquerOutro)
    {
        NodeScript node = new (IdQualquerOutro);
        nodes.Add(node);
    }

    NodeScript AcharNode(GameObject IdQualquerOutroOutro)
    {
        foreach (NodeScript esse in nodes)
        {
            if (esse.getIdCaminho() ==IdQualquerOutroOutro)
            { return esse; }
        }
        return null;
    }
    public void AdicionarLinha(GameObject deNode, GameObject paraNode)
    {
        NodeScript de = AcharNode(deNode);
        NodeScript para = AcharNode(paraNode);
        if (de !=null && para != null)
        {
            EdgeScript edge = new EdgeScript(de, para);
            edges.Add(edge);
            de.edges.Add(edge);
        }
    }
    float HeuAlgumaCoisa(NodeScript pontoA, NodeScript pontoB)
    {
        Vector3 direct = pontoA.getIdCaminho().transform.position - pontoB.getIdCaminho().transform.position;
        return direct.sqrMagnitude;
    }
    int MenorCustoF(List<NodeScript> ListarNode)
    {
        float menor = ListarNode[0].fCusto;
        int conta = 0;
        int menorIndex = 0;
        for(int i = 1; i < ListarNode.Count; i++)
        {
            if (ListarNode[i].fCusto < menor)
            {
                menor = ListarNode[i].fCusto;
                menorIndex = conta;
            }
            conta++;
        }
        return menorIndex;
    }

    public bool aEstrela(GameObject pontoInicial, GameObject pontoFinal)
    {
        if (pontoInicial == pontoFinal)
        {
            path.Clear();
            return false;
        }
        NodeScript startNode = AcharNode(pontoInicial);
        NodeScript endNode = AcharNode(pontoFinal);
        if(startNode == null || endNode == null)
        {
            return false;
        }
        List<NodeScript> abrirSet = new List<NodeScript>();
        List<NodeScript> fecharSet = new List<NodeScript>();
        float testGCusto = 0;
        bool testeDeuBom = false;

        startNode.gCusto = 0;
        startNode.hCusto = HeuAlgumaCoisa(startNode, endNode);
        startNode.fCusto = startNode.gCusto + startNode.hCusto;

        abrirSet.Add(startNode);

        while (abrirSet.Count > 0)
        {
            int i = MenorCustoF(abrirSet);
            NodeScript esseNode = abrirSet[i];
            if(esseNode.getIdCaminho() == endNode.getIdCaminho())
            {
                return true;
            }
        abrirSet.RemoveAt(i);
        fecharSet.Add(esseNode);
        NodeScript visinho;


            foreach (EdgeScript esse in esseNode.edges)
            {
                visinho = esse.endNode;
                if (fecharSet.IndexOf(visinho) > -1)
                {
                    continue;
                }
                testGCusto = esseNode.gCusto + HeuAlgumaCoisa(esseNode, visinho);

            }

        }
        return false;
    }

    void REconstructPath(NodeScript start, NodeScript end)
    {
        path.Clear();
        path.Add(end);
        NodeScript current = end.pai;
        while (current != null && current != start)
        {
            path.Insert(0, current);
            current = current.pai;
        }
        path.Insert(0, start);
        
    }





}
