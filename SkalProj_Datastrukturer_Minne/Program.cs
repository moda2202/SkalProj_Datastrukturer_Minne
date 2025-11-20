using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. Recursive"
                    + "\n6. Iterative"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        Recursion();
                        break;
                    case '6':
                        Iteration();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        private static void Iteration()
        {
            Console.Clear();
            Console.WriteLine("Iteration");
            Console.WriteLine("--------------");
            Console.Write("Please enter positive integer: ");

            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            Console.WriteLine($"IterativeOdd({n}) = {IterativeOdd(n)}");
            Console.WriteLine($"IterativeEven({n}) = {IterativeEven(n)}");
            Console.WriteLine($"IterativeFibonacci({n}) = {IterativeFibonacci(n)}");
        }

        private static int IterativeFibonacci(int n)
        {
            if (n <= 0) return 0;
            if (n == 1 || n == 2) return 1;

            int prev = 1;
            int curr = 1;

            for (int i = 3; i <= n; i++)
            {
                int next = prev + curr;
                prev = curr;
                curr = next;
            }

            return curr;
        }

        private static int IterativeEven(int n)
        {
            int result = 2;
            for (int i = 1; i < n; i++)
            {
                result += 2;
            }
            return result;
        }

        private static int IterativeOdd(int n)
        {
            int result = 1;
            for (int i = 1; i < n; i++)
            {
                result += 2;
            }
            return result;
        }

        private static void Recursion()
        {
            Console.WriteLine("Recursion");
            Console.WriteLine("--------------");
            Console.Write("Please enter positive integer: ");

            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            Console.WriteLine($"RecursiveOdd({n}) = {RecursiveOdd(n)}");
            Console.WriteLine($"RecursiveEven({n}) = {RecursiveEven(n)}");
            Console.WriteLine($"RecursiveFibonacci({n}) = {RecursiveFibonacci(n)}");
        }

       

        private static int RecursiveFibonacci(int n)
        {
            if (n <= 0)
                return 0;
            if (n == 1 || n == 2)
                return 1;

            return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
        }

        private static int RecursiveEven(int n)
        {
            if (n == 1)
                return 2;

            return RecursiveEven(n - 1) + 2;
        }

        private static int RecursiveOdd(int n)
        {
            if (n == 1)
                return 1;
            
            return RecursiveOdd(n - 1) + 2;
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            List<string> wordsList = new List<string>();

            do
            {
                Console.Clear();
                Console.WriteLine("ExamineList()");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Enter +Name to add, -Name to remove");
                Console.WriteLine("Enter 0 to return to main menu.");
                Console.WriteLine();

                Console.Write("\nInput: ");
                string input = (Console.ReadLine() ?? string.Empty).Trim();

                if (input == "0")
                    return;

                if (input.Length == 0)
                    continue;

                char nav = input[0];
                string value = input.Length > 1 ? input.Substring(1).Trim() : string.Empty;


                switch (nav)
                {
                    case '+':
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            wordsList.Add(value);
                            Console.WriteLine($"{value} added.");
                        }
                        else
                        {
                            Console.WriteLine("Please write a name after '+'.");
                        }
                        break;

                    case '-':
                        if (string.IsNullOrEmpty(value))
                        {
                            Console.WriteLine("Please write a name after '-'.");
                        }
                        else if (wordsList.Remove(value))
                        {
                            Console.WriteLine($"{value} removed.");
                        }
                        else
                        {
                            Console.WriteLine($"{value} not found in the list.");
                        }
                        break;

                    default:
                        Console.WriteLine("Use +Name to add or -Name to remove.");
                        break;
                }

                // Visa Count och Capacity efter varje operation
                Console.WriteLine($"Count: {wordsList.Count}, Capacity: {wordsList.Capacity}");
                Console.WriteLine("Press any key to continue..");
                Console.WriteLine(string.Join(", ", wordsList));
                Console.ReadKey();

            } while (true);
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            Queue<string> queue = new Queue<string>();

            do
            {

                Console.Clear();
                Console.WriteLine("ExamineQueue()");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Enter +Name to enqueue, - to dequeue");
                Console.WriteLine("Enter 0 to return to main menu.");
                Console.WriteLine();

                if (queue.Count == 0)
                {
                    Console.WriteLine("Queue is empty");
                }
                else
                {
                    Console.WriteLine("Current queue (front -> back):");
                    Console.WriteLine(string.Join(" <- ", queue));
                }

                Console.Write("\nInput: ");
                string input = (Console.ReadLine() ?? string.Empty).Trim();

                if (input == "0")
                    return;


                if (input.Length == 0)
                    continue;

                char nav = input[0];
                string value = input.Length > 1 ? input.Substring(1) : string.Empty;


                if (nav != '+' && nav != '-')
                {
                    Console.WriteLine("First character must be '+' to enqueue or '-' to dequeue or 0 to exit.");
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                    continue;
                }

                switch (nav)
                {
                    case '+':
                        if (string.IsNullOrWhiteSpace(value))
                        {
                            Console.WriteLine("Please write a name after '+'.");
                        }
                        else
                        {
                            string name = value.Trim();
                            queue.Enqueue(name);
                            Console.WriteLine($"{name} joined the queue.");
                        }
                        break;

                    case '-':
                        if (queue.Count > 0)
                        {
                            string removed = queue.Dequeue();
                            Console.WriteLine($"{removed} left the queue.");
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty nothing to dequeue.");
                        }
                        break;
                }

                Console.WriteLine();
                Console.WriteLine($"Queue count: {queue.Count}");


                if (queue.Count == 0)
                {
                    Console.WriteLine("Queue is empty");
                }
                else
                {
                    Console.WriteLine(string.Join(" <- ", queue));
                }



                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();

            } while (true);
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            Stack<string> stack = new Stack<string>();

            do
            {
                Console.Clear();
                Console.WriteLine("ExamineStack()");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Enter +Text to push, - to pop");
                Console.WriteLine("Enter 0 to return to main menu.");
                Console.WriteLine();

                if (stack.Count == 0)
                {
                    Console.WriteLine("Stack is empty");
                }
                else
                {
                    Console.WriteLine("Current stack (top -> bottom):");
                    Console.WriteLine(string.Join(" | ", stack));
                }

                Console.Write("\nInput: ");
                string input = (Console.ReadLine() ?? string.Empty).Trim();

                if (input == "0")
                    return;


                if (input.Length == 0)
                    continue;

                char nav = input[0];
                string value = input.Length > 1 ? input.Substring(1) : string.Empty;

                if (nav != '+' && nav != '-')
                {
                    Console.WriteLine("First character must be '+' to push or '-' to pop (or 0 to exit).");
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                    continue;
                }

                switch (nav)
                {
                    case '+':
                        if (string.IsNullOrWhiteSpace(value))
                        {
                            Console.WriteLine("Please write some text after '+'.");
                        }
                        else
                        {
                            string text = value.Trim();
                            stack.Push(text);
                            Console.WriteLine($"{text} pushed on stack.");
                        }
                        break;

                    case '-':
                        if (stack.Count > 0)
                        {
                            string removed = stack.Pop();
                            Console.WriteLine($"{removed} popped from stack.");
                        }
                        else
                        {
                            Console.WriteLine("Stack is empty nothing to pop.");
                        }
                        break;
                }

                Console.WriteLine();
                Console.WriteLine($"Stack count: {stack.Count}");

                if (stack.Count == 0)
                {
                    Console.WriteLine("Stack is empty");
                }
                else
                {
                    Console.WriteLine("Current stack (top -> bottom):");
                    Console.WriteLine(string.Join(" | ", stack));
                }

                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();

            } while (true);
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            Console.Clear();
            Console.WriteLine("CheckParenthesis()");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Enter a string to check if parenthesis are well-formed:");
            string? input = Console.ReadLine() ?? string.Empty;

            bool ok = IsWellFormedParenthesis(input);

            if (ok)
                Console.WriteLine("The string is well formed.");
            else
                Console.WriteLine("The string is not well formed.");
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

        static bool IsWellFormedParenthesis(string text)
        {
            var stack = new Stack<char>();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0)
                        return false;
                    char open = stack.Pop();

                    if (!IsMatchingPair(open, c))
                        return false;
                }
            }
            return stack.Count == 0;
        }

        static bool IsMatchingPair(char open, char close)
        {
            if (open == '(' && close == ')') return true;
            if (open == '{' && close == '}') return true;
            if (open == '[' && close == ']') return true;
            return false;
        }
    }
}
