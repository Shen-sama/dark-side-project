using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    public Transform[] waypointArray;
    public Transform character;
    public enum Direction { Forward, Reverse };

    private float pathPosition = 0;
    private RaycastHit hit;
    private float speed = .2f;
    private float rayLength = 5;
    private Direction characterDirection;
    private Vector3 floorPosition;
    private float lookAheadAmount = .01f;
    private float ySpeed = 0;
    private float gravity = .5f;
    private float jumpForce = .12f;
    private uint jumpState = 0; //0=grounded 1=jumping
    public float percentsPerSecond = 0.2f; // %2 of the path moved per second
    float currentPathPercent = 0.0f; //min 0, max 1

    float pathVelocity;
    float pathLength = 0;
    Vector3 lookTarget;
    void OnDrawGizmos()
    {
        iTween.DrawPath(waypointArray, Color.blue);
    }
    void Start()
    {
        //plop as peças de caracteres no " Ignorar Raycast " camada de modo que não temos dados raycast falsos:	
        pathLength = iTween.PathLength(waypointArray);
        pathVelocity = pathLength * percentsPerSecond;

        Calcular();

        foreach (Transform child in character)       
            child.gameObject.layer = 2; 
    }

    void Calcular()
    {
        float deltaPercent = percentsPerSecond * Time.deltaTime;
        Vector3 nextPoint = iTween.PointOnPath(waypointArray, currentPathPercent + deltaPercent);
        float calcDist = Vector3.Magnitude(nextPoint - character.position);
        float calcVelocity = calcDist / Time.deltaTime;
        float velocityScale = pathVelocity / calcVelocity;            // if we are going at double velocity, velocityScale is 1/2; if at half vel, it's 2

        currentPathPercent += (deltaPercent * velocityScale);
        // For looping
        if (currentPathPercent > 1.0f)
            currentPathPercent -= 1.0f;
        else if (currentPathPercent < 0)
            currentPathPercent += 1.0f;

        iTween.PutOnPath(character.gameObject, waypointArray, currentPathPercent);
        Calcular2();
    }

    void Calcular2()
    {
        if (currentPathPercent - lookAheadAmount >= 0 && currentPathPercent + lookAheadAmount <= 1)
        {
            //líder ou ponto de fuga para que possamos ter algo para olhar:
            if (characterDirection == Direction.Forward)
                lookTarget = iTween.PointOnPath(waypointArray, currentPathPercent + lookAheadAmount);
            else
                lookTarget = iTween.PointOnPath(waypointArray, currentPathPercent - lookAheadAmount);
            //look:
            character.LookAt(lookTarget);
            // anular todas as rotações , mas y uma vez que só quero olhar para onde estamos indo :
            float yRot = character.eulerAngles.y;
            character.eulerAngles = new Vector3(0, yRot, 0);
        }
    }
    void Update()
    {
        //DetectKeys();
        //FindFloorAndRotation();
        //MoveCharacter();

        if (Input.GetKeyDown("left"))        
            characterDirection = Direction.Forward;
        
        if (Input.GetKeyDown("right"))       
            characterDirection = Direction.Reverse;
        
        if (Input.GetKey("left"))
        {
            Calcular();
            iTween.PutOnPath(character.gameObject, waypointArray, currentPathPercent);
        }

        if (Input.GetKey("right"))
        {
            float deltaPercent = percentsPerSecond * Time.deltaTime;
            Vector3 nextPoint = iTween.PointOnPath(waypointArray, currentPathPercent + deltaPercent);
            float calcDist = Vector3.Magnitude(nextPoint - character.position);
            float calcVelocity = calcDist / Time.deltaTime;
            float velocityScale = -(pathVelocity) / calcVelocity;
            // if we are going at double velocity, velocityScale is 1/2; if at half vel, it's 2
            currentPathPercent += (deltaPercent * velocityScale);
            // For looping
            if (currentPathPercent > 1.0f)
                currentPathPercent -= 1.0f;
            else if (currentPathPercent < 0)
                currentPathPercent += 1.0f;

            Calcular2();

            iTween.PutOnPath(character.gameObject, waypointArray, currentPathPercent);
        }
        //MoveCamera();
    }

    void FindFloorAndRotation()
    {
        float pathPercent = pathPosition % 1;
        Vector3 coordinateOnPath = iTween.PointOnPath(waypointArray, pathPercent);
        Vector3 lookTarget;

        //calcular dados olhar se não vamos estar a olhar além das extensões do caminho
        Calcular2();

        if (Physics.Raycast(coordinateOnPath, -Vector3.up, out hit, rayLength))
            //Debug.DrawRay(coordinateOnPath, -Vector3.up * hit.distance);
            floorPosition = hit.point;
    }
    void DetectKeys()
    {
        //forward path movement:
        if (Input.GetKeyDown("left")) 
             characterDirection = Direction.Forward;

        if (Input.GetKey("left"))
            pathPosition += Time.deltaTime * (speed);

        //giro do personagem:
        if (Input.GetKeyDown("right"))
            characterDirection = Direction.Reverse;

        if (Input.GetKey("right"))
        {
            //   lidar com ciclo caminho em torno de uma vez que não pode interpolar uma percentagem caminho que é negativo(bem duh):
            float temp = pathPosition - (Time.deltaTime * (speed));

            if (temp < 0)
                pathPosition = 1;
            else
                pathPosition -= (Time.deltaTime * (speed));
        }

        ////jump:
        //if (Input.GetKeyDown("space") && jumpState==0) {
        //	ySpeed-=jumpForce;
        //	jumpState=1;
        //}
    }
    void MoveCharacter()
    {
        //add gravity:
        ySpeed += gravity * Time.deltaTime;

        //apply gravity:
        character.position = new Vector3(floorPosition.x, character.position.y - ySpeed, floorPosition.z);

        //floor checking:
        if (character.position.y < floorPosition.y)
        {
            ySpeed = 0;
            jumpState = 0;
            character.position = new Vector3(floorPosition.x, floorPosition.y, floorPosition.z);
        }
    }
    //void MoveCamera(){
    //	iTween.MoveUpdate(Camera.main.gameObject,new Vector3(character.position.x,2.7f,character.position.z-5f),.9f);	
    //}
}