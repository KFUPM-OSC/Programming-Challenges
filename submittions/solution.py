comb = {'A': 0, 'B': 1, 'C': 2, 'D': 3, 'E': 4, 'F': 5, 'G': 6, 'H': 7, 'I': 8, 'J': 9, 'K': 10, 'L': 11, 'M': 12, 'N': 13, 'O': 14, 'P': 15, 'Q': 16, 'R': 17, 'S': 18, 'T': 19, 'U': 20, 'V': 21, 'W': 22, 'X': 23, 'Y': 24, 'Z': 25}
key_list = list(comb.keys())
val_list = list(comb.values())

def getBishopPath(n,m, start,dest, obstacle):
    l1 = (comb[start[0]],int(start[1:])-1)
    l2 = (comb[dest[0]],int(dest[1:])-1)
    
    if obstacle == "":
        pawn = (-1,-1)
    else:
        pawn = (comb[obstacle[0]],int(obstacle[1:])-1)
    path = bfs(m,n,l1,l2,pawn)
    if path == None:
        return []
    fin = [f"{key_list[val_list.index(loc[0])]}{int(loc[1]+1)}" for loc in path]
    return fin

def bfs(m, n,start, goal,pawn):
    visited = []
    queue = []
    visited.append(start)
    queue.append([start])
    while queue:
        route = queue.pop(0)
        cur = route[-1]
        for neighbour in getNeighbours(m, n,cur, pawn):
            if neighbour not in visited:
                visited.append(neighbour)
                routeC = route.copy()
                routeC.append(neighbour)
                if neighbour == goal:
                    return routeC
                queue.append(routeC)
    return None
def getNeighbours(m, n, point, pawn):
    m -= 1
    n -= 1
    l = []
    x = point[0]
    y = point[1]
    while(x< m and y < n):
        x +=1
        y += 1
        if(x == pawn[0] and y == pawn[1]):
            break
        l.append((x,y))  
    x = point[0]
    y = point[1]
    while(y < n and x > 0):
        x -=1
        y += 1
        if(x == pawn[0] and y == pawn[1]):
            break
        l.append((x,y))
    x = point[0]
    y = point[1]
    while(x< m and y > 0):
        x +=1
        y -= 1
        if(x == pawn[0] and y == pawn[1]):
            break
        l.append((x,y))
    x = point[0]
    y = point[1]
    while(x > 0 and y > 0):
        x -=1
        y -= 1
        if(x == pawn[0] and y == pawn[1]):
            break
        l.append((x,y))
    return l
