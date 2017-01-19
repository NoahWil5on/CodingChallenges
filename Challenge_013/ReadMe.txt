For challenge_013 I attempted to see if one string was simply a rotation of another string by calling a method bool IsSubstring() only once.

ex.)

input: 	"waterbottle"
	"erbottlewat"

output: true

To begin with I wasn't able to figure out how I would accomplish this by only calling the method once, I was looking at it from the wrong angle. Essentially what I needed to do was find the division between the orignal string and the rotated string. What I mean is this:

x = wat
y = erbottle

x + y = waterbottle (string 1)
y + x = erbottlewat (string 2)

This much I knew, but how to find where that division was I was unsure of. It turns out I didn't necessarily need to know where that division was at all; if you take the first string (without even having to divide it) you will automatically have a version of x + y. If you then continue to add the string to itself you will have x + y + x + y or described even better: x + (y + x) + y. So by adding the string to itself you can simplycheck if string 2 (y + x) is a sub string of string 1 + string 1 (x + y + x + y). 

This is the most optimal solution and will give us a runtime of O(n)

Because the code to do this problem was so short (although difficult to come up with) I decided to also write the method bool IsSubstring() which was also quite short but good exersize. This method is actually responsible for the runtime of O(n).

-Noah Wilson
