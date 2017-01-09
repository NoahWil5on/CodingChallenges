This challenge had me take an input in RPN (Reverse Polish Notation) and output the result. This was fairly simple so I decided to make it more complicated by having the program also output the RPN in standard notation.

ex.) 

input: 8 2 4 ^ + 6 /

would be evaluated as:

8
8 2
8 2 4
8 2 ^ 4 -> 3 16
8 16
8 + 16 -> 24
24 6 
24 / 6 -> 4

output: 4

With the inclusion of converting RPN to standard notation the output would actually be:

ouput: ((8+(2^4))/6)=4