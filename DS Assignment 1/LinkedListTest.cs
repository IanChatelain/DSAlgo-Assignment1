using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace TestLibrary
{
    /// <summary>
    /// IMPORTANT NOTE: DO NOT CHANGE THE TEST CODE!! EVER. :)
    /// LinkedListTest - A class for testing the LinkedList class
    /// LinkedList - A class for creating and manipulating a doubly linked list of nodes containing generic data of type T.
    /// 
    /// Assignment:     #1
    /// Course:         ADEV-3009
    /// Date Created:   October 17th, 2022
    /// 
    /// @author: Scott Wachal
    /// @version 1.0
    /// </summary>
    [TestFixture]
    public class LinkedListTest
    {
        #region Milestone 1

        #region Constructor Tests, (requires .Head, .Tail, .Size, IsEmpty())
        /// <summary>
        /// Test the constructor to ensure the default values are set properly.
        /// </summary>
        [Test]
        public void new_constructor_has_size_of_zero_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Size, Is.EqualTo(0));
        }

        [Test]
        /// <summary>
        /// Test GetHead returns null when a new constructor is called.
        /// </summary>
        public void GetHead_is_null_on_new_constructor_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Head, Is.EqualTo(null));
        }

        [Test]
        /// <summary>
        /// Test GetTail returns null when a new constructor is called.
        /// </summary>
        public void GetTail_is_null_on_new_constructor_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Tail, Is.EqualTo(null));
        }

        /// <summary>
        /// Test IsEmpty() should return true on an empty list.
        /// </summary>
        [Test]
        public void IsEmpty_is_true_on_new_constructor_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.IsEmpty(), Is.True);
        }

        /// <summary>
        /// Test IsEmpty() should return true on an empty list.
        /// </summary>
        [Test]
        public void IsEmpty_is_false_on_list_with_size_greater_than_0_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _); // Size == 1, Head and Tail also exist here.
            ClassicAssert.That(list.IsEmpty(), Is.False);
        }

        /// <summary>
        /// Test IsEmpty() should return true on an empty list.
        /// </summary>
        [Test]
        public void IsEmpty_is_false_on_larger_list_with_size_greater_than_0_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(10, out _); // Size == 1, Head and Tail also exist here.
            ClassicAssert.That(list.IsEmpty(), Is.False);
        }

        #endregion

        #region AddFirst(), requires: .Size / GetHead() / GetTail()
        /// <summary>
        /// Test AddFirst() to ensure node is added to list.
        /// </summary>
        [Test]
        public void AddFirst_on_emptylist_count_increases_from_0_to_1_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Size, Is.EqualTo(0));
            list.AddFirst(new Employee(1));
            ClassicAssert.That(list.Size, Is.EqualTo(1));
        }

        /// <summary>
        /// Test AddFirst() method to ensure the head pointer is updated when first object is inserted.
        /// </summary>
        [Test]
        public void AddFirst_on_emptylist_Head_Updated_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Head, Is.EqualTo(null));
            list.AddFirst(new Employee(1));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        }

        /// <summary>
        /// Test AddFirst() method to ensure the tail pointer is updated when first object is inserted.
        /// </summary>
        [Test]
        public void AddFirst_on_emptylist_Tail_Updated_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Tail, Is.EqualTo(null));
            list.AddFirst(new Employee(1));
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(1)) == 0);
        }

        /// <summary>
        /// Test AddFirst() to ensure it throws and exception if element is null
        /// </summary>
        [Test]
        public void AddFirst_null_element_is_not_allowed_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.AddFirst(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// Test AddFirst() method to ensure the head/tail pointers are updated when 2 elements are inserted.
        /// </summary>
        [Test]
        public void AddFirst_on_list_of_2_Head_tail_and_size_Updated_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(new Employee(2));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(1));
            list.AddFirst(new Employee(1));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(2));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Test AddFirst() method to ensure the head/tail pointers are updated when 3 elements are inserted.
        /// </summary>
        [Test]
        public void AddFirst_on_list_of_3_Head_tail_and_size_Updated_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(new Employee(3));
            list.AddFirst(new Employee(2));
            list.AddFirst(new Employee(1));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(3));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Test AddFirst() method to ensure the head/tail pointers are updated when 3 elements are inserted.
        /// </summary>
        [Test]
        public void AddFirst_on_large_list_Head_tail_and_size_Updated_Test()
        {
            int listSize = 10;
            LinkedList<Employee> list = new LinkedList<Employee>();
            for (int i = listSize; i >= 1; i--)
            {
                list.AddFirst(new Employee(i));
                ClassicAssert.That(list.Size, Is.EqualTo(Math.Abs(listSize - i) + 1));
                ClassicAssert.That(list.Head.Element.CompareTo(new Employee(i)) == 0);
                ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize)) == 0);
                ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
            }
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(listSize));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Test AddFirst() method to ensure the head pointer is updated when many objects are inserted.
        /// </summary>
        [Test]
        public void AddFirst_on_larger_Existing_list_Head_and_size_Updated_Test()
        {
            int listSize = 5;
            Node<Employee>[] nodes;
            LinkedList<Employee> list = CreateListWithoutMethods(listSize, out nodes); // pregenerated list
            list.AddFirst(new Employee(listSize + 1)); // executes your AddFirst
            ClassicAssert.That(list.Size, Is.EqualTo(6)); // size increases
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(listSize + 1)) == 0); // head contains the new value
            ClassicAssert.That(list.Tail.Element.CompareTo(nodes[listSize - 1].Element) == 0); // tail is still the same
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list)); // all pointers are connected properly
        }
        #endregion

        #region .Size
        /// <summary>
        /// Test .Size to make sure it returns the proper size; mostly for fun here. :)
        /// </summary>
        [Test]
        public void GetSize_returns_correct_value_after_random_adds_Test()
        {
            Random rnd = new Random();
            int numberOfElements = rnd.Next(1, 50);
            LinkedList<Employee> list = new LinkedList<Employee>();
            for (int i = 0; i < numberOfElements; i++) { list.AddFirst(new Employee(i)); }
            ClassicAssert.That(list.Size, Is.EqualTo(numberOfElements));
        }
        #endregion

        #region GetFirst() and GetLast()

        /// <summary>
        /// Test that GetFirst throws an exception when called on an empty list, because Null.Element doesn't exist!
        /// </summary>
        [Test]
        public void GetFirst_on_emptylist_throws_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.GetFirst(), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test that GetFirst returns the head's element
        /// </summary>
        [Test]
        public void GetFirst_on_list_of_1_returns_head_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(list.Tail.Element.CompareTo(list.GetFirst()) == 0);
        }

        /// <summary>
        /// Test that GetFirst returns the head's element on LARGE list
        /// </summary>
        [Test]
        public void GetFirst_on_existing_larger_list_returns_head_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(10, out _);
            ClassicAssert.That(list.Head.Element.CompareTo(list.GetFirst()) == 0);
        }

        /// <summary>
        /// Test that GetLast throws an exception when called on an empty list, because Null.Element doesn't exist!
        /// </summary>
        [Test]
        public void GetLast_on_emptylist_throws_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.GetLast(), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test that GetLast returns the tail's element
        /// </summary>
        [Test]
        public void GetLast_on_list_of_1_returns_tail_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(list.Tail.Element.CompareTo(list.GetLast()) == 0);
        }

        /// <summary>
        /// Test that GetLast returns the tail's element
        /// </summary>
        [Test]
        public void GetLast_on_existing_larger_list_returns_tail_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(10, out _);
            ClassicAssert.That(list.Tail.Element.CompareTo(list.GetLast()) == 0);
        }
        #endregion

        #region Clear()
        /// <summary>
        /// Test that Clear() empties a list.
        /// </summary>
        [Test]
        public void ClearTest()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
            list.Clear();
            ClassicAssert.That(list.IsEmpty, Is.EqualTo(true));
            ClassicAssert.That(list.Size, Is.EqualTo(0));
            ClassicAssert.That(list.Head, Is.EqualTo(null));
            ClassicAssert.That(list.Tail, Is.EqualTo(null));
        }

        /// <summary>
        /// Test that calling Clear() on an empty list doesn't throw an exception.
        /// </summary>
        [Test]
        public void ClearEmptyListTest()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            try
            {
                list.Clear();
            }
            catch (Exception)
            {
                ClassicAssert.Fail("Clear() should not have thrown exception.");
            }
            ClassicAssert.Pass("Clear() did not throw exception.");
        }
        #endregion

        #region SetFirst(element)
        /// <summary>
        /// Test SetFirst() on an empty list raises an exception.
        /// </summary>
        [Test]
        public void SetFirst_on_emptyList_throws_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.SetFirst(new Employee(1)), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test SetFirst() throws exception if element null
        /// </summary>
        [Test]
        public void SetFirst_throws_exception_when_element_null_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.SetFirst(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// Test SetFirst() replaces element on the head node on list of 1
        /// </summary>
        [Test]
        public void SetFirst_on_list_of_1_replaces_head_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            list.SetFirst(new Employee(2)); // changes from 1 to 2
            ClassicAssert.That(list.GetFirst().CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(1)); //ensure size doesn't change!
        }

        /// <summary>
        /// Test SetFirst() returns the element that has been replaced.
        /// </summary>
        [Test]
        public void SetFirst_Returns_ReplacedElement_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            var returnedData = list.SetFirst(new Employee(2));
            ClassicAssert.That(returnedData.CompareTo(new Employee(1)) == 0);
        }

        /// <summary>
        /// Test SetFirst() does_not_impact_an_existing_list (head/tail/size/pointers)
        /// </summary>
        [Test]
        public void SetFirst_does_not_impact_an_existing_larger_list_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
            var returnedData = list.SetFirst(new Employee(6));
            ClassicAssert.That(returnedData.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.GetFirst().CompareTo(new Employee(6)) == 0);
            ClassicAssert.That(list.Size == 5);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        #endregion

        #region SetLast(element)
        /// <summary>
        /// Test SetLast() on an empty list raises an exception.
        /// </summary>
        [Test]
        public void SetLast_on_emptyList_throws_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.SetLast(new Employee(1)), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test SetLast() throws exception if element null
        /// </summary>
        [Test]
        public void SetLast_throws_exception_when_element_null_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.SetLast(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// Test SetLast() replaces element on the head node on list of 1
        /// </summary>
        [Test]
        public void SetLast_on_list_of_1_replaces_head_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            list.SetLast(new Employee(2)); // changes from 1 to 2
            ClassicAssert.That(list.GetLast().CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(1)); //ensure size doesn't change!
        }

        /// <summary>
        /// Test SetLast() returns the element that has been replaced.
        /// </summary>
        [Test]
        public void SetLast_Returns_ReplacedElement_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            var returnedData = list.SetLast(new Employee(2));
            ClassicAssert.That(returnedData.CompareTo(new Employee(1)) == 0);
        }

        /// <summary>
        /// Test SetLast() does_not_impact_an_existing_list (head/tail/size/pointers)
        /// </summary>
        [Test]
        public void SetLast_does_not_impact_an_existing_larger_list_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
            var returnedData = list.SetLast(new Employee(6));
            ClassicAssert.That(returnedData.CompareTo(new Employee(5)) == 0);
            ClassicAssert.That(list.GetLast().CompareTo(new Employee(6)) == 0);
            ClassicAssert.That(list.Size == 5);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }
        #endregion
        #region AddLast()
        /// <summary>
        /// Test AddLast() to ensure node is added to list.
        /// </summary>
        [Test]
        public void AddLast_on_emptylist_count_increases_from_0_to_1_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Size, Is.EqualTo(0));
            list.AddLast(new Employee(1));
            ClassicAssert.That(list.Size, Is.EqualTo(1));
        }

        /// <summary>
        /// Test AddLast() method to ensure the head pointer is updated when first object is inserted.
        /// </summary>
        [Test]
        public void AddLast_on_emptylist_Head_Updated_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Head, Is.EqualTo(null));
            list.AddLast(new Employee(1));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        }

        /// <summary>
        /// Test AddLast() method to ensure the tail pointer is updated when first object is inserted.
        /// </summary>
        [Test]
        public void AddLast_on_emptylist_Tail_Updated_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Tail, Is.EqualTo(null));
            list.AddLast(new Employee(1));
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(1)) == 0);
        }

        /// <summary>
        /// Test AddLast() to ensure it throws and exception if element is null
        /// </summary>
        [Test]
        public void AddLast_null_element_is_not_allowed_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.AddLast(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// Test AddLast() method to ensure the head/tail pointers are updated when 2 elements are inserted.
        /// </summary>
        [Test]
        public void AddLast_on_list_of_2_Head_tail_and_size_Updated_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddLast(new Employee(2));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(1));
            list.AddLast(new Employee(1));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(2));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Test AddLast() method to ensure the head/tail pointers are updated when 3 elements are inserted.
        /// </summary>
        [Test]
        public void AddLast_on_list_of_3_Head_tail_and_size_Updated_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddLast(new Employee(3));
            list.AddLast(new Employee(2));
            list.AddLast(new Employee(1));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(3)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(3));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Test AddLast() method to ensure the head/tail pointers are updated when 3 elements are inserted.
        /// </summary>
        [Test]
        public void AddLast_on_large_list_Head_tail_and_size_Updated_Test()
        {
            int listSize = 10;
            LinkedList<Employee> list = new LinkedList<Employee>();
            for (int i = listSize; i >= 1; i--)
            {
                list.AddLast(new Employee(i));
                ClassicAssert.That(list.Head.Element.CompareTo(new Employee(listSize)) == 0);
                ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(i)) == 0);
                ClassicAssert.That(list.Size, Is.EqualTo(Math.Abs(listSize - i + 1)));
            }

            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(listSize)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(listSize));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Test AddLast() method to ensure the head pointer is updated when many objects are inserted.
        /// </summary>
        [Test]
        public void AddLast_on_larger_Existing_list_Head_and_size_Updated_Test()
        {
            int listSize = 5;
            Node<Employee>[] nodes;
            LinkedList<Employee> list = CreateListWithoutMethods(listSize, out nodes); // pregenerated list
            ClassicAssert.That(list.Size, Is.EqualTo(5));
            list.AddLast(new Employee(listSize + 1)); // executes your AddLast
            ClassicAssert.That(list.Size, Is.EqualTo(6)); // size increases
            ClassicAssert.That(list.Head.Element.CompareTo(nodes[0].Element) == 0); // head contains the new value
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize + 1)) == 0); // tail is still the same
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list)); // all pointers are connected properly
        }
        #endregion

        #endregion

        #region Milestone 2
        #region RemoveFirst()

        /// <summary>
        /// Test calling RemoveFirst() on an empty list causes an exception.
        /// </summary>
        [Test]
        public void RemoveFirst_on_EmptyList_throws_exception_test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.RemoveFirst(), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test RemoveFirst() returns reduced count by 1
        /// </summary>
        [Test]
        public void RemoveFirst_decreases_count_by_1_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            list.RemoveFirst();
            ClassicAssert.That(list.Size, Is.EqualTo(0));
        }

        /// <summary>
        /// Test RemoveFirst() returns the element removed.
        /// </summary>
        [Test]
        public void RemoveFirst_Returns_first_Element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            var firstElement = list.GetFirst();
            var returnedElement = list.RemoveFirst();
            ClassicAssert.That(returnedElement.CompareTo(firstElement) == 0);
        }

        /// <summary>
        /// Test RemoveFirst() removes the head and tail on size 1 list
        /// </summary>
        [Test]
        public void RemoveFirst_on_list_of_size_1_removes_head_and_tail_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            list.RemoveFirst();
            ClassicAssert.That(list.IsEmpty(), Is.EqualTo(true));
            ClassicAssert.That(list.Head, Is.EqualTo(null));
            ClassicAssert.That(list.Tail, Is.EqualTo(null));
        }

        /// <summary>
        /// RemoveFirst_on_list_2_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveFirst_on_list_2_updates_head_pointers_size_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
            var returnedElement = list.RemoveFirst();
            ClassicAssert.That(list.Size, Is.EqualTo(1));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveFirst_on_list_3_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveFirst_on_list_3_updates_head_pointers_size_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(3, out _);
            var returnedElement = list.RemoveFirst();
            ClassicAssert.That(list.Size, Is.EqualTo(2));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveFirst_on_larger_list_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveFirst_on_larger_list_updates_head_pointers_size_Test()
        {
            int listSize = 10;
            LinkedList<Employee> list = CreateListWithoutMethods(listSize, out _);
            var returnedElement = list.RemoveFirst();
            ClassicAssert.That(list.Size, Is.EqualTo(listSize - 1));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveFirst_multiple_times_on_larger_list_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveFirst_multiple_times_on_larger_list_updates_head_pointers_size_Test()
        {
            int listSize = 10;
            LinkedList<Employee> list = CreateListWithoutMethods(listSize, out _);
            for (int i = 1; i < listSize; i++)
            {
                var returnedElement = list.RemoveFirst();
                ClassicAssert.That(returnedElement.CompareTo(new Employee(i)) == 0);
                ClassicAssert.That(list.Size, Is.EqualTo(listSize - i));
                ClassicAssert.That(list.Head.Element.CompareTo(new Employee(i + 1)) == 0);
                ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize)) == 0);
                ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
            }
            var lastReturnedElement = list.RemoveFirst();
            ClassicAssert.That(lastReturnedElement.CompareTo(new Employee(listSize)) == 0);
            ClassicAssert.That(list.IsEmpty());
            ClassicAssert.That(list.Head, Is.EqualTo(null));
            ClassicAssert.That(list.Tail, Is.EqualTo(null));
        }
        #endregion

        #region RemoveLast()
        /// <summary>
        /// Test calling RemoveLast() on an empty list causes an exception.
        /// </summary>
        [Test]
        public void RemoveLast_on_EmptyList_throws_exception_test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.RemoveLast(), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test RemoveLast() returns reduced count by 1
        /// </summary>
        [Test]
        public void RemoveLast_decreases_count_by_1_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            list.RemoveLast();
            ClassicAssert.That(list.Size, Is.EqualTo(0));
        }

        /// <summary>
        /// Test RemoveLast() returns the element removed.
        /// </summary>
        [Test]
        public void RemoveLast_Returns_first_Element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            var firstElement = list.GetLast();
            var returnedElement = list.RemoveLast();
            ClassicAssert.That(returnedElement.CompareTo(firstElement) == 0);
        }

        /// <summary>
        /// Test RemoveLast() removes the head and tail on size 1 list
        /// </summary>
        [Test]
        public void RemoveLast_on_list_of_size_1_removes_head_and_tail_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            list.RemoveLast();
            ClassicAssert.That(list.IsEmpty(), Is.EqualTo(true));
            ClassicAssert.That(list.Head, Is.EqualTo(null));
            ClassicAssert.That(list.Tail, Is.EqualTo(null));
        }

        /// <summary>
        /// RemoveLast_on_list_2_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveLast_on_list_2_updates_head_pointers_size_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
            var returnedElement = list.RemoveLast();
            ClassicAssert.That(list.Size, Is.EqualTo(1));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveLast_on_list_3_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveLast_on_list_3_updates_head_pointers_size_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(3, out _);
            var returnedElement = list.RemoveLast();
            ClassicAssert.That(list.Size, Is.EqualTo(2));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(3)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveLast_on_larger_list_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveLast_on_larger_list_updates_head_pointers_size_Test()
        {
            int listSize = 10;
            LinkedList<Employee> list = CreateListWithoutMethods(listSize, out _);
            var returnedElement = list.RemoveLast();
            ClassicAssert.That(list.Size, Is.EqualTo(listSize - 1));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(listSize)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize - 1)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveLast_multiple_times_on_larger_list_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveLast_multiple_times_on_larger_list_updates_head_pointers_size_Test()
        {
            int listSize = 10;
            LinkedList<Employee> list = CreateListWithoutMethods(listSize, out _);
            for (int i = 10, count = 1; i > 1; i--, count++)
            {
                var returnedElement = list.RemoveLast();
                ClassicAssert.That(returnedElement.CompareTo(new Employee(i)) == 0);
                ClassicAssert.That(list.Size, Is.EqualTo(listSize - count));
                ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
                ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize - count)) == 0);
                ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
            }
            var lastReturnedElement = list.RemoveLast();
            ClassicAssert.That(lastReturnedElement.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.IsEmpty());
            ClassicAssert.That(list.Head, Is.EqualTo(null));
            ClassicAssert.That(list.Tail, Is.EqualTo(null));
        }
        #endregion

        #region Get(position)
        /// <summary>
        /// Make sure that calling Get(position) on an empty list results in an exception.
        /// </summary>
        [Test]
        public void Get_By_Position_On_EmptyList_throws_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.Get(1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Make sure at calling Get(position) with a negative number results in an exception.
        /// </summary>
        [Test]
        public void Get_By_number_less_than_1_on_existingList_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
            ClassicAssert.That(() => list.Get(-1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that calling Get(positoin) with a value larger than the size of the list results in an exception.
        /// </summary>
        [Test]
        public void Get_By_Position_larger_than_list_size_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
            ClassicAssert.That(() => list.Get(list.Size + 1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that Get(position) returns the element at the correct position.
        /// </summary>
        [Test]
        public void Get_By_Position_1_on_existingList_returns_head_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
            ClassicAssert.That(list.Get(1).CompareTo(list.GetFirst()).Equals(0));
        }

        /// <summary>D
        /// Ensure that Get(position) returns the element at the correct position.
        /// </summary>
        [Test]
        public void Get_By_Position_size_on_existingList_returns_tail_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
            ClassicAssert.That(list.Get(list.Size).CompareTo(list.GetLast()).Equals(0));
        }

        /// <summary>
        /// Ensure that Get(position) returns the element at the correct position.
        /// </summary>
        [Test]
        public void Get_By_Position_3_on_existingList_returns_correct_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
            ClassicAssert.That(list.Get(3).CompareTo(list.Head.Next.Next.Element).Equals(0));
        }

        /// <summary>
        /// Ensure that Get(position) returns the element at the correct position.
        /// </summary>
        [Test]
        public void Get_By_Position_on_LARGE_existingList_returns_correct_elements_and_structure_is_not_changed_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(10, out _);
            Node<Employee> node = list.Head;
            for (int i = 1; i <= list.Size; i++)
            {
                ClassicAssert.That(list.Get(i).CompareTo(node.Element).Equals(0));
                node = node.Next;
            }

            // Head/Tail and all pointers are all intact and correct:
            CheckIntegrityBetweenAllNodes(list);
        }
        #endregion

        #region AddAfter(element, position)
        /// <summary>
        /// Ensure that calling AddAfter() on an empty list will result in an exception.
        /// </summary>
        [Test]
        public void AddAfterPosition_on_EmptyList_throws_exception_test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.AddAfter(new Employee(1), 1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that passing a negative position value to AddAfter(element, position) results in an exception.
        /// </summary>
        [Test]
        public void AddAfterPosition_Negative_Position_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.AddAfter(new Employee(2), -1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that calling AddBefore(element, position) with a value of zero results in an exception.
        /// </summary>
        [Test]
        public void AddAfterPosition_Zero_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.AddAfter(new Employee(1), 0), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that passing a position value larger than size to AddAfter(element, position) results in an exception.
        /// </summary>
        [Test]
        public void AddAfterPosition_getsize_plus_1_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.AddAfter(new Employee(1), list.Size + 1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that passing a null element, throws and exception.
        /// </summary>
        [Test]
        public void AddAfterPosition_null_element_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.AddAfter(null, 1), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// AddAfter position 1 on list of 1 updates size and Tail
        /// </summary>
        [Test]
        public void AddAfterByPosition_on_list_of_1_increases_size_updates_tail_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            list.AddAfter(new Employee(2), 1); // insert 2 after 1
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Size.Equals(2));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// AddAfter position 1 on list of 2, adding after head, inserts between head/tail
        /// </summary>
        [Test]
        public void AddAfterByPosition_1_on_list_of_2_adding_inserts_between_head_tail_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
            list.AddAfter(new Employee(3), 1); // insert 3 after 1, list will be: 1, 3, 2
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(3)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Size.Equals(3));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// AddAfter position 1 on list of Five updates size and node pointers
        /// </summary>
        [Test]
        public void AddAfterByPosition_1_on_list_of_5_increases_size_updates_node_pointers_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
            list.AddAfter(new Employee(6), 1); // insert 6 after 1, list will be: 1, 6, 2, 3, 4, 5
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(6)) == 0);
            ClassicAssert.That(list.Head.Next.Next.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(5)) == 0);
            ClassicAssert.That(list.Size.Equals(6));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// AddAfter by position in the middle of larger list, updates size, node pointers
        /// </summary>
        [Test]
        public void AddAfterByPosition_on_larger_list_add_after_middle_node_increases_size_updates_node_pointers_Test()
        {
            Node<Employee>[] nodes;
            LinkedList<Employee> list = CreateListWithoutMethods(8, out nodes);
            list.AddAfter(new Employee(9), 4); // insert 9 after 4: 1, 2, 3, 4, 9, 5, 6, 7, 8
            ClassicAssert.That(nodes[3].Element.CompareTo(new Employee(4)) == 0);
            ClassicAssert.That(nodes[3].Next.Element.CompareTo(new Employee(9)) == 0);
            ClassicAssert.That(nodes[4].Element.CompareTo(new Employee(5)) == 0);
            ClassicAssert.That(nodes[4].Previous.Element.CompareTo(new Employee(9)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(8)) == 0);
            ClassicAssert.That(list.Size.Equals(9));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Checking edge case; Ensure that passing the tail position will append to the end of the list without error.
        /// </summary>
        [Test]
        public void AddAfterByPosition_using_last_position_on_existingList_updates_tail_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
            list.AddAfter(new Employee(6), list.Size); // 1, 2, 3, 4, 5 then 6 is added as the tail
            ClassicAssert.That(list.Size.Equals(6));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Previous.Element.CompareTo(new Employee(5)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(6)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }
        #endregion

        #region AddBefore(element, positon)
        /// <summary>
        /// Ensure that calling AddBefore() on an empty list will result in an exception.
        /// </summary>
        [Test]
        public void AddBeforePosition_on_EmptyList_throws_exception_test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.AddBefore(new Employee(1), 1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that passing a negative position value to AddBefore(element, position) results in an exception.
        /// </summary>
        [Test]
        public void AddBeforePosition_Negative_Position_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.AddBefore(new Employee(2), -1), Throws.Exception.TypeOf<ApplicationException>());
        }
        /// <summary>
        /// Ensure that calling AddBefore(element, position) with a value of zero results in an exception.
        /// </summary>
        [Test]
        public void AddBeforePosition_Zero_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.AddBefore(new Employee(1), 0), Throws.Exception.TypeOf<ApplicationException>());
        }
        /// <summary>
        /// Ensure that passing a position value larger than size to AddBefore(element, position) results in an exception.
        /// </summary>
        [Test]
        public void AddBeforePosition_getsize_plus_1_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.AddBefore(new Employee(1), list.Size + 1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// AddBefore position 1 on list of 1 updates size and Head
        /// </summary>
        [Test]
        public void AddBeforeByPosition_on_list_of_1_increases_size_updates_head_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            list.AddBefore(new Employee(2), 1); // insert 2 before 1
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Size.Equals(2));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// AddBefore position 2 on list of 2, adding before tail, inserts between head/tail
        /// </summary>
        [Test]
        public void AddBeforeByPosition_2_on_list_of_2_adding_inserts_between_head_tail_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
            list.AddBefore(new Employee(3), 2); // insert 3 before 2, list will be: 1, 3, 2
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(3)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Size.Equals(3));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// AddBefore position size on list of Five updates size and node pointers
        /// </summary>
        [Test]
        public void AddBeforeByPosition_last_position_on_list_of_5_increases_size_updates_node_pointers_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
            list.AddBefore(new Employee(6), list.Size); // insert 6 before 5, list will be: 1, 2, 3, 4, 6, 5
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Previous.Previous.Element.CompareTo(new Employee(4)) == 0);
            ClassicAssert.That(list.Tail.Previous.Element.CompareTo(new Employee(6)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(5)) == 0);
            ClassicAssert.That(list.Size.Equals(6));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// AddBefore by middle position of larger list, updates size, node pointers
        /// </summary>
        [Test]
        public void AddBeforeByPosition_middle_on_larger_list_increases_size_updates_node_pointers_Test()
        {
            Node<Employee>[] nodes;
            LinkedList<Employee> list = CreateListWithoutMethods(8, out nodes);
            list.AddBefore(new Employee(9), 4); // insert 9 before 4: 1, 2, 3, 9, 4, 5, 6, 7, 8
            ClassicAssert.That(nodes[2].Element.CompareTo(new Employee(3)) == 0);
            ClassicAssert.That(nodes[2].Next.Element.CompareTo(new Employee(9)) == 0);
            ClassicAssert.That(nodes[3].Element.CompareTo(new Employee(4)) == 0);
            ClassicAssert.That(nodes[3].Previous.Element.CompareTo(new Employee(9)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(8)) == 0);
            ClassicAssert.That(list.Size.Equals(9));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Checking edge case; Ensure that passing the head position will append to the beginning of the list without error.
        /// </summary>
        [Test]
        public void AddBeforeByPosition_using_first_position_on_existingList_updates_head_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
            list.AddBefore(new Employee(6), 1); // 6, 1, 2, 3, 4, 5 
            ClassicAssert.That(list.Size.Equals(6));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(6)) == 0);
            ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(5)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }
        #endregion

        #region Remove(position)
        /// <summary>
        /// Make sure that calling Remove(position) on an empty list results in an exception.
        /// </summary>
        [Test]
        public void RemoveByPosition_On_EmptyList_throw_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.Remove(1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Make sure at calling Remove(position) with a negative number results in an exception.
        /// </summary>
        [Test]
        public void RemoveByPosition_Negative_number_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.Remove(-1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that calling Remove(position) with a value of zero results in an exception.
        /// </summary>
        [Test]
        public void RemoveByPosition_Zero_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.Remove(0), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that calling Remove(position) with a value larger than the size of the list results in an exception.
        /// </summary>
        [Test]
        public void RemoveByPosition_getsize_plus_one_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.Remove(list.Size + 1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that Remove() returns the element removed.
        /// </summary>
        [Test]
        public void RemoveByPosition_Returns_an_Element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            var returnedElement = list.Remove(1);
            ClassicAssert.That(returnedElement.CompareTo(new Employee(1)) == 0);
        }

        /// <summary>
        /// Ensure that Remove() decreases count and clears the list
        /// </summary>
        [Test]
        public void RemoveByPosition_decreases_count_by_one_updates_head_tail_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            var returnedElement = list.Remove(1);
            ClassicAssert.That(list.Size, Is.EqualTo(0));
            ClassicAssert.That(list.Head, Is.Null);
            ClassicAssert.That(list.Tail, Is.Null);
        }

        /// <summary>
        /// Ensure that Remove() list of 2 on head decreases count and updates head/tail
        /// </summary>
        [Test]
        public void RemoveByPosition_list_of_2_remove_head_updates_head_tail_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
            var returnedElement = list.Remove(1); // removes 1
            ClassicAssert.That(list.Size, Is.EqualTo(1));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Equals(list.Head));
        }

        /// <summary>
        /// Ensure that Remove() list of 2 on Tail decreases count and updates head/tail
        /// </summary>
        [Test]
        public void RemoveByPosition_list_of_2_remove_tail_updates_head_tail_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
            var returnedElement = list.Remove(list.Size); // removes 2
            ClassicAssert.That(list.Size, Is.EqualTo(1));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Equals(list.Head));
        }

        /// <summary>
        /// RemoveByPosition_remove_tail_on_list_of_size_3_Test
        /// </summary>
        [Test]
        public void RemoveByPosition_remove_tail_on_list_of_size_3_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(3, out _);
            var returnedElement = list.Remove(list.Size); // removes employee 3, Remaining list is: 1, 2
            ClassicAssert.That(list.Size, Is.EqualTo(2));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(3)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveByPosition_remove_head_on_list_of_size_3_Test
        /// </summary>
        [Test]
        public void RemoveByPosition_remove_head_on_list_of_size_3_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(3, out _);
            var returnedElement = list.Remove(1); // removes employee 1, Remaining list is: 2, 3
            ClassicAssert.That(list.Size, Is.EqualTo(2));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveByPosition_remove_middle_on_list_of_size_3_Test
        /// </summary>
        [Test]
        public void RemoveByPosition_remove_middle_on_list_of_size_3_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(3, out _);
            var returnedElement = list.Remove(2); // removes employee 2, Remaining list is: 1, 3
            ClassicAssert.That(list.Size, Is.EqualTo(2));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveByPosition_remove_middle_on_larger_list_Test
        /// </summary>
        [Test]
        public void RemoveByPosition_remove_middle_on_larger_list_Test()
        {
            int listSize = 10;
            LinkedList<Employee> list = CreateListWithoutMethods(10, out _);
            var returnedElement = list.Remove(listSize / 2); // removes employee 5, Remaining list is: 1 2 3 4 6 7 8 9 10
            ClassicAssert.That(list.Size, Is.EqualTo(listSize - 1));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(listSize / 2)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }
        #endregion

        #region Set(element, position)
        /// <summary>
        /// Test Set(position) on an empty list results in an exception.
        /// </summary>
        [Test]
        public void SetByPosition_On_EmptyList_throws_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.Set(new Employee(1), 1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test Set(position) with a negative number results in an exception.
        /// </summary>
        [Test]
        public void SetByPosition_Negative_Value_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.Set(new Employee(2), -1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test Set(position) with a value of zero results in an exception.
        /// </summary>
        [Test]
        public void SetByPosition_Zero_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.Set(new Employee(2), 0), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test Set(position) with a value larger than the size of the list results in an exception.
        /// </summary>
        [Test]
        public void SetByPositionLargerThanSizeTest()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
            ClassicAssert.That(() => list.Set(new Employee(2), list.Size + 1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that passing null value to Set(element, position) results in an exception.
        /// </summary>
        [Test]
        public void SetByPosition_Null_element_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.Set(null, 1), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// Test Set(position) returns the replaced element.
        /// </summary>
        [Test]
        public void SetByPosition_Returns_old_Element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            Employee returnValue = list.Set(new Employee(2), 1);
            ClassicAssert.That(returnValue.CompareTo(new Employee(1)) == 0); // old value returned
        }

        /// <summary>
        /// Ensure that Set(position) sets the element at the correct position 
        /// Also checks that no changes occured to the size or structure: head/tail/node or their next/previous
        /// </summary>
        [Test]
        public void SetByPosition_1_on_list_of_1_updates_element_does_not_change_list_or_size_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            Node<Employee> head = list.Head; // saving a pointer to the old head
            list.Set(new Employee(2), 1);
            ClassicAssert.That(head.Element.CompareTo(new Employee(2)) == 0); // node in position 1 is now 2
            ClassicAssert.That(list.Head.Equals(head) && list.Tail.Equals(head)); // the head/tail is still the old head node in memory!
            ClassicAssert.That(list.Size.Equals(1)); // size hasn't changed
            // check that pointers are still correct and head/tail has not changed:
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Ensure that Set(position) sets the element at the correct position.
        /// Also ensures structure remains intact. No changes to Tail/Head/Nodes/Next/Previous/Size.
        /// </summary>
        [Test]
        public void SetByPosition_tail_on_large_list_updates_only_element_Test()
        {
            int listSize = 10;
            Node<Employee>[] nodes;
            LinkedList<Employee> list = CreateListWithoutMethods(listSize, out nodes);
            var returnedElement = list.Set(new Employee(listSize + 1), list.Size);
            ClassicAssert.That(returnedElement.CompareTo(new Employee(listSize)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize + 1)) == 0);
            for (int i = 1, index = 0; i < listSize; i++, index++)
            {
                ClassicAssert.That(nodes[index].Element.CompareTo(new Employee(i)) == 0);
            }
            ClassicAssert.That(list.Size.Equals(listSize));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Ensure that Set(position) sets the element at the correct position.
        /// Also ensures structure remains intact. No changes to Tail/Head/Nodes/Next/Previous/Size.
        /// </summary>
        [Test]
        public void SetByPosition_head_on_large_list_updates_only_element_Test()
        {
            int listSize = 10;
            Node<Employee>[] nodes;
            LinkedList<Employee> list = CreateListWithoutMethods(listSize, out nodes);
            var returnedElement = list.Set(new Employee(listSize + 1), 1);
            ClassicAssert.That(returnedElement.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(listSize + 1)) == 0);
            for (int i = 2, index = 1; i <= listSize; i++, index++)
            {
                ClassicAssert.That(nodes[index].Element.CompareTo(new Employee(i)) == 0);
            }
            ClassicAssert.That(list.Size.Equals(listSize));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Ensure that Set(position) sets the element at the correct position.
        /// Also ensures structure remains intact. No changes to Tail/Head/Nodes/Next/Previous/Size.
        /// </summary>
        [Test]
        public void SetByPosition_middle_on_large_list_updates_only_element_Test()
        {
            int listSize = 10;
            Node<Employee>[] nodes;
            LinkedList<Employee> list = CreateListWithoutMethods(listSize, out nodes);
            var returnedElement = list.Set(new Employee(listSize + 1), list.Size / 2);
            ClassicAssert.That(returnedElement.CompareTo(new Employee(list.Size / 2)) == 0);
            for (int i = 1, index = 0; i <= listSize; i++, index++)
            {
                if (i == list.Size / 2)
                    ClassicAssert.That(nodes[index].Element.CompareTo(new Employee(listSize + 1)) == 0);
                else
                    ClassicAssert.That(nodes[index].Element.CompareTo(new Employee(i)) == 0);
            }
            ClassicAssert.That(list.Size.Equals(listSize));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }
        #endregion
        #endregion

        //#region Milestone 3

        //#region Get(element)
        ///// <summary>
        ///// Make sure that Get(element) on an empty list results in an exception.
        ///// </summary>
        //[Test]
        //public void GetByElement_On_EmptyList_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = new LinkedList<Employee>();
        //    ClassicAssert.That(() => list.Get(new Employee(1)), Throws.Exception.TypeOf<ApplicationException>());
        //}

        ///// <summary>
        ///// Make sure that Get(element) when passed a null element results in an exception.
        ///// </summary>
        //[Test]
        //public void GetByElement_null_element_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    ClassicAssert.That(() => list.Get(null), Throws.Exception.TypeOf<ArgumentNullException>());
        //}

        ///// <summary>
        ///// Ensure that calling Get(element) with element that is not in the list results in an exception.
        ///// </summary>
        //[Test]
        //public void GetByElement_no_match_found_list_of_1_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    ClassicAssert.That(() => list.Get(new Employee(2)), Throws.Exception.TypeOf<ApplicationException>());
        //}

        ///// <summary>
        ///// Ensure that calling Get(element) with element that is not in a LARGE list results in an exception.
        ///// </summary>
        //[Test]
        //public void GetByElement_no_match_found_in_large_list_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
        //    ClassicAssert.That(() => list.Get(new Employee(6)), Throws.Exception.TypeOf<ApplicationException>());
        //}

        ///// <summary>
        ///// Ensure that Get by element returns the element at the correct element.
        ///// </summary>
        //[Test]
        //public void GetByElement_on_list_of_1_returns_the_element_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    ClassicAssert.That(list.Get(new Employee(1)).CompareTo(new Employee(1)) == 0);
        //}

        ///// <summary>
        ///// Ensure that Get by element returns the element at the correct element.
        ///// </summary>
        //[Test]
        //public void GetByElement_on_list_of_1_does_not_change_head_tail_size_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    ClassicAssert.That(list.Size.Equals(1));
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Ensure that Get by element returns the element at the correct element.
        ///// </summary>
        //[Test]
        //public void GetByElement_returns_the_elements_on_large_list_Test()
        //{
        //    int listSize = 10;
        //    LinkedList<Employee> list = CreateListWithoutMethods(listSize, out _);
        //    for (int i = 1; i <= listSize; i++)
        //    {
        //        ClassicAssert.That(list.Get(new Employee(i)).CompareTo(new Employee(i)) == 0);
        //    }
        //    // Ensure the node structure is still valid after running Get() (Head/Tail and pointers did not change)
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Ensure that calling Get(element) with element that matches multiple list elements returns only one result.
        ///// </summary>
        //[Test]
        //public void GetByElement_Multiple_matches_found_returns_first_match_test()
        //{
        //    Employee employee = new Employee(1);
        //    LinkedList<Employee> list = new LinkedList<Employee>();
        //    list.AddLast(employee);
        //    list.AddLast(new Employee(1));
        //    list.AddLast(new Employee(2));
        //    ClassicAssert.That(list.Get(employee).Equals(employee));
        //}

        ///// <summary>
        ///// Ensure that calling Get(element) with element that matches multiple list elements in a LARGE LIST returns only one result.
        ///// </summary>
        //[Test]
        //public void GetByElement_Multiple_matches_found_in_large_list_returns_first_match_test()
        //{
        //    Employee employee2 = new Employee(2);
        //    LinkedList<Employee> list = new LinkedList<Employee>();
        //    list.AddLast(new Employee(5));
        //    list.AddLast(new Employee(4));
        //    list.AddLast(new Employee(3));
        //    list.AddLast(employee2);
        //    list.AddLast(new Employee(2)); // will return false with .Equals() later if returning the 2nd match
        //    list.AddLast(new Employee(1));
        //    ClassicAssert.That(list.Get(employee2).Equals(employee2));
        //    // Ensure the node structure is still valid after running Get() (Head/Tail and pointers did not change)
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}
        //#endregion

        //#region AddAfter(element, oldElement)
        ///// <summary>
        ///// Ensure that calling AddAfter(element) on an empty list will result in an exception.
        ///// </summary>
        //[Test]
        //public void AddAfterByElement_on_EmptyList_throws_exception_test()
        //{
        //    LinkedList<Employee> list = new LinkedList<Employee>();
        //    ClassicAssert.That(() => list.AddAfter(new Employee(1), new Employee(2)), Throws.Exception.TypeOf<ApplicationException>());
        //}

        ///// <summary>
        ///// Ensure that passing element that is not in the list to AddAfter(element) results in an exception.
        ///// </summary>
        //[Test]
        //public void AddAfterByElement_no_match_found_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    // There exists no Employee 2, so we cannot add 3 after 2. It should throw an exception
        //    ClassicAssert.That(() => list.AddAfter(new Employee(3), new Employee(2)), Throws.Exception.TypeOf<ApplicationException>());
        //}

        ///// <summary>
        ///// Ensure that passing null value for oldElement to AddAfter(element, oldElement) results in an exception.
        ///// </summary>
        //[Test]
        //public void AddAfterByElement_when_oldElement_is_null_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    ClassicAssert.That(() => list.AddAfter(new Employee(2), null), Throws.Exception.TypeOf<ArgumentNullException>());
        //}

        ///// <summary>
        ///// Ensure that passing a null element, throws and exception.
        ///// </summary>
        //[Test]
        //public void AddAfterByElement_when_element_is_null_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    ClassicAssert.That(() => list.AddAfter(null, 1), Throws.Exception.TypeOf<ArgumentNullException>());
        //}

        ///// <summary>
        ///// AddAfter on list of 1 updates size and Tail
        ///// </summary>
        //[Test]
        //public void AddAfterByElement_on_list_of_1_increases_size_updates_tail_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    list.AddAfter(new Employee(2), new Employee(1)); // insert 2 after 1
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.That(list.Size.Equals(2));
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// AddAfter on list of 2, adding after head, inserts between head/tail
        ///// </summary>
        //[Test]
        //public void AddAfterByElement_on_list_of_2_adding_after_head_inserts_between_head_tail_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
        //    list.AddAfter(new Employee(3), new Employee(1)); // insert 3 after 1, list will be: 1, 3, 2
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(3)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.That(list.Size.Equals(3));
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// AddAfter on head on list of Five updates size, node pointers
        ///// </summary>
        //[Test]
        //public void AddAfterByElement_on_list_of_5_add_after_head_increases_size_updates_node_pointers_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
        //    list.AddAfter(new Employee(6), new Employee(1)); // insert 6 after 1, list will be: 1, 6, 2, 3, 4, 5
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(6)) == 0);
        //    ClassicAssert.That(list.Head.Next.Next.Element.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(5)) == 0);
        //    ClassicAssert.That(list.Size.Equals(6));
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// AddAfter in the middle of larger list, updates size, node pointers
        ///// </summary>
        //[Test]
        //public void AddAfterByElement_on_larger_list_add_after_middle_node_increases_size_updates_node_pointers_Test()
        //{
        //    Node<Employee>[] nodes;
        //    LinkedList<Employee> list = CreateListWithoutMethods(8, out nodes);
        //    list.AddAfter(new Employee(9), new Employee(4)); // insert 9 after 4: 1, 2, 3, 4, 9, 5, 6, 7, 8
        //    ClassicAssert.That(nodes[3].Element.CompareTo(new Employee(4)) == 0);
        //    ClassicAssert.That(nodes[3].Next.Element.CompareTo(new Employee(9)) == 0);
        //    ClassicAssert.That(nodes[4].Element.CompareTo(new Employee(5)) == 0);
        //    ClassicAssert.That(nodes[4].Previous.Element.CompareTo(new Employee(9)) == 0);
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(8)) == 0);
        //    ClassicAssert.That(list.Size.Equals(9));
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Checking edge case; Ensure that passing the tail element will append to the end of the list without error.
        ///// </summary>
        //[Test]
        //public void AddAfterByElement_using_last_element_on_existingList_updates_tail_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
        //    list.AddAfter(new Employee(6), list.Tail.Element); // 1, 2, 3, 4, 5 then 6 is added as the tail
        //    ClassicAssert.That(list.Size.Equals(6));
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Tail.Previous.Element.CompareTo(new Employee(5)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(6)) == 0);
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Ensure that passing a element that appears multiple times in the list to AddAfter(element, oldElement) element is inserted after first instance.
        ///// </summary>
        //[Test]
        //public void AddAfterByElement_multiple_match_found_adds_after_first_instance_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(3, out _);
        //    list.AddFirst(new Employee(1));
        //    Employee newlyAddedEmployee = new Employee(1);
        //    ClassicAssert.That(list.Size.Equals(4));
        //    // list is now: 1, 1, 2, 3
        //    list.AddAfter(newlyAddedEmployee, new Employee(1));
        //    // list will now be: 1, *newlyAddedEmployee* 1 , 1, 2, 3
        //    ClassicAssert.That(list.Size.Equals(5));
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Head.Next.Element.Equals(newlyAddedEmployee));
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}
        //#endregion

        //#region AddBefore(element, oldElement)
        ///// <summary>
        ///// Ensure that calling AddBefore(element) on an empty list will result in an exception.
        ///// </summary>
        //[Test]
        //public void AddBeforeByElement_on_EmptyList_throws_exception_test()
        //{
        //    LinkedList<Employee> list = new LinkedList<Employee>();
        //    ClassicAssert.That(() => list.AddBefore(new Employee(1), new Employee(2)), Throws.Exception.TypeOf<ApplicationException>());
        //}

        ///// <summary>
        ///// Ensure that passing element that is not in the list to AddBefore(element) results in an exception.
        ///// </summary>
        //[Test]
        //public void AddBeforeByElement_no_match_found_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    // There exists no Employee 2, so we cannot add 3 after 2. It should throw an exception
        //    ClassicAssert.That(() => list.AddBefore(new Employee(3), new Employee(2)), Throws.Exception.TypeOf<ApplicationException>());
        //}

        ///// <summary>
        ///// Ensure that passing a null oldElement, throws and exception.
        ///// </summary>
        //[Test]
        //public void AddBeforeByElement_null_oldElement_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    ClassicAssert.That(() => list.AddBefore(new Employee(2), null), Throws.Exception.TypeOf<ArgumentNullException>());
        //}

        ///// <summary>
        ///// Ensure that passing a null element, throws and exception.
        ///// </summary>
        //[Test]
        //public void AddBeforeByElement_null_element_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    ClassicAssert.That(() => list.AddBefore(null, new Employee(1)), Throws.Exception.TypeOf<ArgumentNullException>());
        //}
        ///// <summary>
        ///// AddBefore head on list of 1 updates size and Head
        ///// </summary>
        //[Test]
        //public void AddBeforeByElement_on_head_list_of_1_increases_size_updates_head_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    list.AddBefore(new Employee(2), new Employee(1)); // insert 2 before 1
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Size.Equals(2));
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// AddBefore position 2 on list of 2, adding before tail, inserts between head/tail
        ///// </summary>
        //[Test]
        //public void AddBeforeByElement_on_tail_list_of_2_adding_inserts_between_head_tail_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
        //    list.AddBefore(new Employee(3), new Employee(2)); // insert 3 before 2, list will be: 1, 3, 2
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(3)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.That(list.Size.Equals(3));
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// AddBefore tail on list of Five updates size and node pointers
        ///// </summary>
        //[Test]
        //public void AddBeforeByElement_last_position_on_list_of_5_increases_size_updates_node_pointers_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
        //    list.AddBefore(new Employee(6), new Employee(list.Size)); // insert 6 before 5, list will be: 1, 2, 3, 4, 6, 5
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Tail.Previous.Previous.Element.CompareTo(new Employee(4)) == 0);
        //    ClassicAssert.That(list.Tail.Previous.Element.CompareTo(new Employee(6)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(5)) == 0);
        //    ClassicAssert.That(list.Size.Equals(6));
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// AddBefore by middle node of larger list, updates size, node pointers
        ///// </summary>
        //[Test]
        //public void AddBeforeByElement_middle_on_larger_list_increases_size_updates_node_pointers_Test()
        //{
        //    Node<Employee>[] nodes;
        //    LinkedList<Employee> list = CreateListWithoutMethods(8, out nodes);
        //    list.AddBefore(new Employee(9), new Employee(4)); // insert 9 before 4: 1, 2, 3, 9, 4, 5, 6, 7, 8
        //    ClassicAssert.That(nodes[2].Element.CompareTo(new Employee(3)) == 0);
        //    ClassicAssert.That(nodes[2].Next.Element.CompareTo(new Employee(9)) == 0);
        //    ClassicAssert.That(nodes[3].Element.CompareTo(new Employee(4)) == 0);
        //    ClassicAssert.That(nodes[3].Previous.Element.CompareTo(new Employee(9)) == 0);
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(8)) == 0);
        //    ClassicAssert.That(list.Size.Equals(9));
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Checking edge case; Ensure that passing the head position will append to the beginning of the list without error.
        ///// </summary>
        //[Test]
        //public void AddBeforeByElement_using_head_on_existingList_updates_head_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
        //    list.AddBefore(new Employee(6), new Employee(1)); // 6, 1, 2, 3, 4, 5 
        //    ClassicAssert.That(list.Size.Equals(6));
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(6)) == 0);
        //    ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(5)) == 0);
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Ensure that passing a element that appears multiple times in the list to 
        ///// AddBefore(element, oldElement) element is inserted before the first instance.
        ///// </summary>
        //[Test]
        //public void AddBeforeByElement_multiple_match_found_adds_before_first_instance_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(3, out _);
        //    list.AddFirst(new Employee(1)); // creates a duplicate at the head
        //    Employee newlyAddedEmployee = new Employee(1);
        //    ClassicAssert.That(list.Size.Equals(4));
        //    // list is now: 1, 1, 2, 3
        //    list.AddBefore(newlyAddedEmployee, new Employee(1));
        //    // list will now be: *newlyAddedEmployee* 1, 1, 1, 2, 3
        //    ClassicAssert.That(list.Size.Equals(5));
        //    ClassicAssert.That(list.Head.Element.Equals(newlyAddedEmployee));
        //    ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}
        //#endregion

        //#region Remove(element)
        ///// <summary>
        ///// Make sure that calling Remove(element) on an empty list results in an exception.
        ///// </summary>
        //[Test]
        //public void RemoveByElement_On_EmptyList_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = new LinkedList<Employee>();
        //    ClassicAssert.That(() => list.Remove(new Employee(1)), Throws.Exception.TypeOf<ApplicationException>());
        //}

        ///// <summary>
        ///// Ensure that calling Remove(element) with element that is not in the list results in an exception.
        ///// </summary>
        //[Test]
        //public void RemoveByElement_Not_In_List_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    ClassicAssert.That(() => list.Remove(new Employee(2)), Throws.Exception.TypeOf<ApplicationException>());
        //}

        ///// <summary>
        ///// Ensure that calling Remove(element) with null element results in an exception.
        ///// </summary>
        //[Test]
        //public void RemoveByElement_null_element_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    ClassicAssert.That(() => list.Remove(null), Throws.Exception.TypeOf<ArgumentNullException>());
        //}

        ///// <summary>
        ///// Test Remove(element) on list of one, removes the first node, reduces size and adjusts head/tail.
        ///// </summary>
        //[Test]
        //public void RemoveByElement_on_list_of_1_decreases_size_sets_nulls_head_and_tail_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    list.Remove(new Employee(1));
        //    ClassicAssert.That(list.Size, Is.EqualTo(0));
        //    ClassicAssert.That(list.Head, Is.Null);
        //    ClassicAssert.That(list.Tail, Is.Null);
        //}

        ///// <summary>
        ///// Ensure that Remove(element) list of 2 on head decreases count and updates head/tail
        ///// </summary>
        //[Test]
        //public void RemoveByElement_list_of_2_remove_head_updates_head_tail_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
        //    var returnedElement = list.Remove(new Employee(1));
        //    ClassicAssert.That(list.Size, Is.EqualTo(1));
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.That(list.Tail.Equals(list.Head));
        //}

        ///// <summary>
        ///// Ensure that Remove(element) list of 2 on Tail decreases count and updates head/tail
        ///// </summary>
        //[Test]
        //public void RemoveByElement_list_of_2_remove_tail_updates_head_tail_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
        //    var returnedElement = list.Remove(new Employee(2));
        //    ClassicAssert.That(list.Size, Is.EqualTo(1));
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Tail.Equals(list.Head));
        //}

        ///// <summary>
        ///// Ensure that Remove(element) list of 3 on Tail decreases count and updates head/tail
        ///// </summary>
        //[Test]
        //public void RemoveByElement_remove_tail_on_list_of_size_3_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(3, out _);
        //    var returnedElement = list.Remove(new Employee(list.Size)); // removes employee 3, Remaining list is: 1, 2
        //    ClassicAssert.That(list.Size, Is.EqualTo(2));
        //    ClassicAssert.That(returnedElement.CompareTo(new Employee(3)) == 0);
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Ensure that Remove(element) list of 3 on Head decreases count and updates head/tail
        ///// </summary>
        //[Test]
        //public void RemoveByElement_remove_head_on_list_of_size_3_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(3, out _);
        //    var returnedElement = list.Remove(new Employee(1)); // removes employee 1, Remaining list is: 2, 3
        //    ClassicAssert.That(list.Size, Is.EqualTo(2));
        //    ClassicAssert.That(returnedElement.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Ensure that Remove(element) list of 3 - remove middle - decreases count and updates nodes
        ///// </summary>
        //[Test]
        //public void RemoveByElement_remove_middle_on_list_of_size_3_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(3, out _);
        //    var returnedElement = list.Remove(new Employee(2)); // removes employee 2, Remaining list is: 1, 3
        //    ClassicAssert.That(list.Size, Is.EqualTo(2));
        //    ClassicAssert.That(returnedElement.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Ensure that Remove(element) LARGE list - remove middle - decreases count and updates nodes
        ///// </summary>
        //[Test]
        //public void RemoveByElement_remove_middle_on_larger_list_Test()
        //{
        //    int listSize = 10;
        //    LinkedList<Employee> list = CreateListWithoutMethods(10, out _);
        //    var returnedElement = list.Remove(new Employee(listSize / 2)); // removes employee 5, Remaining list is: 1 2 3 4 6 7 8 9 10
        //    ClassicAssert.That(list.Size, Is.EqualTo(listSize - 1));
        //    ClassicAssert.That(returnedElement.CompareTo(new Employee(listSize / 2)) == 0);
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize)) == 0);
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Ensure that calling Remove(element) with element that matches multiple list elements returns only one result.
        ///// </summary>
        //[Test]
        //public void RemoveByElement_multiple_matches_removes_first_match_test()
        //{
        //    Node<Employee>[] nodes;
        //    LinkedList<Employee> list = CreateListWithoutMethods(3, out nodes);
        //    var duplicate = nodes[2]; // this is Employee(3)
        //    list.AddFirst(new Employee(3)); // creates a duplicate 3 at the head
        //    // list is now: 3, 1, 2, 3
        //    var newlyRemovedEmployee = list.Remove(new Employee(3));
        //    // list will now be: 1, 2, 3
        //    ClassicAssert.That(list.Size.Equals(3));
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
        //    ClassicAssert.That(list.Tail.Equals(duplicate));
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}
        //#endregion

        //#region Set(element, oldElement)
        ///// <summary>
        ///// Ensure that calling Set(element, oldElement) on an empty list will result in an exception.
        ///// </summary>
        //[Test]
        //public void SetByElement_on_EmptyList_throws_Exception_test()
        //{
        //    LinkedList<Employee> list = new LinkedList<Employee>();
        //    ClassicAssert.That(() => list.Set(new Employee(2), new Employee(1)), Throws.Exception.TypeOf<ApplicationException>());
        //}

        ///// <summary>
        ///// Ensure that passing element that is not in the list to Set(element, oldElement) results in an exception.
        ///// </summary>
        //[Test]
        //public void SetByElement_no_match_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    ClassicAssert.That(() => list.Set(new Employee(3), new Employee(2)), Throws.Exception.TypeOf<ApplicationException>());
        //}

        ///// <summary>
        ///// Ensure that passing null value to Set(element, oldElement) results in an exception.
        ///// </summary>
        //[Test]
        //public void SetByElement_Null_oldElement_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    ClassicAssert.That(() => list.Set(new Employee(1), null), Throws.Exception.TypeOf<ArgumentNullException>());
        //}

        ///// <summary>
        ///// Ensure that passing null value to Set(element, oldElement) results in an exception.
        ///// </summary>
        //[Test]
        //public void SetByElement_Null_element_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    ClassicAssert.That(() => list.Set(null, new Employee(1)), Throws.Exception.TypeOf<ArgumentNullException>());
        //}

        ///// <summary>
        ///// Test Set(element,oldElement) returns the replaced element.
        ///// </summary>
        //[Test]
        //public void SetByElement_Returns_old_Element_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    Employee returnValue = list.Set(new Employee(2), new Employee(1));
        //    ClassicAssert.That(returnValue.CompareTo(new Employee(1)) == 0); // old value returned
        //}

        ///// <summary>
        ///// Ensure that Set(element, oldElement) sets the element at the correct position 
        ///// Also checks that no changes occured to the size or structure: head/tail/node or their next/previous
        ///// </summary>
        //[Test]
        //public void SetByElement_head_on_list_of_1_updates_element_does_not_change_list_or_size_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    Node<Employee> head = list.Head; // saving a pointer to the old head
        //    list.Set(new Employee(2), new Employee(1));
        //    ClassicAssert.That(head.Element.CompareTo(new Employee(2)) == 0); // node in position 1 is now 2
        //    ClassicAssert.That(list.Head.Equals(head) && list.Tail.Equals(head)); // the head/tail is still the old head node in memory!
        //    ClassicAssert.That(list.Size, Is.EqualTo(1)); // size hasn't changed
        //    // check that pointers are still correct and head/tail has not changed:
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Ensure that Set(element, oldElement) sets the element at the correct position.
        ///// Also ensures structure remains intact. No changes to Tail/Head/Nodes/Next/Previous/Size.
        ///// </summary>
        //[Test]
        //public void SetByElement_tail_on_large_list_updates_only_element_Test()
        //{
        //    int listSize = 10;
        //    Node<Employee>[] nodes;
        //    LinkedList<Employee> list = CreateListWithoutMethods(listSize, out nodes);
        //    var returnedElement = list.Set(new Employee(listSize + 1), new Employee(list.Size));
        //    ClassicAssert.That(returnedElement.CompareTo(new Employee(listSize)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize + 1)) == 0);
        //    for (int i = 1, index = 0; i < listSize; i++, index++)
        //    {
        //        ClassicAssert.That(nodes[index].Element.CompareTo(new Employee(i)) == 0);
        //    }
        //    ClassicAssert.That(list.Size.Equals(listSize));
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Ensure that Set(element, oldElement) sets the element at the correct position.
        ///// Also ensures structure remains intact. No changes to Tail/Head/Nodes/Next/Previous/Size.
        ///// </summary>
        //[Test]
        //public void SetByElement_head_on_large_list_updates_only_element_Test()
        //{
        //    int listSize = 10;
        //    Node<Employee>[] nodes;
        //    LinkedList<Employee> list = CreateListWithoutMethods(listSize, out nodes);
        //    var returnedElement = list.Set(new Employee(listSize + 1), new Employee(1));
        //    ClassicAssert.That(returnedElement.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(listSize + 1)) == 0);
        //    for (int i = 2, index = 1; i <= listSize; i++, index++)
        //    {
        //        ClassicAssert.That(nodes[index].Element.CompareTo(new Employee(i)) == 0);
        //    }
        //    ClassicAssert.That(list.Size.Equals(listSize));
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Ensure that Set(element, oldElement) sets the element at the correct position.
        ///// Also ensures structure remains intact. No changes to Tail/Head/Nodes/Next/Previous/Size.
        ///// </summary>
        //[Test]
        //public void SetByElement_middle_on_large_list_updates_only_element_Test()
        //{
        //    int listSize = 10;
        //    Node<Employee>[] nodes;
        //    LinkedList<Employee> list = CreateListWithoutMethods(listSize, out nodes);
        //    var returnedElement = list.Set(new Employee(listSize + 1), new Employee(list.Size / 2));
        //    ClassicAssert.That(returnedElement.CompareTo(new Employee(list.Size / 2)) == 0);
        //    for (int i = 1, index = 0; i <= listSize; i++, index++)
        //    {
        //        if (i == list.Size / 2)
        //            ClassicAssert.That(nodes[index].Element.CompareTo(new Employee(listSize + 1)) == 0);
        //        else
        //            ClassicAssert.That(nodes[index].Element.CompareTo(new Employee(i)) == 0);
        //    }
        //    ClassicAssert.That(list.Size.Equals(listSize));
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Ensure that calling Set(element,oldElement) with oldElement that matches multiple results
        ///// returns only first result.
        ///// </summary>
        //[Test]
        //public void SetByElement_multiple_matches_sets_first_match_test()
        //{
        //    Node<Employee>[] nodes;
        //    LinkedList<Employee> list = CreateListWithoutMethods(3, out nodes);
        //    var duplicate = nodes[2]; // this is Employee(3)
        //    list.AddFirst(new Employee(3)); // creates a duplicate 3 at the head
        //    // list is now: 3, 1, 2, 3
        //    var oldEmployee = list.Set(new Employee(4), new Employee(3));
        //    // list will now be: 4, 1, 2, 3
        //    ClassicAssert.That(list.Size.Equals(4));
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(4)) == 0);
        //    ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
        //    ClassicAssert.That(list.Tail.Equals(duplicate));
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}
        //#endregion

        //#region Insert()
        ///// <summary>
        ///// Ensure that passing null value to Set(element, oldElement) results in an exception.
        ///// </summary>
        //[Test]
        //public void Insert_Null_element_throws_exception_Test()
        //{
        //    LinkedList<Employee> list = new LinkedList<Employee>();
        //    ClassicAssert.That(() => list.Insert(null), Throws.Exception.TypeOf<ArgumentNullException>());
        //}

        ///// <summary>
        ///// Test that Insert() can insert into an empty list and update the head/tail/size
        ///// </summary>
        //[Test]
        //public void Insert_EmptyList_increases_size_updates_head_and_tail_Test()
        //{
        //    LinkedList<Employee> list = new LinkedList<Employee>();
        //    list.Insert(new Employee(1));
        //    ClassicAssert.That(list.Size.Equals(1));
        //    ClassicAssert.That(list.Tail.Equals(list.Head));
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Edge case; check that Insert() will insert into the head when element is smallest
        ///// </summary>
        //[Test]
        //public void Insert_at_Head_when_element_smallest_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
        //    list.Insert(new Employee(0));// order will be: 0,1,2
        //    ClassicAssert.That(list.Size.Equals(3));
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(0)) == 0);
        //    ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Edge case; check that passing the largest element value to Insert() 
        ///// will insert into the tail position
        ///// </summary>
        //[Test]
        //public void Insert_at_Tail_when_element_largest_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
        //    list.Insert(new Employee(3));// order is now: 1,2,3
        //    ClassicAssert.That(list.Size.Equals(3));
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Test that Insert() adds an element to the list in ascending order (middle) spot
        ///// </summary>
        //[Test]
        //public void Insert_inbetween_head_and_tail_when_value_between_Test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    list.AddLast(new Employee(3));// order is: 1,3
        //    list.Insert(new Employee(2));// order is now: 1,2,3 
        //    ClassicAssert.That(list.Size.Equals(3));
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}
        ///// <summary>
        ///// When duplicate elements exist. The newest element will add before the first match
        ///// </summary>
        //[Test]
        //public void Insert_duplicate_values_in_natural_order_test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(3, out _);
        //    Employee newEmployee = new Employee(3);
        //    list.Insert(newEmployee);// order is: 1, 2, 3(newEmployee), 3
        //    ClassicAssert.That(list.Size.Equals(4));
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.That(list.Tail.Previous.Element.Equals(newEmployee));
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// Insert() can handle inserting when the list is unordered.
        ///// The new element will be placed before the first LARGER element, starting from the head
        ///// </summary>
        //[Test]
        //public void Insert_new_value_in_non_ordered_list_assigns_in_natural_order_test()
        //{
        //    LinkedList<Employee> list = new LinkedList<Employee>();
        //    list.AddLast(new Employee(1));
        //    list.AddLast(new Employee(4));
        //    list.AddLast(new Employee(3));
        //    list.Insert(new Employee(2)); // list will now be: 1,2,4,3
        //    ClassicAssert.That(list.Size.Equals(4));
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.That(list.Tail.Previous.Element.CompareTo(new Employee(4)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
        //    ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        //}
        //#endregion


        //#region SortAscending()
        ///// <summary>
        ///// We run SortAscending() on an empty list, no exceptions should be thrown.
        ///// </summary>
        //[Test]
        //public void SortAscending_on_EmptyList_does_not_throw_exception_test()
        //{
        //    LinkedList<Employee> list = new LinkedList<Employee>();
        //    list.SortAscending();
        //    ClassicAssert.That(list.IsEmpty());
        //    ClassicAssert.That(list.Head, Is.Null);
        //    ClassicAssert.That(list.Tail, Is.Null);
        //}

        ///// <summary>
        ///// We run SortAscending() on a list of 1, no changes should be made.
        ///// </summary>
        //[Test]
        //public void SortAscending_on_list_of_1_does_not_change_anything_test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    list.SortAscending();
        //    ClassicAssert.That(list.Size.Equals(1));
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Head.Equals(list.Tail));
        //    ClassicAssert.That(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// We run SortAscending() on a sorted list, no changes should be made.
        ///// </summary>
        //[Test]
        //public void SortAscending_on_sorted_list_does_not_change_anything_test()
        //{
        //    Node<Employee>[] nodes;
        //    int listSize = 10;
        //    LinkedList<Employee> list = CreateListWithoutMethods(listSize, out nodes);
        //    list.SortAscending();
        //    ClassicAssert.That(list.Size.Equals(listSize));
        //    for (int i = 1, index = 0; i <= listSize; i++, index++)
        //    {
        //        ClassicAssert.That(nodes[index].Element.CompareTo(new Employee(i)) == 0);
        //    }
        //    ClassicAssert.That(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// We run SortAscending() on an unsorted list of 2, should sort the values
        ///// </summary>
        //[Test]
        //public void SortAscending_on_unsorted_list_of_2_sorts_ascending_test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    list.AddFirst(new Employee(2)); // list is: 2, 1
        //    list.SortAscending(); // list should be: 1, 2
        //    ClassicAssert.That(list.Size.Equals(2));
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.That(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// We run SortAscending() on an unsorted list of 3, should sort the values
        ///// </summary>
        //[Test]
        //public void SortAscending_on_Unsorted_list_of_3_sorts_ascending_test()
        //{
        //    LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
        //    list.AddFirst(new Employee(2));
        //    list.AddFirst(new Employee(3)); // 3, 2, 1
        //    list.SortAscending(); // 1, 2, 3
        //    ClassicAssert.That(list.Size.Equals(3));
        //    ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        //    ClassicAssert.That(list.Head.Next.Element.CompareTo(new Employee(2)) == 0);
        //    ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
        //    ClassicAssert.That(CheckIntegrityBetweenAllNodes(list));
        //}

        ///// <summary>
        ///// We run SortAscending() on a large unsorted list, should sort the values
        ///// </summary>
        //[Test]
        //public void SortAscending_on_large_Unsorted_list_sorts_ascending_test()
        //{
        //    Random rnd = new Random();
        //    int listSize = rnd.Next(6000, 10000);
        //    LinkedList<Employee> list = new LinkedList<Employee>();
        //    List<int> randomNumbers = new List<int>();
        //    for (int i = 0; i < listSize; i++)
        //    {
        //        int newNumber = rnd.Next(1, 2140000);
        //        randomNumbers.Add(newNumber);
        //        list.AddLast(new Employee(newNumber));
        //    }

        //    list.SortAscending();
        //    randomNumbers.Sort();

        //    Node<Employee> node = list.Head;
        //    for (int i = 0; i < listSize; i++, node = node.Next)
        //    {
        //        ClassicAssert.That(node.Element.CompareTo(new Employee(randomNumbers[i])) == 0);
        //    }
        //    ClassicAssert.That(CheckIntegrityBetweenAllNodes(list));
        //}


        ///// <summary>
        ///// We run SortAscending() on a large unsorted list with many duplicates, should sort the values
        ///// </summary>
        //[Test]
        //public void SortAscending_on_large_Unsorted_list_containing_many_duplicates_sorts_ascending_test()
        //{
        //    Random rnd = new Random();
        //    int listSize = rnd.Next(100, 1000);
        //    LinkedList<Employee> list = new LinkedList<Employee>();
        //    List<int> randomNumbers = new List<int>();
        //    for (int i = 0; i < listSize; i++)
        //    {
        //        int newNumber = rnd.Next(1, 10); // randomly assign 1 to 10 to each employee ID
        //        randomNumbers.Add(newNumber);
        //        list.AddLast(new Employee(newNumber));
        //    }

        //    list.SortAscending();
        //    randomNumbers.Sort();

        //    Node<Employee> node = list.Head;
        //    for (int i = 0; i < listSize; i++, node = node.Next)
        //    {
        //        ClassicAssert.That(node.Element.CompareTo(new Employee(randomNumbers[i])) == 0);
        //    }
        //    ClassicAssert.That(CheckIntegrityBetweenAllNodes(list));
        //}
        //#endregion

        //#endregion

        /* HELPER METHODS */
        /// <summary>
        /// Ensures: 
        /// Head points previous to null
        /// Tail points next to null
        /// The head is in the first spot
        /// The tail is in the last spot
        /// Each inner node (not head/tail) is mutually pointing at it's neighbours on previous/next.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private bool CheckIntegrityBetweenAllNodes(LinkedList<Employee> list)
        {
            bool isValid = true;
            Node<Employee>[] array = ConvertToNodeArray(list);

            isValid &= array[0] == list.Head;
            isValid &= array[0].Previous == null;

            isValid &= array[list.Size - 1] == list.Tail;
            isValid &= array[array.Length - 1].Next == null;

            for (int i = 1; i <= array.Length - 2 && isValid; i++)
            {
                isValid &= CheckInnerNodeIntegrity(array[i]);
            }

            return isValid;
        }

        /// <summary>
        /// Ensures a node points previous/next to valid nodes (not null)
        /// Ensure the neighbouring nodes (before/after) also point back to the original node.
        /// </summary>
        /// <param name="node">the node to validate (must not be head/tail)</param>
        /// <returns>true if valid</returns>
        private bool CheckInnerNodeIntegrity(Node<Employee> node)
        {
            Node<Employee> before = node.Previous;
            Node<Employee> after = node.Next;

            return before.Next == node && after.Previous == node;
        }

        /// <summary>
        /// For testing purposes, make an array out of the LinkedList
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private Node<Employee>[] ConvertToNodeArray(LinkedList<Employee> list)
        {
            Node<Employee>[] array = new Node<Employee>[list.Size];
            int index = 0;
            int count = 0;

            for (Node<Employee> node = list.Head; node != null; node = node.Next, index++)
            {
                array[index] = node;
                count++;
            }

            if (count != list.Size) throw new Exception("Your LinkedList is broken. The number of nodes does not equal the size of your linkedlist");

            return array;
        }

        /// <summary>
        /// Creates a list without using any of the methods in the LinkedList class.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="nodeArray"></param>
        /// <returns></returns>
        private LinkedList<Employee> CreateListWithoutMethods(int size, out Node<Employee>[] nodeArray)
        {
            Node<Employee> beforeNode = null, node = null;

            LinkedList<Employee> list = new LinkedList<Employee>();
            nodeArray = new Node<Employee>[size];

            for (int i = 1, index = 0; i <= size; i++, index++)
            {
                node = new Node<Employee>(new Employee(i));
                nodeArray[index] = node;

                if (beforeNode != null)
                {
                    beforeNode.Next = node;
                    node.Previous = beforeNode;
                }

                if (i == 1) list.Head = node;
                if (i == size) list.Tail = node;
                list.Size++;
                beforeNode = node;
            }

            return list;
        }
    }
}