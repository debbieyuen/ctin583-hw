using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* TODO: Problem 5: BARBIES HOUSE
Barbie's House needs to inherit everything from the BarbieWorld class in your
BarbieWorld.cs file. Please modify the BarbieHouse class to inherit from
BarbieWorld and write at least three methods within BarbieHouse representing 
furniture, pets, household items, food, etc. within her house. 
*/ 
public class BarbieHouse<T> : BarbieWorld<T> {
    private List<string> furniture;
    private List<string> pets;
    private List<string> food;

    // initalize the lists
    public BarbieHouse() {
        furniture = new List<string>();
        pets = new List<string>();
        food = new List<string>();
    }

    // method for adding furniture
    public void AddFurniture(string furnitureItem) {
        furniture.Add(furnitureItem);
        Debug.Log($"Added {furnitureItem} to Barbie's house!");
    }

    // method for adding pets
    public void AdoptPet(string petName) {
        pets.Add(petName);
        Debug.Log($"Welcome {petName} to Barbie's house!");
    }

    // method for stocking the kitchen
    public void StockKitchen(string foodItem) {
        food.Add(foodItem);
        Debug.Log($"Added {foodItem} to Barbie's kitchen!");
    }
}