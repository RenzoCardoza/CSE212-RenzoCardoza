using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // TODO Problem 1
        // create a new node 
        Node newNode = new(value);
        // if list empty point head and tail to this node
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // not empty list
        else
        {
            newNode.Prev = _tail; //connect prev node to be the tail
            _tail.Next = newNode; // make new node be next to previous tail
            _tail = newNode; // set tail to newnode
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }

    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // TODO Problem 2
        // if the list has only one item, set both tail and head to null
        // this will equal to am empty list
        if (_tail == _head)
        {
            _head = null;
            _tail = null;
        }
        // if the list has more than one item, only tail gets affected
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null; // disconnect previous node from old tail
            _tail = _tail.Prev; // update the tail to point to previous node.
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3
        // begin searching the list at the head.
        Node? currentNode = _head;
        // while node is not null keep seeing looking at nodes.
        while (currentNode is not null)
        {
            if (currentNode.Data == value)
            {
              //if data is head or tail call methods above
              if (currentNode == _head)
                {
                    // call removeHead to remove head
                    RemoveHead();

                } else if (currentNode == _tail)
                {
                    // call the removetail to remove tail
                    RemoveTail();

                } else  // node is not head or tail
                {
                    currentNode.Next?.Prev = currentNode.Prev; // set next node's previous node the current's node previous.
                    currentNode.Prev?.Next = currentNode.Next; // set previous node's next node to the current's node next.
                }
                // exit the function if this was successful.
                return;
            }
            // go to next node to search for the value
            currentNode = currentNode.Next;
        } 
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4
        // begin looking at the head to search for value 
        Node? currentNode = _head;
        // loop through the linked list
        while (currentNode is not null)
        {
            // if the current node's value is the target update the value
            if (currentNode.Data == oldValue)
            {
                // update old for new value
                currentNode.Data = newValue;
            } else 
            {
                //move to the next node
                currentNode = currentNode.Next;
            }
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        var currentNode = _tail; // start at the tail and go backwards
        while (currentNode is not null)
        {
            yield return currentNode.Data; // Provide (yield) each time to the user
            currentNode = currentNode.Prev; // go backwards on the linked list.
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}