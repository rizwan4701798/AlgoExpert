using System;
using System.Collections.Concurrent;


namespace quick_code_test
{

    //Please fill in the implementation of the service defined below. This service is to keep track
    //of ids to return if they have been seen before. No 3rd party packages can be used and the method
    //must be thread safe to call.

    //create the implementation as efficiently as possible in both locking, memory usage, and cpu usage

    public interface IDuplicateCheckService
    {

        //checks the given id and returns if it is the first time we have seen it
        //IT IS CRITICAL that duplicates are not allowed through this system but false
        //positives can be tolerated at a maximum error rate of less than 1%
        bool IsThisTheFirstTimeWeHaveSeen(int id);

    }

    public class HighlyOptimizedThreadSafeDuplicateCheckService : IDuplicateCheckService
    {

        ConcurrentDictionary<int, int> IsAlreadySeen = new ConcurrentDictionary<int, int>();
        Random randomNumber = new Random();

        public void IsThisTheFirstTimeWeHaveSeenTest()
        {
            bool result =  IsThisTheFirstTimeWeHaveSeen(randomNumber.Next(1, 1000));
            if (result)
            {
                Console.WriteLine("We have not seen this before");
            }
            else
            {
                Console.WriteLine("We have seen this before");
            }
        }

        public bool IsThisTheFirstTimeWeHaveSeen(int id)
        {
            try
            {
                if (id < 0)
                {
                    throw new ArgumentOutOfRangeException("id");
                }

                return IsAlreadySeen.TryAdd(id.GetHashCode(), id); // returns true if key not already seen, false if the key already exists.

            }
            catch 
            {
                return false;
            }
        }
    }
}
