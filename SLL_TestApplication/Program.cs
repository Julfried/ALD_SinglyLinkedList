using SinglyLinkedList;
using System.Reflection.Metadata;

Console.WriteLine("This Application is for testing the SLL (Singly Linked Líst)");

// Create a new empty list of strings
SinglyLinkedList<string> myTestList = new SinglyLinkedList<string>();

// Entering 6 strings for adding to the list
for (int i = 0; i < 6; i++)
{
    Console.WriteLine($"Please enter string number {i + 1} to save to the List:");
    var userinput = Console.ReadLine();

    //Check if User input is Empty
    if ( !string.IsNullOrEmpty(userinput))
    {
        myTestList.Add(userinput);  
    }
    else
    {
        myTestList.Add("emptyInput");
    }
}

// Check if the list Contains a specific string
Console.Clear();
Console.WriteLine("Now lets check if the list contains a specific string. Please enter the string you want to check:");
var checkstring = Console.ReadLine();

//Check if User input is Empty
if (string.IsNullOrEmpty(checkstring))
{
    checkstring = "emptyInput";
}

if(myTestList.Contains(checkstring))
{
    Console.WriteLine($"The List contains the string: {checkstring}");
}
else
{
    Console.WriteLine($"The List does not contain the string: {checkstring}");
}

// Get string at index
Console.WriteLine("Now let's get a string at a specific index. Please enter the index you want to check:");
var index = Convert.ToInt32(Console.ReadLine());

if (index >= 0 && index < myTestList.Count())
{
    string value = myTestList.FindByIndex(index);
    Console.WriteLine($"The value at index {index} is: {value}");
}
else
{
    Console.WriteLine("Invalid index.");
}

// Delete specific values
Console.WriteLine("Now let's delete a specific string. Please enter the string you want to delete:");
var deleteString = Console.ReadLine();

bool removed = myTestList.Remove(deleteString);

if (removed)
{
    Console.WriteLine($"The List no longer contains the string: {deleteString}");
}
else
{
    Console.WriteLine($"The List still contains the string: {deleteString}");
}


