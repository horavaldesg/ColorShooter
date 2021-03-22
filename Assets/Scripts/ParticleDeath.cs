using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeath : MonoBehaviour
{
    public float radius = 5f;
    public float power = 100f;
    public float liftPower = 50f;
    private ParticleSystem PSystem;
    private ParticleCollisionEvent[] CollisionEvents;

    void Start()
    {
        PSystem = GetComponent<ParticleSystem>();
}

    public void OnParticleCollision(GameObject other)
    {
        int collCount = PSystem.GetSafeCollisionEventSize();

        if (collCount > CollisionEvents.Length)
        {
            CollisionEvents = new ParticleCollisionEvent[collCount];
        }
        int eventCount = PSystem.GetCollisionEvents(other, CollisionEvents);

        for (int i = 0; i < eventCount; i++)
        {
            Explosions(CollisionEvents[i].intersection);

            //TODO: Do your collision stuff here. 
            // You can access the CollisionEvent[i] to obtaion point of intersection, normals that kind of thing
            // You can simply use "other" GameObject to access it's rigidbody to apply force, or check if it implements a class that takes damage or whatever
        }
    }

    void Explosions(Vector3 intersection)
    {

        Vector3 explosionPos = intersection;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if (hit && hit.GetComponent<Rigidbody>())
            {
                hit.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, liftPower);
            }
        }

        GetComponent<AudioSource>().Play();

    }
}
