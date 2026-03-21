using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add values with different priorities and test the basic priority system
    // Expected Result: "Renzo"
    // Defect(s) Found: none at the moment
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Renzo", 4);
        priorityQueue.Enqueue("Alejandra", 1);
        priorityQueue.Enqueue("Arami", 3);
        priorityQueue.Enqueue("Armando", 2);

        var expectedResult = "Renzo";

        var result = priorityQueue.Dequeue();

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    // Scenario: Test items with the same priority in the queue
    // Expected Result: "Renzo"
    // Defect(s) Found: "program is not grabbing the first that entered into the list
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Renzo", 3);
        priorityQueue.Enqueue("Alejandra", 3);
        priorityQueue.Enqueue("Arami", 3);
        priorityQueue.Enqueue("Armando", 3);

        var expectedResult = "Renzo";

        var result = priorityQueue.Dequeue();

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    // Scenario: Test when queue is empty
    // Expected Result: invalidOperationException message and empty thing.
    // Defect(s) Found: none
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should jump in now");
        } catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        } catch (AssertFailedException)
        {
            throw;
        } catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                    e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Test that even last item has the priority to be dequeued
    // Expected Result: "Renzo"
    // Defect(s) Found: for loop stops before the last item and does not check the last item.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Wilson", 2);
        priorityQueue.Enqueue("Alejandra", 3);
        priorityQueue.Enqueue("Arami", 6);
        priorityQueue.Enqueue("Renzo", 10);

        var expectedResult = "Renzo";

        var result = priorityQueue.Dequeue();

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    // Scenario: Ensure dequeue removes the highest-priority item (even if it's last)
    // Expected Result: "Renzo" is removed and no longer in the queue
    // Defect(s) Found: method is not removing the item in the queue
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alejandra", 3);
        priorityQueue.Enqueue("Arami", 6);
        priorityQueue.Enqueue("Renzo", 10);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Renzo", result);

        // Assert it was removed from queue
        var queueState = priorityQueue.ToString();
        Assert.IsFalse(queueState.Contains("Renzo"));
    }
}