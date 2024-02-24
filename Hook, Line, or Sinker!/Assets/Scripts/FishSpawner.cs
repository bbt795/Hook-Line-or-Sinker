using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public Collider2D polygonCollider;
    public int numberRandomPositions = 10;

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        if (polygonCollider == null) GetComponent<Collider2D>();
        if (polygonCollider == null) Debug.Log("Please assign Collider2D component.");

        int i = 0;
        while (i < numberRandomPositions)
        {
            Vector3 rndPoint3D = RandomPointInBounds(polygonCollider.bounds, 1f);
            Vector2 rndPoint2D = new Vector2(rndPoint3D.x, rndPoint3D.y);
            Vector2 rndPointInside = polygonCollider.ClosestPoint(new Vector2(rndPoint2D.x, rndPoint2D.y));
            if (rndPointInside.x == rndPoint2D.x && rndPointInside.y == rndPoint2D.y)
            {
                GameObject rndCube = Instantiate(prefab, rndPointInside, Quaternion.identity);
                rndCube.transform.position = rndPoint2D;
                i++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 RandomPointInBounds(Bounds bounds, float scale)
    {
        return new Vector3(
            Random.Range(bounds.min.x * scale, bounds.max.x * scale),
            Random.Range(bounds.min.y * scale, bounds.max.y * scale),
            Random.Range(bounds.min.z * scale, bounds.max.z * scale)
        );
    }
}
