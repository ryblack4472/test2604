using System;
class Program { static void Main()
 {
    Console.Write("Put the number of stalls: ");
    int n = int.Parse(Console.ReadLine());
    bool[] stalls = new bool[n];

    while (true) {
      Console.Write("Put the stall number **0 to exit** : ");
      int stallNum1 = int.Parse(Console.ReadLine());
      int stallNum2 = 0;

      if (stallNum1 == 0) {
        Console.WriteLine("Exiting...");
        break;
      }

      if (stallNum1 < 0 || stallNum1 >= n) {
        Console.WriteLine("Invalid input. Stall number must be between 1 and " + n + ".");
        continue;
      }

      if (stallNum2 == 0) {
        Console.WriteLine("Reserving Stall " + stallNum1 + "...");
        if (stalls[stallNum1 - 1]) {
          Console.WriteLine("The stall is reserved.");
        } else {
          stalls[stallNum1 - 1] = true;
          Console.WriteLine("The stall is reserved.");
        }
      } else if (stallNum2 < 0 || stallNum2 >= n) {
        Console.WriteLine("Invalid input. Stall number must be between 1 and " + n + ".");
        continue;
      } else {
        Console.WriteLine("Reserving Stalls " + stallNum1 + " and " + stallNum2 + "...");
        if (stalls[stallNum1 - 1] || stalls[stallNum2 - 1]) {
          Console.WriteLine("The stall is reserved.");
        } else {
          int start = Math.Min(stallNum1, stallNum2);
          int end = Math.Max(stallNum1, stallNum2);
          bool canReserve = true;
          for (int i = start - 1; i < end; i++) {
            if (stalls[i]) {
              Console.WriteLine("The entrance cannot be reserved.");
              canReserve = false;
              break;
            }
          }
          if (canReserve) {
            for (int i = start - 1; i < end; i++) {
              stalls[i] = true;
            }
            Console.WriteLine("The stalls are reserved.");
          }
        }
      }

      Console.Write("Stalls: ");
      for (int i = 0; i < n; i++) {
        if (stalls[i]) {
          Console.Write("X ");
        } else {
          Console.Write(i + 1 + " ");
        }
      }
      Console.WriteLine();
    }
  }
}
