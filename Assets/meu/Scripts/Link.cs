using System;
using UnityEngine;

[Serializable]

public class Link
{
    public enum Direction
    {
        UmaDirecao,
        BiDrecao
    }
    public GameObject no1;
    public GameObject no2;
    public Direction direcao;

}
