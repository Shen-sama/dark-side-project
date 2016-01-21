using UnityEngine;
using System.Collections;

public class Col_Player : MonoBehaviour
{
    Mov_Player Mov_player;
    bool Entrando = false;
    void Start()
    {
        Mov_player = FindObjectOfType(typeof(Mov_Player)) as Mov_Player;
    }
    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.name == "Porta")
            Mov_player.enteringPort=true;
         
    }
}