namespace Sort;

public class MergeSort
{
    /// <summary>
    /// 递归方式
    /// </summary>
    public static int[] ByRecursion(int[] nums)
    {
        int startI = 0;
        int endI = nums.Length % 2 == 1 ? nums.Length - 2 : nums.Length - 1;
        
        Recursion(nums, startI, endI);
        
        if (nums.Length % 2 == 1)
        {
            for (int i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i] < nums[i - 1])
                {
                    int temp = nums[i];
                    nums[i] = nums[i - 1];
                    nums[i - 1] = temp;
                }
            }
        }

        return nums;
    }

    public static int[] Recursion(int[] nums, int startIndex, int endIndex)
    {
        int step = (endIndex - startIndex + 1) / 2;
        if (step >= 2)
        {
            for (int i = 0; i < nums.Length - step - 1; i += step)
            {
                Recursion(nums, i, i + step - 1);
            }
        }
        
        for (int i = 1; i <= step; i++)
        {
            for (int j = startIndex + i; j > startIndex; j--)
            {
                if (nums[j] < nums[j - 1])
                {
                    int temp = nums[j];
                    nums[j] = nums[j - 1];
                    nums[j - 1] = temp;
                }
            }
        }

        return nums;
    }

    /// <summary>
    /// 迭代方式
    /// </summary>
    public static int[] ByIteration(int[] nums)
    {
        int lengtha = nums.Length % 2 == 0 ? nums.Length : nums.Length - 1;
        for (int i = 2; i <= lengtha; i*=2)
        {
            int times = (int)MathF.Floor(lengtha / 1.0f / i);
            for (int j = 0; j < times; j++)
            {
                for (int k = i / 2; k < i; k++)
                {
                    for (int l = i * j + k; l > i * j; l--)
                    {
                        if (nums[l] < nums[l - 1])
                        {
                            int temp = nums[l];
                            nums[l] = nums[l - 1];
                            nums[l - 1] = temp;
                        }
                    }
                }
            }
        }

        if (nums.Length % 2 == 1)
        {
            for (int i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i] < nums[i - 1])
                {
                    int temp = nums[i];
                    nums[i] = nums[i - 1];
                    nums[i - 1] = temp;
                }
            }
        }
        
        return nums;
    }

    
}