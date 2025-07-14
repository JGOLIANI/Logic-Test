namespace logic_test;

using System;
using System.Collections.Generic;

public class Network
{
    private int elements;
    private List<List<int>> connection;

    public Network(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentException("The number os elements should be positive.");
        }
        elements = n;
        connection = new List<List<int>>();
        for (int i = 0; i <= n; i++)
        {
            connection.Add(new List<int>());
        }
    }

    public void Connect(int a, int b)
    {
        if (a < 1 || a > elements || b < 1 || b > elements)
        {
            throw new ArgumentException("Elements out of the valid range.");
        }
        if (a == b || connection[a].Contains(b))
        {
            return;
        }
        connection[a].Add(b);
        connection[b].Add(a);
    }

    public bool Query(int a, int b)
    {
        if (a < 1 || a > elements || b < 1 || b > elements)
        {
            throw new ArgumentException("Elements out of the valid range.");
        }
        if (a == b)
        {
            return true; 
        }

        bool[] visited = new bool[elements + 1];
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(a);
        visited[a] = true;

        while (queue.Count > 0)
        {
            int currentElement = queue.Dequeue();
            if (currentElement == b)
            {
                return true;
            }
            foreach (int neighbor in connection[currentElement])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
        return false;
    }
}
