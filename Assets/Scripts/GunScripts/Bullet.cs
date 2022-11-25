using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public Rigidbody rb;
   public GameObject explosion;
   public LayerMask whatEnemies;

   //Stats
   [Range(0f, 1f)] 
   public float bounciness;
   public bool useGravity;

    //Damage
   public int explosionDamage;
   public float explosionRange;
   public float explosionForce;

   public int maxCollisions;
   public float maxLifetime;
   public bool explodeOnTouch = true;

   int collisions;
   PhysicMaterial physics_mat;

   private void Start()
   {
        Setup();
   }

   private void Update()
   {
        //When to explode
        if(collisions > maxCollisions) Explode();

        maxLifetime -= Time.deltaTime;
        if(maxLifetime <= 0) Explode();
   }

   private void Explode()
   {
        //Start explosion
        if(explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        //Check for enemies
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatEnemies);
        for(int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i].GetComponent<Rigidbody>())
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange);
                enemies[i].GetComponent<EnemyAI>().TakeDamage(explosionDamage);
        }
        //Add delay to make sure everything works fine
        Invoke("Delay", 0.05f);
   }

   private void Delay()
   {
        Destroy(gameObject);
   }

   private void OnCollisionEnter(Collision collision)
   {
        if(collision.collider.CompareTag("Bullet")) return;

        //Count Up Collisions
        collisions++;

        //Explode if bullet hits an enemy directly
        if(collision.collider.CompareTag("Enemy") && explodeOnTouch) Explode();
   }

   private void Setup()
   {
    //New physic material
    physics_mat = new PhysicMaterial();
    physics_mat.bounciness = bounciness;
    physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
    physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
    //Asign material to collider
    GetComponent<SphereCollider>().material = physics_mat;

    //Set gravity
    rb.useGravity = useGravity;
   }
}
