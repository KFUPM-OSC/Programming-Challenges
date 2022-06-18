import 'dart:math';

// last 4 elements are for alignment detection only
enum Direction {
  TOP_RIGHT,
  TOP_LEFT,
  BOTTOM_RIGHT,
  BOTTOM_LEFT,
  TOP,
  BOTTOM,
  RIGHT,
  LEFT
}

class BishopSolver {
  /**
   * medium mode with dynamic coordinates boundaries
   * repatedly check for a 2-move finishing move, if not
   * make the largest possible leap in the direction of the destination
   */

  static List<int> coulmns = [];
  static List<int> rows = [];
  // map to define coordinate shift direction for each move on an xy plane
  static final Map<Direction, List<int>> shifter = {
    Direction.BOTTOM_LEFT: [-1, -1],
    Direction.BOTTOM_RIGHT: [1, -1],
    Direction.TOP_RIGHT: [1, 1],
    Direction.TOP_LEFT: [-1, 1],
  };

  // pathfinder function
  static List<String> getBishopPath(int n, int m, String start, String dest) {
    if (start == dest) {
      return [start];
    }
    if (n == 1 || m == 1) {
      return [];
    }

    int maxDimension = max(n, m);

    var startColumn = (start[0].toUpperCase().codeUnitAt(0) - 64);
    var startRow = int.parse(start.substring(1));

    var destColumn = dest[0].toUpperCase().codeUnitAt(0) - 64;
    var destRow = int.parse(dest.substring(1));

    if (!inBoundary(startColumn.toDouble(), startRow.toDouble(), n, m) ||
        !inBoundary(destColumn.toDouble(), destRow.toDouble(), n, m)) {
      return [];
    }

    // check if it is possible to reach the target on a square boundary before moving
    // (different colors can never be reached)

    var check = isDone(
        startColumn, startRow, destColumn, destRow, maxDimension, maxDimension);

    if (check.isEmpty) {
      return []; // different colors
    }
    // if n != m check if it is possible to reach after reducing to actual boundary in 1 or 2 moves
    var result = [
      [startColumn, startRow]
    ];
    var shiftedLocation;
    var direction;
    check = isDone(startColumn, startRow, destColumn, destRow, n, m);
    // looping by leaping in diagonals till you reach a 2-move finisher
    while (check.isEmpty) {
      direction = getDirection(destColumn - startColumn, destRow - startRow);
      if (direction.length == 1) {
        shiftedLocation =
            generateDiagonal(startColumn, startRow, direction[0], n, m).last;
      } else {
        var diagonal1 =
            generateDiagonal(startColumn, startRow, direction[0], n, m);
        var diagonal2 =
            generateDiagonal(startColumn, startRow, direction[1], n, m);
        // chosing the largest leap for aligned positions
        shiftedLocation =
            max(diagonal1.length, diagonal2.length) == diagonal1.length
                ? diagonal1.last
                : diagonal2.last;
      }
      startColumn = shiftedLocation[0];
      startRow = shiftedLocation[1];
      result.add(shiftedLocation);
      check = isDone(startColumn, startRow, destColumn, destRow, n, m);
    }
    // add the final destination coordinate
    check.removeAt(0);
    result.addAll(check);
    return result
        .map((e) => '${String.fromCharCode(e[0] + 64)}${e[1]}')
        .toList();
  }

  static List<List<int>> isDone(
      int startCol, int startRow, int destCol, int destRow, int n, int m) {
    // calculating differnece for relative location of both tiles
    int colDiff = startCol - destCol;
    int rowDiff = startRow - destRow;
    // works only for 1 move - finish
    if (rowDiff / colDiff == 1 || rowDiff / colDiff == -1) {
      return [
        [startCol, startRow],
        [destCol, destRow]
      ];
    }

    var middle_row = (startRow - startCol + destCol + destRow) / 2;

    var middle_col = max(startRow - startCol, destCol + destRow) - middle_row;

    if (inBoundary(middle_col, middle_row, n, m)) {
      return [
        [startCol, startRow],
        [middle_col.toInt(), middle_row.toInt()],
        [destCol, destRow]
      ];
    }

    middle_row = (destRow - destCol + startCol + startRow) / 2;
    middle_col = max(destRow - destCol, startCol + startRow) - middle_row;

    if (inBoundary(middle_col, middle_row, n, m)) {
      return [
        [startCol, startRow],
        [middle_col.toInt(), middle_row.toInt()],
        [destCol, destRow]
      ];
    }

    return [];
  }

  static bool inBoundary(double col, double row, int n, int m) {
    return (col > 0 && col <= m) &&
        (row > 0 && row <= n) &&
        (col.floor() == col) &&
        (row.floor() == row);
  }

  static List<Direction> getDirection(int collDifference, int rowDifference) {
    if (collDifference > 0) {
      if (rowDifference > 0) {
        return [Direction.TOP_RIGHT];
      } else if (rowDifference < 0) {
        return [Direction.BOTTOM_RIGHT];
      } else {
        return [Direction.TOP_RIGHT, Direction.BOTTOM_RIGHT];
      }
    } else if (collDifference < 0) {
      if (rowDifference > 0) {
        return [Direction.TOP_LEFT];
      } else if (rowDifference < 0) {
        return [Direction.BOTTOM_LEFT];
      } else {
        return [Direction.TOP_LEFT, Direction.BOTTOM_LEFT];
      }
    } else {
      if (rowDifference > 0) {
        return [Direction.TOP_RIGHT, Direction.TOP_LEFT];
      } else {
        return [Direction.BOTTOM_RIGHT, Direction.BOTTOM_LEFT];
        // impossible for both diffs to be zero at this point
      }
    }
  }

  // finding all diagonal positions for a specified position
  static List<List<int>> generateDiagonal(int columnCoordinate,
      int rowCoordinate, Direction direction, int n, int m) {
    List<List<int>> path = []; // used to choose the largest leap
    var col = columnCoordinate;
    var row = rowCoordinate;
    // a diagonal that is within the boundaries
    while (true) {
      if ((col + shifter[direction]![0]) <= m &&
          (col + shifter[direction]![0]) > 0 &&
          (row + shifter[direction]![1]) <= n &&
          row + shifter[direction]![1] > 0) {
        path.add([col + shifter[direction]![0], row + shifter[direction]![1]]);
      } else {
        return path;
      }
      col += shifter[direction]![0];
      row += shifter[direction]![1];
    }
  }
}

// runner
void main(List<String> args) {
  print(BishopSolver.getBishopPath(1, 26, "a1", "g1"));
}
