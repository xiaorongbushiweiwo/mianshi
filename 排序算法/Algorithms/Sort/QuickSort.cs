namespace Sort;

public class QuickSort
{
    /// <summary>
    /// 递归方式
    /// </summary>
    public static int[] ByRecursion(int[] nums)
    {
        Recursion(nums, 0, 0, nums.Length - 1);
        return nums;
    }
    
    private static int[] Recursion(int[] nums, int baseIndex, int startIndex, int endIndex)
    {

        if (endIndex - startIndex <= 1)
        {
            return nums;
        }
        
        for (int i = baseIndex + 1; i <= endIndex; i++)
        {
            if (nums[i] < nums[baseIndex])
            {
                int temp = nums[i];
                for (int j = i; j > baseIndex; j--)
                {
                    nums[j] = nums[j - 1];
                }

                nums[baseIndex] = temp;
                baseIndex += 1;
            }
        }

        //右侧
        Recursion(nums, baseIndex + 1, baseIndex + 1, endIndex);
        //左侧
        Recursion(nums, startIndex, startIndex, baseIndex - 1);
        
        return nums;
    }
    
    /// <summary>
    /// 迭代方式
    /// </summary>
    public static int[] ByIteration(int[] nums)
    {
        int frontIndex = 0;
        int backIndex = 0;
        int baseIndex = 0;
        while (true)
        {
            
            for (int i = backIndex + 1; i <= nums.Length; i++)
            {
                if (nums[i] < nums[backIndex])
                {
                    int temp = nums[i];
                    for (int j = i; j > backIndex; j--)
                    {
                        nums[j] = nums[j - 1];
                    }

                    nums[backIndex] = temp;
                    backIndex += 1;
                }
            }

            for (int i = 0; i <= baseIndex; i++)
            {
                
            }
        }
        
        return nums;
    }
}