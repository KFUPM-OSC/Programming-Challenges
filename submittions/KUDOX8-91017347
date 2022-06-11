import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        String start = "";
        String dest = "";
        String editedStart = "";
        String editedDest = "";
        Scanner kb = new Scanner(System.in);
        start = editedStart = kb.nextLine().toUpperCase();
        dest = editedDest = kb.nextLine().toUpperCase();
        if (start.equals(dest)) {
            System.out.println("[\"" + start + "\"]");
            System.exit(0);
        }
        editedStart = editedStart.replace('A', '1');
        editedStart = editedStart.replace('B', '2');
        editedStart = editedStart.replace('C', '3');
        editedStart = editedStart.replace('D', '4');
        editedStart = editedStart.replace('E', '5');
        editedStart = editedStart.replace('F', '6');
        editedStart = editedStart.replace('G', '7');
        editedStart = editedStart.replace('H', '8');
        editedDest = editedDest.replace('A', '1');
        editedDest = editedDest.replace('B', '2');
        editedDest = editedDest.replace('C', '3');
        editedDest = editedDest.replace('D', '4');
        editedDest = editedDest.replace('E', '5');
        editedDest = editedDest.replace('F', '6');
        editedDest = editedDest.replace('G', '7');
        editedDest = editedDest.replace('H', '8');

        int startCol = Integer.parseInt(editedStart.charAt(0) + "");
        int startRow = Integer.parseInt(editedStart.charAt(1) + "");
        int destCol = Integer.parseInt(editedDest.charAt(0) + "");
        int destRow = Integer.parseInt(editedDest.charAt(1) + "");
        List<Integer> startAlter = new ArrayList<>();
        List<Integer> destAlter = new ArrayList<>();

        // Top Right Diagonal

        while (startCol != 9 && startRow != 9) {
            startAlter.add(startCol * 10 + startRow);
            startCol++;
            startRow++;

        }

        // Top Left Diagonal
        startCol = Integer.parseInt(editedStart.charAt(0) + "") - 1;
        startRow = Integer.parseInt(editedStart.charAt(1) + "") + 1;

        while (startCol != 0 && startRow != 0) {
            startAlter.add(startCol * 10 + startRow);
            startCol--;
            startRow++;

        }

        // Bottom Right Diagonal
        startCol = Integer.parseInt(editedStart.charAt(0) + "") + 1;
        startRow = Integer.parseInt(editedStart.charAt(1) + "") - 1;

        while (startCol != 0 && startRow != 0) {
            startAlter.add(startCol * 10 + startRow);
            startCol++;
            startRow--;

        }

        // Bottom Left Diagonal
        startCol = Integer.parseInt(editedStart.charAt(0) + "") - 1;
        startRow = Integer.parseInt(editedStart.charAt(1) + "") - 1;

        while (startCol != 0 && startRow != 0) {
            startAlter.add(startCol * 10 + startRow);
            startCol--;
            startRow--;

        }

        if (startAlter.contains(destCol * 10 + destRow)) {
            System.out.println("[\"" + start + ",\"" + dest + "\"]");
            System.exit(0);
        }
        ;

        //////////////////////////////////////////////////

        // Top Right Diagonal
        while (destCol != 9 && destRow != 9) {
            destAlter.add(destCol * 10 + destRow);
            destCol++;
            destRow++;

        }

        // Top Left Diagonal
        destCol = Integer.parseInt(editedDest.charAt(0) + "") - 1;
        destRow = Integer.parseInt(editedDest.charAt(1) + "") + 1;

        while (destCol != 0 && destRow != 0) {
            destAlter.add(destCol * 10 + destRow);
            destCol--;
            destRow++;

        }

        // Bottom Right Diagonal
        destCol = Integer.parseInt(editedDest.charAt(0) + "") + 1;
        destRow = Integer.parseInt(editedDest.charAt(1) + "") - 1;

        while (destCol != 0 && destRow != 0) {
            destAlter.add(destCol * 10 + destRow);
            destCol++;
            destRow--;

        }

        // Bottom Left Digonal
        destCol = Integer.parseInt(editedDest.charAt(0) + "") - 1;
        destRow = Integer.parseInt(editedDest.charAt(1) + "") - 1;

        while (destCol != 0 && destRow != 0) {
            destAlter.add(destCol * 10 + destRow);
            destCol--;
            destRow--;

        }

        String midle;
        for (int cordinate : destAlter) {
            if (startAlter.contains(cordinate)) {
                midle = String.valueOf(cordinate);
                switch (midle.charAt(0)) {
                    case '1':
                        midle = midle.replaceFirst("1", "A");
                        break;
                    case '2':
                        midle = midle.replaceFirst("2", "B");
                        break;

                    case '3':
                        midle = midle.replaceFirst("3", "C");
                        break;
                    case '4':
                        midle = midle.replaceFirst("4", "D");
                        break;

                    case '5':
                        midle = midle.replaceFirst("5", "E");
                        break;

                    case '6':
                        midle = midle.replaceFirst("6", "F");
                        break;
                    case '7':
                        midle = midle.replaceFirst("7", "G");
                        break;
                    case '8':
                        midle = midle.replaceFirst("8", "H");
                        break;
                    default:
                        break;
                }
                System.out.println("[\"" + start + "\",\"" + midle + "\",\"" + dest + "\"]");
                System.exit(0);
            }

        }
        System.out.println("Error: Enter valid inputs");

        kb.close();
    }
}
