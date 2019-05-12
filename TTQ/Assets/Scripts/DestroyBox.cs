using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject weapon;
    private void OnCollisionEnter(Collision col)
    {
        GameObject ex = Instantiate(explosion);
        ex.transform.position = transform.position;
        ex.transform.localScale = transform.localScale;
        for(int i=0;i<7;i++)
        {
            GameObject w = Instantiate(weapon);
            w.transform.position = new Vector3(transform.position.x + Random.Range(0, 5),
                transform.position.y + Random.Range(0, 5), transform.position.z + Random.Range(0, 5));
        }
        Destroy(this.gameObject);
    }
}
