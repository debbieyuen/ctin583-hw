using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* TODO: Problem 1: GENERICS SHORT ANSWER QUESTIONS
    * What is Unity's `GetComponent<T>`? Why is it considered a generic method?
    * In generics, there is a particular convention we follow in defining generics. What leter do we use to represent a placeholder type or generic? In generics, what are the naming conventions used if we have more than one parameter? 
    * What does the generic variable do? Why does it end up as the return type and argument type for a method? 
    * Give a realistic and detailed example of when you would want to use generics in your game. When would type variables be useful?
    * What are the performance implications of using generic arrays as opposed to non-generic arrays in C#?
    * What does it mean to instantiate? */

    // 1. GetComponent<T> is a method in Unity that retrieves a component of type T attached to a GameObject. It's considered a generic method because it works with any component type.
    // 2. The letter T is used to represent a placeholder type or generic. For multiple parameters, the naming conventions for generics are either T1, T2, etc or more meaningful names like TValue, TKey.
    // 3. The generic variable acts as a placeholder for whatever type is used when the class/method is actually used. It is both the return type and argument type to ensure type safety throughout the method being run and allows for compile-time type checking.
    // 4. An example of using generics in a game could be game inventory, where there are different inventory for different types, such as Inventory<Weapon> and Inventory<Poition>
    // 5. Generic arrays are type-safe and have no boxing or unboxing overhead, and tend to perform similar as non-generic arrays because the compiler knows the exact type at runtime.
    //    On the other hand, non-generic arrays are prone to runtime errors due to incorrect type casting.
    // 6. To instantiate means to create a specific instance of a class or type and allocating memory for the object.

public class BarbieWorld<T>
{
    T item; 
    T currentCareer; // added

    /* TODO: Problem 2: BARBIE'S CAREERS: Barbie wears many hats. She is a photographer,
    singer, athlete, painter, musician, rockstar, and much more.
    What is the function below trying to accomplish?
    How are we using the T variable in this case?
    Please instantiate an item of this class in  
    your BarbieWalletBalance.cs file in your
    Start() or Update() functions. */

    // The function below allows Barbie to switch to any type of career. Its use of generics allows for type safety and makes the career system
    // flexible enough for strings, enums, or classes
    public void BarbieCareers(T newCareer) {
        currentCareer = newCareer;
    }
}