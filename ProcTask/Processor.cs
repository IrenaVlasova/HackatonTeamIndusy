namespace ProcTask
{
    public class Processor
    {
        public Processor(int type)
        {
            Type = type;
        }
        public int Tacts { get; set; }

        public int Type { get; set; }

        public int GetCountTaktForTask(int task)
        {
            int count = 0;
            switch (Type)
            {
                case 0:
                    count = task + Tacts;
                    break;
                case 1:
                    if (task % 13 == 0) count = (task / 13) + Tacts;
                    else count = (3 * task + 1) + Tacts;
                    break;
                case 2:
                    if (task % 2 == 0) count = (task / 2) + Tacts;
                    else count = (3 * task + 1) + Tacts;
                    break;
            }
            return count;
        }
    }
}