using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public Collider2D boxCollider;
    public int numberRandomPositions = 10;

    public List<GameObject> prefabPool;

    // Start is called before the first frame update
    void Start()
    {
        if (boxCollider == null)
        {
            GetComponent<Collider2D>();
        }
        if (boxCollider == null)
        {
            Debug.Log("Please assign Collider2D component.");
        }

        
        //int prefabSpawned = Random.Range(0, prefabPool.Count);
        //GameObject toSpawn = prefabPool[prefabSpawned];

        int i = 0;
        while (i < numberRandomPositions)
        {
            Vector3 rndPoint3D = RandomPointInBounds(boxCollider.bounds, 1f);
            Vector2 rndPoint2D = new Vector2(rndPoint3D.x, rndPoint3D.y);
            Vector2 rndPointInside = boxCollider.ClosestPoint(new Vector2(rndPoint2D.x, rndPoint2D.y));

            if (rndPointInside.x == rndPoint2D.x && rndPointInside.y == rndPoint2D.y)
            {
                GameObject rndCube = Instantiate(prefabPool[Random.Range(0, prefabPool.Count)], rndPointInside, Quaternion.identity);
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
