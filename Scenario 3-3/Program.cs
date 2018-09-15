using System;
using System.Collections.Generic;

namespace Scenario_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Stack<int> s1 = generateSortedStack(r, 3);
            printStack(s1);
            Stack<int> s2 = generateSortedStack(r, 5);
            printStack(s2);

            Stack<int> s3 = new Stack<int>();

            // Examine each stack to determine the number to push into s3
            // This number is the larger of s1 and s2's first element
            while(s1.Count > 0 && s2.Count > 0)
            {
                int n1 = s1.Peek();
                int n2 = s2.Peek();
                if(n1 > n2)
                {
                    s3.Push(n1);
                    s1.Pop();
                } else
                {
                    s3.Push(n2);
                    s2.Pop();
                }
            }

            // Either s1 or s2 will still have some remaining elements
            // Push these remaining stack elements to s3
            while(s1.Count > 0)
            {
                s3.Push(s1.Pop());
            }

            while (s2.Count > 0)
            {
                s3.Push(s2.Pop());
            }

            // s3 will be sorted in asc order.
            // Print it out by popping one element at a time
            while(s3.Count > 0)
            {
                Console.Write("{0} ", s3.Pop());
            }
            Console.WriteLine(); //newline
        }

        // helper function to display stack (non-destructively)
        static void printStack(Stack<int> s)
        {
            foreach(int i in s)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine(); //newline
        }
        
        static Stack<int> generateSortedStack(Random r, int n)
        {
            Stack<int> s = new Stack<int>();
            int start, end;
            for(int i = 0; i < n; i++)
            {
                start = 100 * i;
                end = start + 100;
                s.Push(r.Next(start, end));
            }

            return s;
        }
    }
}
