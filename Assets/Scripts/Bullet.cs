using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public int damage = 50;

    public float speed = 70f;
    public GameObject imputEffect;

    public float explosionRadius = 0f;

    public void seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisTrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisTrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisTrame, Space.World);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(imputEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        /*
        if (explosionRadius > 0f)
        {
            // Explode();
            Damage(target);

        }
        else
        {
            Damage(target);
        }
        */
        Damage(target);
        //Destroy(target.gameObject);·F
        Destroy(gameObject);
    }
    /*
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }    
    */
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }    
    /*
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }    
    */
}
