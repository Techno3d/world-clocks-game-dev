using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateBoxes : MonoBehaviour
{
    public int gridSize = 40;
    public float seperation = 1.0f;
    private GameObject[,] boxes;

    void Start() {
      boxes = new GameObject[gridSize, gridSize];
      for (int x = 0; x < gridSize; x++) {
         for (int z = 0; z < gridSize; z++) {
               Vector3 position = new Vector3(x * seperation, 0, z * seperation);
               position.y = Mathf.Pow(position.x - seperation*gridSize/2f, 2) + Mathf.Pow(position.z - seperation*gridSize/2f, 2);
               GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
               box.transform.position = position;
               box.transform.SetParent(this.transform);
               boxes[x, z] = box;
           }
       }
   }

    void Update() {
     Vector2 spinny = new Vector2(Mathf.Cos(0.5f*Time.time), Mathf.Sin(0.5f*Time.time));
      for (int x = 0; x < gridSize; x++) {
         for (int z = 0; z < gridSize; z++) {
             GameObject box = boxes[x,z];
             Vector2 funnyScale = new Vector2(box.transform.position.x, box.transform.position.z);
             funnyScale.Normalize();
             float dotBetween = Vector2.Dot(spinny, funnyScale);
             Vector3 position = new Vector3(
                 x*seperation+Mathf.Sin(0.5f*Time.time)*dotBetween,
                 box.transform.position.y,
                 z*seperation+Mathf.Sin(0.5f*Time.time)*dotBetween
             );
             position.y = Mathf.Pow(position.x - seperation*gridSize/2f, 2) + Mathf.Pow(position.z - seperation*gridSize/2f, 2);
             box.transform.position = position;
             boxes[x, z] = box;
           }
       }
        
    }
}
