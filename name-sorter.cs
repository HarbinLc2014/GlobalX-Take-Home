using System;
using System.IO;

public class Hello
{
  public static void Main(string[] args)
  {
      string path = "";
      if(args.Length==0){
        Console.WriteLine("Please enter a file path.");
        return;
      }
      path=args[0];
      if(!File.Exists(path)){
        Console.WriteLine("Invalid file path.");
        return;
      }
      string[] lines = System.IO.File.ReadAllLines(path);
    //  string[] sample = {"Janet Parsons", "Vaughn Lewis" ,"Adonis Julius Archer" ,"Shelby Nathan Yoder" ,"Marin Alvarez", "London Lindsey", "Beau Tristan Bentley", "Leo Gardner", "Hunter Uriah Mathew Clarke", "Mikayla Lopez", "Frankie Conner Ritter"};
      string[] array = GetLastFirstArray(lines);
      Array.Sort(array);
      string[] arraynew = GetFirstLastArray(array);
      Console.WriteLine(string.Join("\n",arraynew));
      System.IO.File.WriteAllLines("sorted-names-list.txt", lines);
  }

  public static string[] GetLastFirstArray(string[] sample) {
    int length = sample.Length;
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
    int length = sample.Length;
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
  public static string[] Slice(string[] source, int start, int end)
  {
      if (end < 0)
      {
          end = source.Length + end;
      }
      int len = end - start;

      string[] res = new string[len];
      for (int i = 0; i < len; i++)
      {
          res[i] = source[i + start];
      }
      return res;
  }
}
