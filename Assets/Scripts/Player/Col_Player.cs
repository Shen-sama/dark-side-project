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

    public Vector3 positionNpc;
    bool olharNpc;
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
            olharNpc = true;
        }

        if (olharNpc)
        {
            var lookPos = positionNpc - transform.position;
            lookPos.y = 0; var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 20);
        }
    }

    void OnTriggerEnter(Collider Col)
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

    void OnTriggerStay(Collider Col)
    {
        positionNpc = Col.gameObject.transform.position;//Armazena a position do Npc q eu estiver colidindo.
    }

        void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.CompareTag("Npc"))
        {
            WindowsDialog.SetActive(false);
            colidiuNpc = false;
            olharNpc = false;
        }
    }
}