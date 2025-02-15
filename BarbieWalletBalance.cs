using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbieBank : MonoBehaviour
{

    // Start is called before the first frame update

    /* TODO: Problem 3: BARBIE'S BANK
    Convert the following function to a generic if needed. 
    Then, write a private generic function named BarbieBank. 
    BarbieBank should take in the parameters: numOfPennies, cashAmount, and numOfCreditCards
    Have the function return a new generic array with the correct parameters. 
    */

    void Start()
    {
        // instantiate BarbieWorld instance with string type for careers
        BarbieWorld<string> barbieCareer = new BarbieWorld<string>();
        // set Barbie's career
        barbieCareer.BarbieCareers("Astronaut");

        int[] biggerWallet = BarbieWallet(500, 600);
        Debug.Log(biggerWallet.Length + " " + biggerWallet[0] + " " + biggerWallet[1]);

        GetMoney(500, 600);

        // call BarbieBank
        int[] barbieFinances = BarbieBank(1000, 5000, 3);
        Debug.Log($"BarbieBank Length: {barbieFinances.Length} | Pennies: {barbieFinances[0]} | Cash: {barbieFinances[1]} | Credit Cards: {barbieFinances[2]}");

        // call KenWallet
        KenWallet(100, 200);
    }

    // BarbieBank, generic method w/ 3 params
    private T[] BarbieBank<T>(T numOfPennies, T cashAmount, T numOfCreditCards) {
        T[] wallet = new T[3];
        wallet[0] = numOfPennies;
        wallet[1] = cashAmount;
        wallet[2] = numOfCreditCards;
        return wallet;
    }

    // BarbieWallet, generic method w/ 2 params
    private T[] BarbieWallet<T>(T numOfPennies, T cashAmount) {
        T[] wallet = new T[2];
        wallet[0] = numOfPennies;
        wallet[1] = cashAmount;
        return wallet;
    }

    // GetMoney method
    private void GetMoney(int cashAmount, int savingsAmount)
    {
        int total = cashAmount + savingsAmount;
        Debug.Log($"Barbie's Total Money: ${total}");
    }

    /* TODO: Problem 4: INHERITANCE: SHORT ANSWERS
        * What is the "Protected" access modifier? How does it relate to inheritence and between two classes. 
        * What is MonoBehaviour? Why do Unity C# scripts inherit from MonoBehaviour? Give some examples of Unity functions that come from MonoBehaviour. 
        * What is multiple inheritance? Can we perform multiple inheritance in C#? Why or why not?
        * What does "Protected virtual void" mean? When is it needed and what does virtual do in your code?
        * What happens when a constructor in a parent class is called? How do we control which base class contructor is being called?
     */ 

        // 1. The "Protected" modifier means that the member is accessible within its own class and by classes that inherit from this class. In other words, 
        //    child classes are able to access the parent class's members while the members are hidden from other classes that do not inherit from the parent class.
        // 2. MonoBehavior is the base class from which every Unity script derives. It provides methods for Unity's events such as Start(), Update(), OnCollisionEnter(), and etc.
        // 3. Multiple inheritance is when a class inherits from more than one parent class. C# does not support multiple inheritance due to ambiguity in methods from multiple parent classes. 
        //    instead, C# supports multiple interfaces.
        // 4. As aforementioned, "protected" means that the method is accessible only within its class and child classes. "Virtual" means that the method can be overridden by a child class that writes  
        //    its own implementation of this method. Lastly, "void" means that it does not return anything, but performs an action.
        // 5. When a child class is instantiated, the parent class constructor is called first to initialize the base part of the object. We can control which base class constructor 
        //    is being called by using the "base" keyword. 

    private void KenWallet<T1, T2>(T1 money, T2 moreMoney) {
        Debug.Log(money.GetType());
        Debug.Log(moreMoney.GetType());
    }
}