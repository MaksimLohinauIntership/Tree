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
        TraverseItem(current);
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
        CopyToRecursive(top, array, ref arrayIndex);
    }

    private void CopyToRecursive(Node node, int[] array, ref int index)
    {
        if (node == null)
            return;

        CopyToRecursive(node.left, array, ref index);
        array[index++] = node.Value;
        CopyToRecursive(node.right, array, ref index);
    }

    public bool Remove(int value)
    {
        if (Contains(value))
        {
            top = RemoveRecursive(top, value);
            return true;
        }
        return false;
    }

    private Node RemoveRecursive(Node node, int value)
    {
        if (node == null)
            return null;

        if (value < node.Value)
        {
            node.left = RemoveRecursive(node.left, value);
        }
        else if (value > node.Value)
        {
            node.right = RemoveRecursive(node.right, value);
        }
        else
        {
            // Узел с одним или нулем дочерних узлов
            if (node.left == null)
                return node.right;
            else if (node.right == null)
                return node.left;

            // Узел с двумя дочерними узлами: ищем минимальный элемент в правом поддереве
            node.Value = FindMinValue(node.right);
            node.right = RemoveRecursive(node.right, node.Value);
        }
        return node;
    }

    private int FindMinValue(Node node)
    {
        int minValue = node.Value;
        while (node.left != null)
        {
            minValue = node.left.Value;
            node = node.left;
        }
        return minValue;
    }

    private IEnumerable<int> InOrderTraversal(Node node)
    {
        if (node != null)
        {
            foreach (var left in InOrderTraversal(node.left))
            {
                yield return left;
            }
            yield return node.Value;
            foreach (var right in InOrderTraversal(node.right))
            {
                yield return right;
            }
        }
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

    public IEnumerator<int> GetEnumerator()
    {
        return InOrderTraversal(top).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}






