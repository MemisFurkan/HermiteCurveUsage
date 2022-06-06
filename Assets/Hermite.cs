using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hermite : MonoBehaviour
{
    public Transform bslngc0;
    public Transform bslngc1;
    public Transform bts0;
    public Transform bts1;
    List<Vector2> positions;
    Vector3 bslngc0pos;
    Vector3 bslng1pos;
    Vector3 bts0pos;
    Vector3 bts1pos;
    float ytrlizmn = 2.5f;
    float gcnzmn;
    bool turbitti=false;

    
    private void Awake()
    {
        positions = new List<Vector2>();
    }
    private void Start()
    {
        
        bslngc0pos = bslngc1.position;
        bslng1pos = bts1.position;
        bts1pos = bslngc0pos;
        bts0pos = bslng1pos;
        for (float i = 0; i < 1f; i += .01f)
        {
            float x = ((2 * Mathf.Pow(i, 3) - 3 * Mathf.Pow(i, 2) + 1) * bslngc0.position.x) + ((-2 * Mathf.Pow(i, 3) + 3 * Mathf.Pow(i, 2)) * bts0.position.x) + ((Mathf.Pow(i, 3) - 2 * Mathf.Pow(i, 2) + i) * bslngc1.position.x) + ((Mathf.Pow(i, 3) - Mathf.Pow(i, 2)) * bts1.position.x);
            float y = ((2 * Mathf.Pow(i, 3) - 3 * Mathf.Pow(i, 2) + 1) * bslngc0.position.y) + ((-2 * Mathf.Pow(i, 3) + 3 * Mathf.Pow(i, 2)) * bts0.position.y) + ((Mathf.Pow(i, 3) - 2 * Mathf.Pow(i, 2) + i) * bslngc1.position.y) + ((Mathf.Pow(i, 3) - Mathf.Pow(i, 2)) * bts1.position.y);
            
            positions.Add(new Vector2(x, y));
        }
    }

    
    void Update()
    {
        gcnzmn += Time.deltaTime;
        float percentage = gcnzmn / ytrlizmn;
        if (!turbitti)
        {
            bslngc1.position = Vector2.Lerp(bslngc0pos, bts0pos, Mathf.SmoothStep(0, 1, percentage));
            bts1.position = Vector2.Lerp(bslng1pos, bts1pos, Mathf.SmoothStep(0, 1, percentage));
        }
        else
        {
            bslngc1.position = Vector2.Lerp(bts0pos, bslngc0pos, Mathf.SmoothStep(0, 1, percentage));
            bts1.position = Vector2.Lerp(bts1pos, bslng1pos, Mathf.SmoothStep(0, 1, percentage));
        }
        
        for (float i = 0; i < 1f; i += .01f)
        {
            float x = ((2 * Mathf.Pow(i, 3) - 3 * Mathf.Pow(i, 2) + 1) * bslngc0.position.x) + ((-2 * Mathf.Pow(i, 3) + 3 * Mathf.Pow(i, 2)) * bts0.position.x) + ((Mathf.Pow(i, 3) - 2 * Mathf.Pow(i, 2) + i) * bslngc1.position.x) + ((Mathf.Pow(i, 3) - Mathf.Pow(i, 2)) * bts1.position.x);
            float y = ((2 * Mathf.Pow(i, 3) - 3 * Mathf.Pow(i, 2) + 1) * bslngc0.position.y) + ((-2 * Mathf.Pow(i, 3) + 3 * Mathf.Pow(i, 2)) * bts0.position.y) + ((Mathf.Pow(i, 3) - 2 * Mathf.Pow(i, 2) + i) * bslngc1.position.y) + ((Mathf.Pow(i, 3) - Mathf.Pow(i, 2)) * bts1.position.y);
            int index = Mathf.RoundToInt(i * 100);
            positions[index]=new Vector2(x,y);
        }
        if (percentage > 1)
        {
            gcnzmn = 0;
            if (turbitti)
            {
                turbitti = false;
                
            }
            else
            {
                turbitti = true;
                
            }
        }
        
    }
    private void OnDrawGizmos()
    {
        if (positions != null)
        {
            foreach (Vector2 pos in positions)
            {
                Gizmos.DrawSphere(pos, .3f);
            }
        }
        
    }
}
