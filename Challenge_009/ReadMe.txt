For Challenge_009 I took 2 strings and checked if they were 1 (or 0) edit away from being the same string. This is considering an edit to be an insert, removal or replacement of a character to one or both strings.

ex.)
input: 	pale
	ple
output: true

input:	pale
	pales
output: true

input:	pale
	bale
output:	true

input:	pale
	bake
output: false

My approach would take 0(n) time and have the same space complexity as the books solution, however our approaches greatly differed. I noticed that in the case of an insert/removal of a character, there should only be one difference between the characters. So using a bitVector I could simply toggle on and off the position of each character I found in string 1, and then use that same bitVector and toggle on and off each character I found in string 2. Then I could simply check if the bitVectors differed by one bit and return true or false.

In the case that the strings are the same length (perhaps a character had been replaced) I could use the same exact method but instead check for 2 or 0 differences; 2 being a replacement, 0 being the exact same string. This was a fairly straight forward approach, and I was able to implement almost immediatly after writing it down with pen and paper.


The book's approach was slightly more, I thought, verbose. The book checked for each case seperatley, and then eventually attempted to check for each case all at once, which became a little more messy and hard to follow. They did so by first considering an insertion and removal of a character the same thing. You could then simply loop through the 2 and check to make sure that (after the misshap of missing character) all character matched perfectly. Similarly, with the case of the replacement of a character, you could just loop through the 2 strings and check to make sure no more than one character was different.

The books solution was very straight forward and made sense. Either solution is works just as well, Maybe the books was easier for someone new to the program to understand. In the end I decided to stick with mine as it worked just as well; I also didn't feel compelled to try and implement the books approach as it was so simple.

-Noah Wilson

Epilogue:

Scratch everything, My program worked perfectly when running against the tests in the book, but when I tried to implement it in another program, I quickly realized that it failed to realize when words were out of order, or a word (that was all but completely different) contained duplicate letters that would cancel themselves out and leave me thinking the two words were close to identical. My program has now been altered to refelct the book's solution.