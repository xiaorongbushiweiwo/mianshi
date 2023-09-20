// See https://aka.ms/new-console-template for more information

using Sort;

int[] a = { 5, 4, 3, 2, 1, 7, 9, 6, 1};

#region BubbleSort

//BubbleSort.MinToMax(a);
//BubbleSort.MaxToMin(a);

#endregion

#region SelectionSort

//SelectionSort.SelectMin(a);
//SelectionSort.SelectMax(a);

#endregion

#region InsertionSort

//InsertionSort.MinToMax(a);
//InsertionSort.MaxToMin(a);

#endregion

#region ShellSort

//ShellSort.MinToMax(a);
//ShellSort.MaxToMin(a);

#endregion

#region MergeSort

//MergeSort.ByRecursion(a);
//MergeSort.ByIteration(a);

#endregion

#region QuickSort

QuickSort.ByRecursion(a);

#endregion

for (int i = 0; i < a.Length; i++)
{
    Console.Write(a[i] + " ");

}

