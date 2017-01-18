Challenge_012 had me take a matrix, search through it for zeros, and then turn the respective row and column to zeros.

ex.) 
input:	17893
	08931
	84904
	48923

output:	07803
	00000
	00000
	08903

My solution took O(M*N) to search through the matrix where M is the width and N is the height (there is no faster way to do this) and then add the x,y coordinates of any 0's to a list for later use. Once my program knew where the 0's were it would simply change every instance in its respective column and row into a 0. This worked simply as for(i < columns){matrix[x,i] = 0} and vise versa for rows. which made the total time complexity something similar to O(M*N + C(M + N)) where C is the number of points found in the matrix. Time wise, this was arguably as optimal as you could get(although it's not always as you'll see later).

The solution's Space complexity, however, had a lot more variance. By using a list I was sometimes using more space than was necessary and sometimes less, depending on where the points were, how many points there were, and how large the matrix was. This is obviously not always the best. 

This is where the book's solution, which used a space complexity of O(1), came in handy. Instead of using some other data structure to hold all the data points, you could simply use the outer row and outer column to hold the information of what rows and columns need to be switched. You're able to do this because the solution we're making doesn't need to know where in the row/column the 0 is, it just needs to know what row and columns need to be all zeros. So my example input from before would go through this process and come out looking something like this:

	07803
	08931
	04904
	48923

You can see now that all you would need to do is loop through the first row and first column and the program will quickly see which rows columns need to be zeroed. Now the time complexity is O(M*N + C1*M + C2*N) where C is the total number of 0's added up from the first row/column rather than the total number of points in the whole system. Where my solution may be just as (if not super super close to) as optimal as this solution in an example where say it's a 1000x1000 matrix with just a couple of 0's in the entire thing. On the other hand, my solution would be far inferior when considering a 1000x1000 matrix with 10s of thousands of 0's in it.

*****
On a side note this was all completed before the start of January 1/18/17 (where my goal/new years resolution is to code and post something to github every day for the next year). Unfortanetley our internet provider sucks, so the internet for anyone using fronteir in western NY was down today resulting in me not only being unable to post from my house, but anyone else's house around me, so I couldn't just pop over to the neighbors. While this very much frustrates me I will try and not let it get in my way of completing the rest of the year by viewing this as some sort of failure.

I will also be trying to set the clock on my laptop back a couple of hours tomorrow morning and hopefully github will still count it as yesterdays work fingers crossed.
*****