using UnityEngine;
using System.Collections;

public class Col_Player : MonoBehaviour
{
    Mov_Player Mov_player;
    Ctrl_Dialog dialog;
    bool Entrando = false;
    public GameObject WindowsDialog;
    string nameColision;
    public bool colidiuNpc = false;
    void Start()
    {
        Mov_player = FindObjectOfType(typeof(Mov_Player)) as Mov_Player;
        dialog = FindObjectOfType(typeof(Ctrl_Dialog)) as Ctrl_Dialog;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)&& colidiuNpc)
        {
     
            dialog.Iniciar(nameColision);
            //colidiuNpc = false;
        }
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.name == "Porta")
            Mov_player.StopMoviment=true;

        if (Col.gameObject.CompareTag("Npc"))
        {
            WindowsDialog.SetActive(true);
            colidiuNpc = true;
            nameColision = Col.gameObject.name.ToString();
        }
    }

    void OnTriggerExit2D(Collider2D Col)
    {
        if (Col.gameObject.CompareTag("Npc"))
        {
            WindowsDialog.SetActive(false);
            colidiuNpc = false;
        }
    }
}