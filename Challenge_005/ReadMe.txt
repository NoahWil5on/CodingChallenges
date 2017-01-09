This challenge was from the book "Cracking the Coding Interview". My attempt to solve the challenge was a verbose solution of a solution the book had. 

The solution's time complexity was O(n) (arguably O(1) assuming a finite character set) and space complexity was O(1)

or

time complexity O(min(c,n)) space complexity O(c) where c is the size of the character set.

By using a bit vector we can reduce the space complexity by eight time which was the absolute optimal solution provided by the book. My solution was slightly less optimal but still fell under acceptable solutions according to the book.