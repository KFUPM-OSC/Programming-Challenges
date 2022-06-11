# Challenge #1 - Bishop

In chess, the ***Bishop*** can only move diagonally. The Bishop can move as many squares as wanted in any diagonal in one step (assuming no other chess pieces are on the board). It is also known that it may never move to a different color other than the one it starts on. You are given two coordinates on a chess-field and should determine, if a bishop can reach the one field from the other and the path that it will take. Coordinates in chess are given by a letter and a number that specifies the column and row respectively.

### Easy Level

For a regular chessboard of size 8×8. The columns are labelled (’A’ to ’H’) and rows are numbered 1 to 8.
> **Input:** *start* = "F1", *dest* = "E8"\
> **Output:** ["F1", "B5", "E8"]\
> **Explanation:** The Bishop will move from F1 to B5 then to E8.

```Javascript
/**
 * @param {String} start - The starting coordinate of the Bishop piece.
 * @param {String} dest - The destination coordinate of the Bishop piece.
 * @return {String[]} path - If possible, a valid path that Bishop piece can take in order to reach the destination coordinate.
 */
public String[] getBishopPath (String start, String dest) {

  /* Your code here */
  
}
```

### Medium Level

For any arbitrary chessboard of size n×m, where n ≤ 26 and m ≤ 26.

> **Input:** *n* = 16, *m* = 14, *start* = "F1", *dest* = "K14"\
> **Output:** ["F1", "B5", "K14"]\
> **Explanation:** The Bishop will move from F1 to B5 then to K14.

```Javascript
/**
 * @param {Integer} n - The  number of columns of the chessboard.
 * @param {Integer} m - The number of rows of the chessboard.
 * @param {String} start - The starting coordinate of the Bishop piece.
 * @param {String} dest - The destination coordinate of the Bishop piece.
 * @return {String[]} path - If possible, a valid path that Bishop piece can take in order to reach the destination coordinate.
 */
public String[] getBishopPath (Integer n, Integer m, String start, String dest) {

  /* Your code here */
  
}
```

### Hard Level

For any arbitrary chessboard of size n×m, where n ≤ 26 and m ≤ 26. and a pawn piece (that acts as an obstacle).

> **Input:** *n* = 16, *m* = 14, *start* = "I12", *dest* = "K14", *obstacle* = "J13"\
> **Output:** ["I12", "J11", "L13", "K14"]\
> **Explanation:** The Bishop cannot got from I12 to K14 directly (since there is an obstacle in the middle). So, it will have to go to J11 then to L13 in order to reach K14.

```Javascript
/**
 * @param {Integer} n - The  number of columns of the chessboard.
 * @param {Integer} m - The number of rows of the chessboard.
 * @param {String} start - The starting coordinate of the Bishop piece.
 * @param {String} dest - The destination coordinate of the Bishop piece.
 * @param {String} obstacle - The coordinate of an obstacle.
 * @return {String[]} path - If possible, a valid path that Bishop piece can take in order to reach the destination coordinate.
 */
public String[] getBishopPath (Integer n, Integer m, String start, String dest, String obstacle) {

  /* Your code here */
  
}
```

## How to submit your solution

We will be using GitHub for submitting Challenges solutions, to submit a new solution:

1. Go to [https://kfu.pm/challenge/01-bishop](https://kfu.pm/challenge/01-bishop).
2. Login using your github account.
3. Write your solution using any programming language (Pseudo-code is accepted).
4. Commit your solution.
5. Have fun 😊.


###### GOOD LUCK AND HAPPY CODING!
