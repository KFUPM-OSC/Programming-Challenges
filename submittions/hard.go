package main

import (
	"fmt"
	"strconv"
	"strings"
)

// Solution : Get all diagonal moves for each start and dest, the common element should be the solution

// using ASCII to convert between chars and numbers
func ConvertToNum(s string) int {
	// 49 = 1, 65 = A -- subtract 16
	byt := []rune(s)
	if byt[0] >= 74 && byt[0] < 84 {
		ret, _ := strconv.Atoi(string((byt[0] - 16 - 10)))
		return ret + 10
	} else if byt[0] >= 84 && byt[0] < 91 {
		ret, _ := strconv.Atoi(string((byt[0] - 16 - 20)))
		return ret + 20
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

type Point struct {
	Current string
}

func (p *Point) getL() int {
	return ConvertToNum(string(p.Current[0]))
}

func (p *Point) getN() int {
	num, _ := strconv.Atoi(string(p.Current[1:]))
	return num
}

func combine(s string, i int) string {
	return (s + strconv.Itoa(i))
}

func GetDiagonalMoves(Current string, n, m int, obstacle string) []string {
	letter := Current[0]
	lnum := ConvertToNum(string(letter))
	num, _ := strconv.Atoi(string(Current[1:]))
	possiblemoves := []string{}
	// ====================== //
	poss := []string{"F", "S", "T", "R"}
	numOfC := n
	numOfR := m
	mx := func() int {
		if numOfC > numOfR {
			return numOfC
		}
		return numOfR
	}()
	for currentc := range poss {
		for i := 1; i <= mx; i++ {
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
			if (i2 < 1 || i2 > numOfC) || (i3 > numOfR || i3 < 1) {
				break
			}
			key := combine(ConvertToChar(i2), i3)
			if strings.EqualFold(key, obstacle) {
				break
			}
			if !(strings.EqualFold(key, Current)) {
				possiblemoves = append(possiblemoves, key)
			}
		}
	}
	return possiblemoves
}

func findCommonElements(l1, l2 []string) []string {
	ret := []string{}
	for i := range l1 {
		for j := range l2 {
			if l1[i] == l2[j] {
				ret = append(ret, l1[i])
			}
		}
	}
	return ret
}

func getBishopPath(m, n int, start, dest, obstacle string) []string {
	// med & hard
	// Solution: loop through all the diagonal places and check if it is leading to the destination
	// Add the unexplored place and keep searching through its diagonals until we get to the destination or we lose track
	sol := func() []Point {
		sPoint := Point{Current: start}
		if dest == start {
			return []Point{sPoint}
		}
		explored := make(map[int]map[int]bool)
		for i := 0; i < n+1; i++ {
			explored[i] = make(map[int]bool)
			for j := 0; j < m+1; j++ {
				explored[i][j] = false
			}
		}
		lis := make([][]Point, 0)
		lis = append(lis, []Point{sPoint})
		explored[sPoint.getL()][sPoint.getN()] = true
		for len(lis) > 0 {
			nPoint := lis[0]
			currentp := nPoint[len(nPoint)-1]
			lis = lis[1:]
			mover := GetDiagonalMoves(currentp.Current, n, m, obstacle)
			for k := range mover {
				nnPoint := Point{Current: mover[k]}
				if !(explored[nnPoint.getL()][nnPoint.getN()]) {
					explored[nnPoint.getL()][nnPoint.getN()] = true
					newPoint := make([]Point, len(nPoint))
					copy(newPoint, nPoint)
					newPoint = append(newPoint, Point{Current: mover[k]})
					if mover[k] == dest {
						return newPoint
					}
					lis = append(lis, newPoint)
				}
			}
		}
		return nil
	}
	s := sol()
	result := []string{}
	for i := range s {
		result = append(result, s[i].Current)
	}
	if len(result) == 0 {
		return []string{"NON"}
	}
	return result
}

func main() {
	sol := getBishopPath(5, 26, "A1", "B2", "A2")
	fmt.Println(sol)
}
