Challenge_014 marks the start of chapter 2, linked lists. The challenge had me take an unordered linked list and remove any duplicate values.

ex.)
input: 	1,2,3,4,4,4,4,5,6

ouput:	1,2,3,4,5,6

My solution simply added all the values in the linked list to a hashet, cleared the list, and then added the values back, the hashset acted as a buffer because it will only hold one of each value, so any duplicates will automatically be discarded. The result is a linked list with no duplicates in O(n) time using O(n) space.

The books solution was very similar. However they did have another solution that went around using a buffer which brought down the space complexity to O(1) however brought up the time ot O(1).

Pretty basic solution for today but sometimes time for more complicated challenges is hard to find.

-Noah Wilson