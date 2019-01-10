using System;
using System.IO;

public class Namesort
{
  public static void Main(string[] args)
  {
      string path = "";

      // if the program didnt receive arg, terminate the program.
      if(args.Length == 0)
      {
        Console.WriteLine("Please enter a file path.");
        return;
      }
      path = args[0];

      // if the file in the arg doesnt exist, terminate the program.
      if(!File.Exists(path))
      {
        Console.WriteLine("Invalid file path.");
        return;
      }

      // read names in the txt file into string array.
      string[] lines = System.IO.File.ReadAllLines(path);
    //  string[] sample = {"Janet Parsons", "Vaughn Lewis" ,"Adonis Julius Archer" ,"Shelby Nathan Yoder" ,"Marin Alvarez", "London Lindsey", "Beau Tristan Bentley", "Leo Gardner", "Hunter Uriah Mathew Clarke", "Mikayla Lopez", "Frankie Conner Ritter"};

      // get the array each element of which is reordered as `firstName-lastName`
      string[] array = GetLastFirstArray(lines);

      // sort the array using Array.Sort() method
      Array.Sort(array);

      // get the array each element of which is reordered as `lastName-firstName`
      string[] arraynew = GetFirstLastArray(array);

      // Write the output into new txt file and console.
      Console.WriteLine(string.Join("\n",arraynew));
      System.IO.File.WriteAllLines("sorted-names-list.txt", lines);
  }

  public static string[] GetLastFirstArray(string[] sample) {
    // get length of array
    int length = sample.Length;

    // for each name in the array, reorder the name as `lastName-firstName` format.
    for (int i = 0; i < length; i++)
    {
      string[] split = sample[i].Split(' ');
      int len = split.Length;
      string lastName = split[len-1];
      string[] firstNameArray = Slice(split, 0,len-1);
      string firstName = string.Join(" ", firstNameArray);
      string fullName = lastName + " " + firstName;
      sample[i] = fullName;
    }
    return sample;
  }


  public static string[] GetFirstLastArray(string[] sample) {
    // get length of array
    int length = sample.Length;

    // for each name in the array, reorder the name as `lastName-firstName` format.
    for (int i = 0; i < length; i++)
    {
      string[] split = sample[i].Split(' ');
      int len = split.Length;
      string lastName = split[0];
      string[] firstNameArray = Slice(split, 1,len);
      string firstName = string.Join(" ", firstNameArray);
      string fullName = firstName + " " + lastName;
      sample[i] = fullName;
    }
    return sample;
  }

  // Get the subarray of an array with given original array, start index and end index
  public static string[] Slice(string[] source, int start, int end)
  {
      // convert the negative index into positive index
      if (end < 0)
      {
          end = source.Length + end;
      }

      // calculate the length of the subarray
      int len = end - start;

      // construct the subarray
      string[] res = new string[len];
      for (int i = 0; i < len; i++)
      {
          res[i] = source[i + start];
      }
      return res;
  }
}
