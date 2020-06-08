using System;
using System.Collections.Generic;
using System.Text;

namespace Sem_2
{
  public class Node
  {
    public int data;
    public Node next;

    public Node(int d)
    {
      this.data = d;
      this.next = null;
    }
  }
  public class SinglyLinkedList
  {
    public int iterations;
    public Node head;
    public SinglyLinkedList()
    {
      this.iterations = 0;
      this.head = null;
    }

    public void AddNode(int data)
    {
      if (head == null)
      {
        head = new Node(data);
        return;
      }

      Node curr = head;
      while (curr.next != null)
        curr = curr.next;

      Node newNode = new Node(data);
      curr.next = newNode;
    }

    public void PrintList(Node n)
    {
      while (n != null)
      {
        Console.Write(n.data);
        Console.Write(" ");
        n = n.next;
      }
    }

    public Node ParitionLast(Node start, Node end)
    {
      if (start == end ||
      start == null || end == null)
        return start;

      Node pivot_prev = start;
      Node curr = start;
      int pivot = end.data;

      int temp;
      while (start != end)
      {

        if (start.data < pivot)
        {
          pivot_prev = curr;
          temp = curr.data;
          curr.data = start.data;
          start.data = temp;
          curr = curr.next;
        }
        start = start.next;
      }

      temp = curr.data;
      curr.data = pivot;
      end.data = temp;

      return pivot_prev;
    }
    public void Sort(Node start, Node end)
    {
      iterations++;
      if (start == end)
        return;

      Node pivot_prev = ParitionLast(start, end);
      Sort(start, pivot_prev);

      if (pivot_prev != null &&
          pivot_prev == start)
        Sort(pivot_prev.next, end);

      else if (pivot_prev != null &&
              pivot_prev.next != null)
        Sort(pivot_prev.next.next, end);
    }
  }
}
