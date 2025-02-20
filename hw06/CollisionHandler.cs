using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;

/* 
******************************************************************************************************
    Problem 1: TODO: Finish the case statements for each collectible item listed in CollectibleItems.cs

    Problem 2: TODO: Currently each case statement is written as a string. Enums are especially helpful 
    in preventing spelling mistakes. Instead of using strings such as "Enemy" and "Gem", lets use an enum. 
    Please modify each case statement to use an enum instead. 

    Problem 3: TODO: Define a normal tuple and a value tuple. When would you use a value tuple? 
    Print out each value in your defined tuple with Debug.Log

    Problem 4: TODO: Define a new enum within this file taking in different types of particles. 
    Examples include: FireParticles, GoldRibbons, Snowflakes, RainParticles, etc. 

    Problem 5: TODO: 
        * When would you use a tuple over a struct?
        * How do we acces items in a tuple?
        * Try visualizing your enum in the Unity Editor. How does it appear as?

******************************************************************************************************
*/

// Problem 4: Define a new enum for different types of particles
public enum Particles {
    FireParticles,
    GoldRibbons,
    Snowflakes,
    RainParticles,
    SparkleParticles,
    BubbleParticles
}

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private ParticleSystem enemyParticles;
    [SerializeField] private CollectibleItems collectibles; 

    private void OnCollisionEnter(Collision collision) {
        // Problem 2: Use enum instead of strings for case statements
        CollectibleItems collidedItem;

        if(System.Enum.TryParse(collision.gameObject.tag, out collidedItem)) {
            switch (collidedItem) {

                // Problem 1: finish case statements for each collectible item
                case CollectibleItems.Enemy:
                    Destroy(gameObject);
                    break;

                case CollectibleItems.Gem:
                    meshRenderer.material = collision.gameObject.GetComponent<Renderer>().material;
                    Destroy(collision.gameObject);
                    PlayParticles();
                    break;

                case CollectibleItems.Bomb:
                Destroy(collision.gameObject);
                Destroy(gameObject, 0.5f);
                PlayParticles();
                    break;

                case CollectibleItems.Rock:
                    GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse); // bounce with force
                    break;

                case CollectibleItems.Leaf:
                    GetComponent<Rigidbody>().mass *= 0.5f; // make player temporarily float/lighter
                    Destroy(collision.gameObject);
                    break;

                case CollectibleItems.Flower:
                    transform.localScale *= 1.25f; // increase player size
                    Destroy(collision.gameObject);
                    break;

                case CollectibleItems.Fake:
                    Destroy(collision.gameObject); // disappears w/o effect
                    break;

                case CollectibleItems.Player: 
                    Physics.IgnoreCollision(collision.collider, GetComponent<Collider>()); // handle player-to-player collision
                    break;

                default:
                    break;
            }
        }
    }

    // Check to make sure our value is defined
    private bool IsCollectibleItem(CollectibleItems collectible) {
        return (collectibles & collectible) != 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the tag based on the enum
        gameObject.tag = collectibles.ToString();

        // Problem 3: Define normal tuple and value tuple
        // Normal tuple
        System.Tuple<string, int, bool> normalTuple = new System.Tuple<string, int, bool>("Player", 100, true);

        // Value tuple
        (string name, int health, bool isActive) valueTuple = ("Player", 100, true);

        // When to use value tuple:
        // A: When you need a lightweight, short-lived data structure with named elements without creating a class or struct

        // Print tuple values
        Debug.Log($"Normal Tuple—Item1: {normalTuple.Item1}, Item2: {normalTuple.Item2}, Item3: {normalTuple.Item3}");
        Debug.Log($"Value Tuple—name: {valueTuple.name}, health: {valueTuple.health}, isActive: {valueTuple.isActive}");

        // Problem 5
        // A1: You would use a tuple over a struct when you need a quick, lightweight, and temporary grouping 
        //     of related values without defining a new type; structs are better for more complex data structures.
        // A2: We access items in a tuple by using dot notation with named elements or index-based access.
        // A3: In the Unity Editor, enum appears as a drop-down menu in the Inspector when used as serialized fields.
    }
}
