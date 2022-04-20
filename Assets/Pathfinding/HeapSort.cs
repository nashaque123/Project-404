using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeapSort<T> where T : HeapItem<T>
{

    T[] items;
    int currentCount;

    public HeapSort(int maxHeapSize)
    {
        items = new T[maxHeapSize];
    }

    public void Add(T item)
    {
        item.HeapIndex = currentCount;
        items[currentCount] = item;
        SortUp(item);
        currentCount++;
    }

    public T RemoveFirst()
    {
        T firstItem = items[0];
        currentCount--;
        items[0] = items[currentCount];
        items[0].HeapIndex = 0;
        SortDown(items[0]);
        return firstItem;
    }

    public void UpdateItem(T item)
    {
        SortUp(item);
    }

    public int Count
    {
        get
        {
            return currentCount;
        }
    }
    public bool Contains(T item)
    {
        return Equals(items[item.HeapIndex], item);
    }
    void SortUp(T item)
    {
        int parentIndex = (item.HeapIndex - 1) / 2;

        while (true)
        {
            T parentItem = items[parentIndex];
            if(item.CompareTo(parentItem) > 0)
            {
                Swap(item, parentItem);
            }
            else
            {
                break;
            }
            parentIndex = (item.HeapIndex - 1) / 2;
        }
    }

    void SortDown(T item)
    {
        while (true)
        {
            int childIndexLeft = item.HeapIndex * 2 + 1;
            int childIndexRight = item.HeapIndex * 2 + 2;
            int swapIndex = 0;
            if(childIndexLeft < currentCount)
            {
                swapIndex = childIndexLeft;
                if(childIndexRight < currentCount)
                {
                    if(items[childIndexLeft].CompareTo(items[childIndexRight]) < 0)
                    {
                        swapIndex = childIndexRight;
                    }
                }

                if(item.CompareTo(items[swapIndex]) < 0)
                {
                    Swap(item, items[swapIndex]);
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }

    void Swap(T item1, T item2)
    {
        items[item1.HeapIndex] = item2;
        items[item2.HeapIndex] = item1;
        int item1Index = item1.HeapIndex;
        item1.HeapIndex = item2.HeapIndex;
        item2.HeapIndex = item1Index;
    }
}

public interface HeapItem<T> : IComparable<T>
{
    int HeapIndex 
    {
        get; set; 
    }
}
