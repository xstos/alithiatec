Hi Ned,

I was intrigued by your question yesterday so i whipped up a simple brute force solution for it this morning. I'm testing it now and i'll send u the code for it once i see it works.

I basically created a long array of 100K elements and filled each element with index+1 representing the matrix columns (first row)

i then looped through the rows from 1-100K cloning (memcpy) the original array and doing the multiplication of each array element and dumping the results to disk as bytes. The file in the end was 78GB and took about 10min to output.

I then iterated over the file in 100 passes and binned the numbers in fixed-width ranges
so the first bin array would contain the histogram of numbers between 1-100000000
and the next for numbers 100000001-200000000
etc...
to 9900000001-100^2

Right now it think it's doubling the counts because im not doing the upper triangle only... Each pass through the 78 gig file (took 5min) to compute the histogram doesn't take very long either since the byte buffers are read in big blocks.