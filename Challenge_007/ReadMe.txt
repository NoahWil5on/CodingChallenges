This challenge had me take a string and replace all of its spaces with "%20"

ex)
input:  "Mr John Smith    "
output: "Mr%20John%20Smith"

My first approach was to simply split the string using its spaces and then use a string builder to put the string back together with a %20 between each string in the string array. 

However, after reading the hints in the book I got the impression that the book was looking for something more along the lines of a solution containing a char array. My solution was to copy the string to a char array, loop through the char array and compare it's chars to the chars in the string and then replace the chars characters with %, 2%, 0, (with a buffer for how many spaces it had encountered) which looked similar to what is shown below

	if (s[i] == ' ')
                {
                    c[i + spaces * 2] = '%';
                    c[i + 1 + spaces * 2] = '2';
                    c[i + 2 + spaces * 2] = '0';
                    spaces++;
                }

The book had a similar solution however, I feel the book's solution was a little verbose although they tried to simplify it by iterating through the string backwards. This is good practice as it prevents you from having to keep track of how many spaces you have encountered and try to counteract that as I did with statements like c[i + spaces*2] but in the end the books solution still managed to account for that. Just they had to account for it outside the for loop.

Both have the same time and space complexity and my solution is a little shorter so I decided to stick with mine :)