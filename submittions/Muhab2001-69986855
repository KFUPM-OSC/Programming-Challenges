class BishopSolver {
  /**
   * medium mode with dynamio coordinates boundaries
   * we will extend all diagonals for both placements
   * case 1: if there is no intersection between the two diagonals, not possible
   * case 2: there is an intersection and the 2 placements do not appear as an intersection, 2 moves
   * case 3: an intersection with one of the 2 placements in the intersection, 1 move
   */

  static List<String> lettersBoundary = [];
  static List<int> numbersBoundary = [];

  // utility to generate the boundary
  static intializeBoundary(int n, int m) {
    for (int i = 1; i <= n; i++) {
      numbersBoundary.add(i);
    }
    var letter = "a";
    for (int i = 0; i < n; i++) {
      lettersBoundary.add(shiftLetter(letter, i));
    }
  }

  // pathfinder function
  static List<String> getBishopPath(int n, int m, String start, String dest) {
    intializeBoundary(n, m);

    var startLetter = start[0];
    var startNumber = int.parse(start.substring(1));

    var endLetter = dest[0];
    var endNumber = int.parse(dest.substring(1));

    // generate diagonals
    var startDiagonals =
        generateDiagonals(startLetter, startNumber).union({start});
    var destDiagonals = generateDiagonals(endLetter, endNumber).union({dest});
    // find intersection
    final commonElements = startDiagonals.intersection(destDiagonals);

    // case #1
    if (commonElements.isEmpty) {
      return []; // cannot be done
    }

    // case #3: we check for the starting placements presence in intersection
    if (commonElements.contains(start)) {
      return [start, dest];
    }

    // case #2
    // sometimes we can have 2 paths, select the first option
    return [start, commonElements.first, dest];
  }

  // finding all diagonal positions for a specified position
  static Set<String> generateDiagonals(
      String letterCoordinate, int numberCoordinate) {
    List<String> result = [];

    var letter = letterCoordinate;
    var num = numberCoordinate;
    // top right diagonal
    while (true) {
      if (lettersBoundary.contains(shiftLetter(letter, 1)) &&
          numbersBoundary.contains(num + 1)) {
        result.add('${shiftLetter(letter, 1)}${num + 1}');
      } else {
        break;
      }

      letter = shiftLetter(letter, 1);
      num += 1;
    }

    letter = letterCoordinate;
    num = numberCoordinate;
    // top left diagonal
    while (true) {
      if (lettersBoundary.contains(shiftLetter(letter, -1)) &&
          numbersBoundary.contains(num + 1)) {
        result.add('${shiftLetter(letter, -1)}${num + 1}');
      } else {
        break;
      }
      letter = shiftLetter(letter, -1);
      num += 1;
    }

    letter = letterCoordinate;
    num = numberCoordinate;
    // bottom left diagonal
    while (true) {
      if (lettersBoundary.contains(shiftLetter(letter, -1)) &&
          numbersBoundary.contains(num - 1)) {
        result.add('${shiftLetter(letter, -1)}${num - 1}');
      } else {
        break;
      }

      letter = shiftLetter(letter, -1);
      num -= 1;
    }

    letter = letterCoordinate;
    num = numberCoordinate;
    // bottom right diagonal
    while (true) {
      if (lettersBoundary.contains(shiftLetter(letter, 1)) &&
          numbersBoundary.contains(num - 1)) {
        result.add('${shiftLetter(letter, 1)}${num - 1}');
      } else {
        break;
      }

      letter = shiftLetter(letter, 1);
      num -= 1;
    }

    return result.toSet();
  }

  // utility to shift letter unicode
  static shiftLetter(String letter, int num) {
    return String.fromCharCode(letter.codeUnitAt(0) + num);
  }
}
// runner 
void main(List<String> args) {
  print(BishopSolver.getBishopPath(18, 18, "a1", "i9").toString());
}
