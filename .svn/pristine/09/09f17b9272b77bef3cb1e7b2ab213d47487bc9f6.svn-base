using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICompareSample : MonoBehaviour
{
    public List<Person> items = new List<Person>();
    // Start is called before the first frame update
    void Start()
    {
        /*
        items.Sort();
        int index= items.BinarySearch(new Person { name = "DEF" });
        Debug.LogError(index);
        */
        PersonCompare personCompare = new PersonCompare();
        items.Sort(personCompare);
        Person key = new Person();
        key.age = 18;
        key.name = "DF";
        key.Sample(1, 2, 3, 4, 5);
        int index = items.BinarySearch(key, personCompare);
        Debug.LogError(index);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
[Serializable]
public class Person : IComparable<Person>
{
    public int age;
    public string name;

    public int CompareTo(Person other)
    {
        return this.name.CompareTo(other.name);
    }
    public void Sample(params int[] n_params)
    {
        int total = 0;

        for (int i = 0; i < n_params.Length; i++)
        {
            total += n_params[i];
        }
        Debug.LogError(total);
    }
}
public class PersonCompare : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (x.age < y.age)
        {
            return -1;
        }
        else if (x.age > y.age)
        {
            return 1;
        }
        else
        {
            return x.CompareTo(y);
        }
    }
}