using System.Linq;

namespace ProcTask
{
    public static class ProcessorsHelper
    {
        public static void InitProcessors(int[] array, ProcessorsList processorsList)
        {
            for(int i = 0; i < array.Length; i++)
            {
                processorsList.AddProcessor(new Processor(array[i]));
            }
        }

        public static int AddTasks(int[] inputArray, ProcessorsList processorsList, ref int[] outputArray)
        {
            int minCount = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                int[] countArray = new int[processorsList.GetProcessors().Count];
                int proc = 0;
                foreach (var currentProcessor in processorsList.GetProcessors())
                {
                    countArray[proc] = currentProcessor.GetCountTaktForTask(inputArray[i]);
                    proc++;
                }
                int min = 999999999;
                int neededProc = 0;

                for (int k = 0; k < countArray.Length; k++)
                {
                    if (countArray[k] < min)
                    {
                        min = countArray[k];
                        neededProc = k;
                    }
                }

                processorsList.GetProcessors()[neededProc].Tacts = inputArray[i];
                outputArray[i] = neededProc;
                int a = 5;
            }
            return minCount;
        }

    }
}