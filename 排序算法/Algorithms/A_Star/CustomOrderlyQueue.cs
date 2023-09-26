using System.Collections;

namespace A_Star;

public class CustomOrderlyQueue<T>
{
    private List<T> list = new List<T>();
    public int Count { get; set; }
    public void Enqueue(T item, Func<T, T, bool> comparer, bool reverse)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (reverse && comparer(item, list[i]) || !reverse && !comparer(item, list[i]))
            {
                list.Insert(i, item);
                Count = list.Count;
                return;
            }
        }

        list.Add(item);
        Count = list.Count;
    }

    public T Dequeue()
    {
        T item = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        Count = list.Count;
        return item;
    }

    public bool Camparer(T item, Func<T, T, bool> comparer, out T result)
    {
        result = default(T);
        foreach (var v in list)
        {
            if (comparer(item, v))
            {
                result = v;
                return true;
            }
        }

        return false;
    }

    public void Clear()
    {
        list.Clear();
        Count = 0;
    }

}