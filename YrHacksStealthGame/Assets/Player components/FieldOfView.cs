using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] MousePosition mousePosition;
    [SerializeField] playerController playerController;
    [SerializeField] enemy enemy;
    // Start is called before the first frame update
    private Mesh mesh;
     Vector3 origin = Vector3.zero;
     float startAngle;
     private float fov;
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 90f;
    }

    private void Update(){
        SetAimDirection((GetMouseWorldPosition() - playerController.transform.position).normalized);
        SetOrigin(playerController.transform.position);
        int rayCount = 50;
        float viewDistance = 25f;
        float angle = startAngle;
        float angleIncrease = fov / rayCount;



        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;
        int vertexIndex = 1;
        int triangleIndex = 0;
        bool detected = false;
        for (int i = 0; i <= rayCount; i++) {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D.collider == null) {
                // No hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
                if(detected == false){
                enemy.SpriteDisabled();
                }
            } else {
                // Hit object
                vertex = raycastHit2D.point;
                if(raycastHit2D.collider.tag.Equals("Enemy")){
                    enemy.SpriteEnabled();
                    detected = true;
                }else{
                }
            }
            vertices[vertexIndex] = vertex;

            if (i > 0) {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    private Vector3 GetVectorFromAngle(float angle){
        float angleRad = angle * (Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
    private float GetAngleFromVectorFloat(Vector3 dir){
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg;
        if(n<0) n+=360;
        return n;
    }
    public Vector3 GetMouseWorldPosition() {
    Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mouseWorldPosition.z = 0f;
    return mouseWorldPosition;
}

    public void SetOrigin(Vector3 origin){
        this.origin = origin;
    }
    public void SetAimDirection(Vector3 aimDirection){
        startAngle = GetAngleFromVectorFloat(aimDirection) + fov/2f;
    }
}

