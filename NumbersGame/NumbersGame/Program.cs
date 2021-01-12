using System;

namespace NumbersGame
{
    class NumbersGame
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (Exception exc)
            {
                //generic exception
                Console.WriteLine("Hm, something went wrong.");
                throw new Exception("Hm, something went wrong.", exc);

            }
            finally
            {
                Console.WriteLine("Program is complete.");
            }
            //finally: state program has completed
        }

        static void StartSequence()
        {
            try
            {
                //prompt user to enter a number
                Console.WriteLine("Welcome to my game! Lets do some math!");
                Console.WriteLine("Please enter a number greater than zero");
                //save number then parse to integer
                string input = Console.ReadLine();
                int length = Convert.ToInt32(input);
                //instantiate new int array of input size
                int[] numbers = new int[length];
                //call populate method with array in params
                int[] populated = Populate(numbers);
                //call getSum method
                int sum = GetSum(populated);
                //call getProduct
                int product = GetProduct(populated, sum);
                //call getQuotient
                decimal quotient = GetQuotient(product);
                //Output values
                Console.WriteLine($"Your array is size: {length}");
                Console.WriteLine("The numbers in the array are {0}", string.Join(",", populated));
                Console.WriteLine($"The sum of the array is {sum}");
                //reverse solving for the inputted values:
                int element = product / sum;
                decimal num = product / quotient;
                Console.WriteLine($"{sum} * {element} = {product}");
                Console.WriteLine($"{product} / {num} = {quotient}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
            }
            catch (OverflowException eo)
            {
                Console.WriteLine(eo);
            }
        }

        static int[] Populate(int[] arr)
        {
            //iterate through array
            for(int i = 0; i < arr.Length; i++)
            {
                //get number from user
                Console.WriteLine($"Please enter number: {i + 1} of {arr.Length}");
                string input = Console.ReadLine();
                //parse int
                int num = Convert.ToInt32(input);
                //add to array
                arr[i] = num;
            }
            //return array
            return arr;
        }

        static int GetSum(int[] arr)
        {
            //declare int sum
            int sum = 0;
            //iterate through array
            for(int i = 0; i < arr.Length; i++)
            {
                //update sum to add each value
                sum += arr[i];
            }
            //throw custom exception for values less than 20
            if(sum < 20)
            {
                Console.WriteLine($"Value of { sum} is too low.");
                throw new Exception($"Value of {sum} is too low.");
            }
            else
            {
            //return sum
            return sum;
            }
        }

        static int GetProduct(int[] arr, int sum)
        {
            try
            {
                //Prompt user to select a number between 1 and array length
                Console.WriteLine($"Please select a random number between 1 and {arr.Length}");
                //Save as integer
                string input = Console.ReadLine();
                int index = Convert.ToInt32(input);
                //decrement to account for zero based index
                index--;
                //multiply sum by the element at the index chosen by the user
                int product = sum * arr[index];
                //return product
                return product;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw new ArgumentOutOfRangeException("Index parameter is out of range", e);
            }
        }

        static decimal GetQuotient(int product)
        {
            //prompt user for a number to divide by
            Console.WriteLine($"Please select a number to divide your product {product} by");
            //retrieve and parse input
            string input = Console.ReadLine();
            int div = Convert.ToInt32(input);
            //divide product by input
            try
            {
                decimal quotient = decimal.Divide(product, div);
                //return quotient
                return quotient;
            }
            catch (DivideByZeroException eo)
            {
                Console.WriteLine($"Division of {product} by zero", eo);
                return 0;
            }
        }
    }
}
