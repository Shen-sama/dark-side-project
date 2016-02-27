using UnityEngine;
using System.Collections;

public class arma : DefaulItem
{
    public enum efeitos { nenhum,danoFogo, danoGelo,veneno}

    public int atackMagic;
    public int atackFisico;
    public int grau;
    public int experiencia;

    public arma(tipoAdquirir TipoAdquirir, string Descricao, string Nome, int QtdPermitida,
        efeitos Efeitos,int AtackMagic,int AtackFisico, int Grau,int Experiencia)
    {

    }
}
