namespace Sort;

public class SelectionSort
{
    public static int[] SelectMin(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int min = i;
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[j] < nums[min])
                {
                    min = j;
                }
            }

            int temp = nums[i];
            nums[i] = nums[min];
            nums[min] = temp;

        }

        return nums;
    }
    
    public static int[] SelectMax(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int max = nums.Length - 1 - i;
            for (int j = max - 1; j >= 0 ; j--)
            {
                if (nums[j] > nums[max])
                {
                    max = j;
                }
            }

            int temp = nums[nums.Length - 1 - i];
            nums[nums.Length - 1 - i] = nums[max];
            nums[max] = temp;

        }

        return nums;
    }
}