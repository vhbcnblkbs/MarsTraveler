using System;
using System.Linq;
using System.Threading;

namespace TravelerInMars
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        Mars mars = new Mars();
        Console.WriteLine("Yüzey boyutlarını giriniz:");
        string[] size = ReadConsole();
        mars.X = int.Parse(size[0]);
        mars.Y = int.Parse(size[1]);

        Robot robot1 = new Robot();
        Console.WriteLine("1. robotun koordinatlarını giriniz:");
        string[] koordinations_1 = ReadConsole();
        robot1.X = int.Parse(koordinations_1[0]);
        robot1.Y = int.Parse(koordinations_1[1]);
        robot1.Direction = char.Parse(koordinations_1[2]);

        Console.WriteLine("1. robot için hareket komutlarını giriniz:");
        string[] moveOrders_1 = ReadConsole();
        Location l1 = robot1.Move(mars, moveOrders_1);
        Console.WriteLine(String.Format("1. robotun koordinatları: {0} {1} {2}", l1.X, l1.Y, l1.Direction));

        Robot robot2 = new Robot();
        Console.WriteLine("2. robotun koordinatlarını giriniz:");
        string[] koordinations_2 = ReadConsole();
        robot1.X = int.Parse(koordinations_2[0]);
        robot1.Y = int.Parse(koordinations_2[1]);
        robot1.Direction = char.Parse(koordinations_2[2]);

        Console.WriteLine("2. robot için hareket komutlarını giriniz:");
        string[] moveOrders_2 = ReadConsole();
        Location l2 = robot1.Move(mars, moveOrders_2);
        Console.WriteLine(String.Format("2. robotun koordinatları: {0} {1} {2}", l2.X, l2.Y, l2.Direction));
      }
      catch (Exception e)
      {
        throw e;
      }
      finally
      {
        Console.WriteLine("Çıkmak için enter tuşuna basın ...");
        Console.ReadLine();
      }
    }

    public static string[] ReadConsole()
    {
      return Console.ReadLine().Trim().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
    }
  }

  class Koordinates
  {
    private int x;
    private int y;

    public int X
    {
      get { return x; }
      set { x = value; }
    }

    public int Y
    {
      get { return y; }
      set { y = value; }
    }
  }
  class Location : Koordinates
  {
    private char direction;

    public char Direction
    {
      get { return direction; }
      set { direction = value; }
    }
  }
  class Mars : Koordinates
  {
    public Mars() { }
  }
  
  class Robot : Location
  {
    public Robot() { }

    public Location Move(Mars mars, string[] moveOrders)
    {
      foreach(char c in moveOrders[0])
      {
        switch (c)
        {
          case 'M':
            switch (this.Direction)
            {
              case 'N':
                if (this.Y < mars.Y)
                  this.Y++;
                break;
              case 'E':
                if (this.X < mars.X)
                  this.X++;
                break;
              case 'S':
                if (this.Y > 0)
                  this.Y--;
                break;
              case 'W':
                if (this.X > 0)
                  this.X--;
                break;
            }
            break;
          case 'R':
          case 'L':
            this.Direction = MoveRightLeft(this.Direction, c);
            break;
        }
      }

      return new Location { X = this.X, Y = this.Y, Direction = this.Direction };
    }

    public char MoveRightLeft(char currentDirection, char direction)
    {
      switch (currentDirection)
      {
        case 'N':
          return direction == 'R' ? 'E' : 'W';
        case 'E':
          return direction == 'R' ? 'S' : 'N';
        case 'S':
          return direction == 'R' ? 'W' : 'E';
        case 'W':
          return direction == 'R' ? 'N' : 'S';
        default: return currentDirection;
      }
    }
  }
}
