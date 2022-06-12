package main

import (
	"fmt"
	"math/rand"
	"strconv"
	"time"
)

// Solution : Get all diagonal moves for each start and dest, the common element should be the solution
//
// 1 - 8
// A - H

func ConvertToNum(s string) int {
	// 49 = 1, 65 = A -- subtract 16
	byt := []rune(s)
	if byt[0] >= 74 && byt[0] < 84 {
		ret, _ := strconv.Atoi(string((byt[0] - 16 - 10)))
		return ret + 10
	} else if byt[0] >= 84 && byt[0] < 91 {
		ret, _ := strconv.Atoi(string((byt[0] - 16 - 20)))
		return ret
	}
	ret, _ := strconv.Atoi(string((byt[0] - 16)))
	return ret
}
func ConvertToChar(s int) string {
	// 49 = 1, 65 = A -- Add 16
	byt := []rune(strconv.Itoa(s))
	if len(byt) >= 2 {
		sec, _ := strconv.Atoi(string(byt[1]))
		if s >= 10 && s < 20 {
			return string(byt[0] + 16 + 9 + (int32)(sec)) // 49 + 16
		} else if s >= 20 && s <= 26 {
			return string(byt[0] + 16 + 18 + (int32)(sec))
		}
	}

	return string(byt[0] + 16)
}

func combine(s string, i int) string {
	return (s + strconv.Itoa(i))
}

func GetDiagonalMoves(Current string, n, m int) []string {
	letter := Current[0]
	lnum := ConvertToNum(string(letter))
	num, _ := strconv.Atoi(string(Current[1:]))
	possiblemoves := []string{}
	// ====================== //
	poss := []string{"F", "S", "T", "R"}
	numOfC := n
	numOfR := m
	for currentc := range poss {
		for i := 1; i <= numOfC; i++ {
			i2 := 0 // Columns - Letters
			i3 := 0 // ROWS
			if poss[currentc] == "F" || poss[currentc] == "S" {
				i2 = lnum + i
			} else {
				i2 = lnum - i
			}
			if poss[currentc] == "F" || poss[currentc] == "T" {
				i3 = num + i
			} else {
				i3 = num - i
			}
			if poss[currentc] == "F" {
				if i2 > numOfC || i3 > numOfR {
					break
				}
			} else if poss[currentc] == "S" {
				if i2 > numOfC || i3 < 1 {
					break
				}
			} else if poss[currentc] == "T" {
				if i2 < 1 || i3 > numOfR {
					break
				}
			} else if poss[currentc] == "R" {
				if i2 < 1 || i3 < 1 {
					break
				}
			}
			possiblemoves = append(possiblemoves, combine(ConvertToChar(i2), i3))
		}
	}
	return possiblemoves
}

func getBishopPath(n, m int, start, dest string) []string {
	mov1 := GetDiagonalMoves(start, n, m)
	mov2 := GetDiagonalMoves(dest, n, m)
	moves := []string{}
	for i := range mov1 {
		for j := range mov2 {
			if mov1[i] == mov2[j] {
				moves = append(moves, mov1[i])
			}
		}
	}
	if len(moves) > 1 {
		rand.Seed(time.Now().UnixNano()) // for random
		fmt.Printf("%v Possible moves %v\n", len(moves), moves)
		return []string{start, moves[rand.Intn(len(moves))], dest}
	} else if len(moves) == 1 {
		return []string{start, moves[0], dest}
	}
	return []string{"NON"}
}

func main() {
	sol := getBishopPath(16, 14, "F1", "K14")
	fmt.Println(sol)
}
