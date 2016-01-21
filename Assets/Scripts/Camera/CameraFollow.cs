using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform player;
    private float posX;
    private float posY;

    public float ajusteX;
    public float ajusteY;

    public float transition;
    public bool IsSuavizacaoX;
    public bool IsSuavizacaoY;

    //Limit Camera
     public  Transform LE;
     public Transform LD;

    private float posY_Cam;
    void Start () {
        //player = GameObject.Find("Player").transform;
	}
	
	void Update () {
        posX = player.position.x+ ajusteX;
        posY = player.position.y+ ajusteY;

        if (IsSuavizacaoY)
            posY_Cam = posY + ajusteY;
        else
            posY_Cam = transform.position.y;

        if (posX > LE.position.x && posX < LD.position.x)
        {
            if(IsSuavizacaoX)
                transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY_Cam, transform.position.z), transition);
            else
                transform.position =new Vector3(posX, posY_Cam, transform.position.z);
        }
        else//Ajusta o Limite da camera quando o Lerp estiver Ativado.
        {
            if (IsSuavizacaoX && transform.position.x > LE.position.x && transform.position.x < LD.position.x)
                transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY_Cam, transform.position.z), transition);
        }

    }
}
