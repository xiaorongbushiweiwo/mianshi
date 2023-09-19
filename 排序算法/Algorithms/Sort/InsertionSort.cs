namespace Sort;

public class InsertionSort
{
    public static int[] MinToMax(int[] nums )
    {
        int mid = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            
            for (int j = i; j > mid + 1; j--)
            {
                if (nums[j] < nums[j - 1])
                {
                    int temp = nums[j]; 
                    nums[j] = nums[j - 1];
                    nums[j - 1] = temp;
                }
            }

            if (nums[mid] > nums[mid + 1])
            {
                for (int j = mid + 1; j > 0; j--)
                {
                    if (nums[j] < nums[j - 1])
                    {
                        int temp = nums[j]; 
                        nums[j] = nums[j - 1];
                        nums[j - 1] = temp;
                        
                    }
                }

                mid += 1;
            }
        }
        return nums;
    }
    
    public static int[] MaxToMin(int[] nums )
    {
        int mid = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            
            for (int j = i; j > mid + 1; j--)
            {
                if (nums[j] > nums[j - 1])
                {
                    int temp = nums[j]; 
                    nums[j] = nums[j - 1];
                    nums[j - 1] = temp;
                }
            }

            if (nums[mid] < nums[mid + 1])
            {
                for (int j = mid + 1; j > 0; j--)
                {
                    if (nums[j] > nums[j - 1])
                    {
                        int temp = nums[j]; 
                        nums[j] = nums[j - 1];
                        nums[j - 1] = temp;
                        
                    }
                }

                mid += 1;
            }
        }
        return nums;
    }
}