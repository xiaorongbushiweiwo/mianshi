namespace Sort;

public class ShellSort
{
    public static int[] MinToMax(int[] nums)
    {
        int step = (int)MathF.Floor(nums.Length / 2.0f) ;

        while (step >= 1)
        {
            for (int i = 0; i < step ; i++)
            {
                for (int j = i + step; j < nums.Length; j += step)
                {
                    for (int k = j; k < nums.Length; k += step)
                    {
                        if (nums[k] < nums[k - step])
                        {
                            int temp = nums[k];
                            nums[k] = nums[k - step];
                            nums[k - step] = temp;
                        }
                    }
                }
            }
            step = (int)MathF.Floor(step / 2.0f) ;
        }
        
        return nums;
    }
    public static int[] MaxToMin(int[] nums)
    {
        int step = (int)MathF.Floor(nums.Length / 2.0f) ;

        while (step >= 1)
        {
            for (int i = 0; i < step ; i++)
            {
                for (int j = i + step; j < nums.Length; j += step)
                {
                    for (int k = j; k < nums.Length; k += step)
                    {
                        if (nums[k] > nums[k - step])
                        {
                            int temp = nums[k];
                            nums[k] = nums[k - step];
                            nums[k - step] = temp;
                        }
                    }
                }
            }
            step = (int)MathF.Floor(step / 2.0f) ;
        }
        
        return nums;
    }
}