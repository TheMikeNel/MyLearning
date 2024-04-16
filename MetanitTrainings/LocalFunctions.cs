namespace MetanitTrainings
{
    internal class LocalFunctions
    {
        /// <summary>
        /// Compares Two Arrays
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns>1 if arr1 > arr2 / -1 if arr1 < arr2 / 0 if equals</returns>
        public static int CompareArrays(int[] arr1, int[] arr2)
        {
            static int Sum(int[] arr) // static - не может обращаться к переменным окружения (внешнего метода)
            {
                int result = 0;
                foreach (int i in arr)
                    result += i;
                return result;
            }

            if (Sum(arr1) > Sum(arr2)) return 1;
            else if (Sum(arr1) < Sum(arr2)) return -1;
            else return 0;
        }
    }
}
