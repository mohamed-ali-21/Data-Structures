namespace Data_Structures.DataStructures.Tree.Algorithms
{
    public static class Sort
    {
        public static void SelectionSort(int[] myarray)
        {
            int min_index;
            for (int i = 0; i < myarray.Length - 1; i++)
            {
                min_index = i;
                for (int j = i + 1; j < myarray.Length; j++)
                {
                    if (myarray[j] < myarray[min_index])
                    {
                        min_index = j;
                    }
                }
                swap(ref myarray[i], ref myarray[min_index]);
            }
        }
        private static void swap(ref int m, ref int n)
        {
            int t = m;
            m = n;
            n = t;
        }

        public static void d(Int32 x)
        {
            x = 1;
        }
    }
}