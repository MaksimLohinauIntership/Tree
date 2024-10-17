// See https://aka.ms/new-console-template for more information
using System.Collections;

Console.WriteLine("Hello, World!");

public class Node()
{
    public int Value { get; set; }
    public Node left;
    public Node right;
    public int Count { get; set; }
}

public class Tree : ICollection<int>
{
    Node top;
    public Tree()
    {
        top = null;
    }

    public Tree(int value)
    {
        top = new Node { Value = value };
    }
    

    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public void Add(int value)
    {
        AddItem(top, value);
    }

    private void AddItem(Node current, int value)
    {
        if(current == null)
            current = new Node { Value = value };
        else
        {
            if(current.Value > value)
                AddItem(current.left, value);
            else
            {
                AddItem((Node)current.right, value);
            }
        }
    }

    public void Traverse(Node current)
    {

    }

    private void TraverseItem(Node current)
    {
        if (current != null)
        {
            Console.WriteLine(current.Value);
            TraverseItem(current.left);
            TraverseItem(current.right);
        }
        else
            return;
    }

    public void Clear()
    {
        top = null;
    }

    public bool Contains(int item)
    {
        return ContainsItem(item, top);
    }

    private bool ContainsItem(int item, Node current)
    {
        if (current.Value == item)
            return true;
        else
        {
            if (top.left.Value > item)
                return ContainsItem(item, current.left);
            else 
                return ContainsItem(item, current.right);
        }
    }

    public void CopyTo(int[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<int> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public bool Remove(int item)
    {
        return RemoveItem(item, top);
    }
    private bool RemoveItem(int item, Node current)
    {
        if (current == null)
            return false;
        else
        {
            if (current.Value > item)
                return RemoveItem(item, current.left);
            if (current.Value < item)
                return RemoveItem(item, current.right);
            if (current.Value == item)
            {
                if (current.left == null && current.right == null)
                {
                    current = null;
                    return RemoveItem(item, current);
                }

                if (current.left == null && current.right != null)
                {
                    current = current.right;
                    current.right = null;
                    return RemoveItem(item, current);
                }

                if (current.left != null && current.right == null)
                {
                    current = current.left;
                    current.left = null;
                    return RemoveItem(item, current);
                }

                if (current.left != null && current.right != null)
                {
                    current = current.right;
                    current.right = null;
                    return RemoveItem(item, current);
                }
            }
            return false;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public int CountItem()
    {
        int result = 0;
        CountItem(top, ref result);
        return result;
    }

    private int CountItem(Node current, ref int result)
    {
        if (current != null)
        {
            result++;
            CountItem(current.left, ref result);
            CountItem(current.right, ref result);
        }

        return result;
    }
}






