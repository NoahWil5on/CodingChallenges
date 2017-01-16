Challenge_011 left me looking pretty stupid. The idea was to take a square matrix and rotate it 90 degrees.

The first thing I did was create a quick little program so that a user could enter in their own matrix of desired length and then created a function so it would be printed out whenever so we could actually see if we were rotating it correctly. This was no problem.

The actual task is where I started to stumble a little.

I wrote a program that ran in O(n^2) where n is the length of any given row/column of the square matrix and it had a space complexity of O(n^2) where again, n is the row/column length of the matrix. My time complexity was fine, that was actually optimal. However the space complexity was much greater than necessary. What could have been O(1) was O(n^2).

My solution was to copy the matrix (which was my mistake) into a temporary matrix and simply cycle through the matrix and set any position [x,y] to [y,length-1-x]. This resulted in a very short elegant solution which rotated the matrix quickly and effectively. However there was a better solution.

The better solution was actually what I tried to do on my first approach but after getting stumped I moved to the solution who's space complexity was greater. This solution was to go layer by layer (in the sense that both columns or rows could be considered layers) and move the top layer to the right layer, the right to bottom, bottom to left, and left back to top, effectively rotating the matrix. This could be done by entire layers at a time (with space complexity O(n) time complexity O(n^2)) or by single slots at a time (space complexity O(1) time complexity O(n^2)).

While I was a little more pressed for time today, and my computer kept freezing up :( I could have taken a better approach to find the solution by solving it more systematically (I forwent a pen and paper solution for the sake of time). Still my solution would at least not appear any less optimal for a front end user. 

-Noah Wilson