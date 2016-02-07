using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Global : MonoBehaviour {
   public string nome1;
   public string[] falaPersonagem1;

   public string nome2;
   public string[] falaPersonagem2;

    public List<Npc> npc;

    void Start () {
         npc = new List<Npc>();
         npc.Add(new Npc(nome1, falaPersonagem1));
         npc.Add(new Npc(nome2, falaPersonagem2));
       
    }
}
