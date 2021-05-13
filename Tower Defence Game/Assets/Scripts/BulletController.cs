using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public int damage = 50;
    
    public float explosionRange = 0f;
    public GameObject impactEffect;

    public void TargetSeek (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //Distance to target calc
        Vector3 dir = target.position - transform.position;
        float frameDistance = speed * Time.deltaTime;

        //Hit Detector
        if (dir.magnitude <= frameDistance)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * frameDistance, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 5f);

        if (explosionRange > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }


        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] hitObjects = Physics.OverlapSphere(transform.position, explosionRange);
        foreach (Collider hitObject in hitObjects)
        {
            if (hitObject.tag == "Enemy")
            {
                Damage(hitObject.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.DamageCalculator(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange); 
    }
}
