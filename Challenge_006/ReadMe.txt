This challenge (challenge 1.2 from "Cracking the Coding Interview") had me test two strings against eachother to decide whether they were permutations of one another.

for example:

input: 	"mom"
	"omm"
out:	Permutation

input: 	"mom"
	"oom"
output: Not Permutation

My intstinct "brute force" idea was to put all the characters of one string into a list. Then, run back through by comparing each character in the other string to the list and remove the character from the list if the two had the character in common. In the end, if the list of characters reached zero before looking at all the characters in the second string, or there were characters remaining in the list after looking through all the characters in the second string then the two strings would not be permutations of eachother.

This would work but would be O(n^2) and pretty verbose. So I knew I needed a better solution.

I quickly came up with the next idea, making 2 hashtable with length 128 (for ASCII characters) and then cycling through each character in each string and looking at their hashcode. Then adding 1 to each respective hashcode slot for each respective string's hashtable. Finally, I could loop through The tables and check to make sure their values are equal to eachother. 

This would take O(2n), arguable O(n + 1) time complexity because the size of the hashtables is set. Both reduce to a time complexity of O(n).

That solution was similar to the books. However, the book only had you make one hashtable. For one string you would add 1 to each character's hashcode spot in the hashtable. For the other string you would subtract 1. If you ever have a negative value then you know the two strings are not permutations of eachother.

This has the same time complexity as my solution but has half the space complexity because you're only using one hashtable.

The other one of the books solutions (which I was able to recreate by reading the hints rather than the solution) had you sort both strings and then simply compare to make sure both strings are equal to eachother. This is great in the sense that is a very simple solution to arrive at, however its time complexity is O(n*log(n)) which is worse than the other solutions. I do believe however that its space complexity is less than either of the solutions.

For each solutions you would first check if the string one's length is equal to string 2's length. In the case that they are not equal, you can return early and not have to perform the rest of the method. In any case of unequal string length the time complexity would be O(1) and the space comlexity would be O(1) as well.

-Noah

