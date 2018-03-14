using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestingDigit
{
  class InterestingDigit
  {
    public static void Main(string[] args) {
      InterestingDigit id = new InterestingDigit();
      int b = Convert.ToInt32(Console.ReadLine());
      int[] interDig = new int[b];

      interDig = id.digits(b);

      for (int i = 0; i < interDig.Length; ++i) {
        Console.Write(interDig[i] + " ");
      }
    }

    public int[] digits(int b) {
      InterestingDigit id = new InterestingDigit();
      if (b > 30 || b < 3) {
        return null;
      }
      
      int[] vals = new int[b];
      int testValue = 2;
      int current;
      int index = 0;
      bool passed = true;

      for (int i = 2; i < b; ++i) {
        passed = true;
        testValue = 2;

        while (testValue < 1000) {
          current = i * testValue;

          if (current < b) {
            current = id.convertToBase(current, b);
            current = id.addTogether(current, b, false);
          }
          else {
            int temp = current;
            current = id.convertToBase(current, b);
            if (b > 10) current = id.addTogether(temp, b, true);
            else current = id.addTogether(current, b, true);
          }

          if (current % i != 0) {
            passed = false;
            break;
          }
          testValue++;
        }

        if (passed) {
          vals[index] = i;
          index++;
        }
      }

      int[] final = new int[index];
      for (int i = 0; i < index; ++i) {
        final[i] = vals[i];
      }

      return final;
    }

    public int convertToBase(int val, int newBase) {
      int temp = val;
      int col = 1;
      int cur = 0;
      int newVal = 0;
      int placeHolder = 1;
      
      while (val > 0) {
        cur = val % newBase;

        if (cur != 0) {
          if (cur > 10) placeHolder *= 10;
          cur *= col;
          newVal += cur;
        }
        col *= 10 * placeHolder;
        val /= newBase;
        cur = 0;
      }

      return newVal;
    }

    public int addTogether(int val, int b, bool converted) {
      if (!converted)
        return val;

      int cur = 0, newVal = 0;
      int baseVal;
      if (b > 10) 
        baseVal = b;
      else 
        baseVal = 10;

      

      while (val > 0) {
        cur = val % baseVal;
        newVal += cur;
        val /= baseVal;
      }

      return newVal;
    }
  }
}
