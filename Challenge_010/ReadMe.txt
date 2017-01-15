Challenge_010 had me take a string and "compress" it, then return compressedString < original ? compressedString : original.

ex.)
input: 	How are you?
output:	How are you?

input:	aabcccccaaa
output:	a2b1c5a3

My approach differed a little more than expected from the books. The biggest reason being that I came under the impression (based on the books instructions and the fact that there is no one I can ask without looking at the solution first) that I had to check if the each character was an alphabetical character or not. This resulted in me doing a quick while loop before my main for loop and creating another method called IsCharacter.

In the end they both essentially have the same runtime, I just wish I had know not to do the extra bit so I could better evaluate my code against the books. Essentially all I did was record the current character I was "counting up" and then check to see if the next character was equal to it, if not, then I would reset my counting total, change the character I was looking at, and append my character and count to a string builder. This took O(n) time.

-Noah Wilson