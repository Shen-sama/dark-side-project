using UnityEngine;
using System.Collections;

public class consumivel : DefaulItem
{
    public enum especialidade { HpRecuperado, MpRecuperado }
    public bool reviver;
    public int quantidade;

    public consumivel(tipoAdquirir TipoAdquirir, string Descricao, string Nome, int QtdPermitida,
         especialidade Especialidade,bool Reviver,int Quantidade)
    {

    }
}
