public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // To approach this problem I need to create an array that will have a fixed capacity that is tied
        // to the second parameter of the function. Then, I need to multiply the given number with the natural numbers
        // i.e. (1, 2, 3..). I will use a loop to multiply the given number with an iterator that will increase until
        // reaches the same value as length. Inside the loop, I will add the result of the multiplication of the given
        // number and the iterator. Finally, I will return the array with the values that will be the multiples of the number 
        
        // create a fixed array with the same length as the parameter
        var result = new double[length];
        // loop to multiply every number in sequence until reaching the length value.
        for (var i = 1; i <= length; i++)
        {
            //add the value of the multiplication to the correct index (i - 1 since indexes start at 0)
            result[i - 1] = number * i;
        }

        return result; // return my new array
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // My approach to this problem is simple and uses the methods for the list type in C# 
        // First I need to get the range from the list using the GetRange method which will create a shallow copy
        // of the list. The parameters for that will be the data.Count value minus the amount which will give me the
        // value of my range. Then, I need to delete the same range on the original list to avoid duplicates, again 
        // possible through the RemoveRange() method with the same parameters as before. 
        // Finally, I need to insert the range that I got from the first expression on the 0 index on the same list 
        // through the InsertRange() method. Since the method updates the actual value of the list, I do not need to 
        // return a new value or list.

        //obtain the range that will be rotated later  
        List<int> rangeToInsert = data.GetRange(data.Count - amount, amount);
        // remove the values to avoid duplicity
        data.RemoveRange(data.Count - amount, amount);
        // Insert the range at the beginning of the list updating the actual list.
        data.InsertRange(0, rangeToInsert);
    }
}
