Challenge_008 had me take a string and decide whether it had a permutation that was a palindrome or not (a string that is the same forward as it is backwards). This is excluding any non-alphabetical characters

ex.)
input: "Taco cat"
output: true (catotac)

input: "Noah was here"
output: false

My initial approach was to sort the string which then (for the first example) would give me something along the lines of "AACCOTT", Then cycle through the string and check to make sure that no more than one character was left without a partner. If only one character is left without a partner (in this case it is O) then that is okay becuase it will just always be the center character o the palindrome. However, in the case that there is more than one the string cannot be a palindrome. Again my method was very short and worked like a charm, but it was a little slow. Because of the sort it had a time complexity of O(nlog(n)) which isn't horrible but it could be better.

After looking at the books hints I discovered that I could be using a hashtable (duh) So I implemented a solution very similar to what the book had. This brought the time back down to O(n) by simply going through string without sorting it, and adding up all the numbers of each character I find and placing that number in the hashtable. In the end I just go back through the hashtable and make sure there are no more than one slots with an odd amount of characters.

There is an even more optimal solution that I  wasn't able to implement without the books help. that is using a bitmap to count the number of each type of character. When you consider that it doesn't matter how many characters you find, it just ( for the most part) needs to be an even amount, we can consider that everytime we look at a new character, we just switch on/off that bit in the bitmap. 0 would represent that we have either never found that character or we have found it an even amount of times. On the flip side 1 would indicate that we have found that character an odd amount of times. So, a bit vector that either is all 0's (equal to 0) or only contains one 1 ((bitVector & (bitVector -1)) == 0) would then by definition be considered a palindrome

This solution has the same time complexity, O(n) as the solution prior, however it has a greatly reduced space complexity.

-Noah Wilson