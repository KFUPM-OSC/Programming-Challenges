arr='ABCDEFGHIJKLMNOPQRSTUVWXYZ'
def line_intersection(n,m,start,end):
    s = [int(arr.index(start[0]))+1,int(start[1:])] # list of the start postiion with the format [a,b] where a and b are int
    e = [int(arr.index(end[0]))+1,int(end[1:])]   # .............. end .......
    if start == end:
        return [end]
    sol1 ,sol2 ='','' # two possible solutions max

    # making two line and finding the intersection between them (positive first)
    solpx = (-s[1]+s[0]+e[1]+e[0])/2
    solpy = solpx+s[1]-s[0]

    if not solpx.is_integer():
        return ['no solution']

    # check if they are on the board
    if solpx>0 and solpx<n+1 and solpy>0 and solpy<m+1:
        sol1= arr[int(solpx)-1]+f'{int(solpy)}'
    

    solnx = (-e[1]+e[0]+s[1]+s[0])/2
    solny = -solnx+s[1]+s[0]
 
   

    if solnx>0 and solnx<n+1 and solny>0 and solny<m+1:
        sol2= arr[int(solnx)-1]+f'{int(solny)}'


    if sol1 ==start or sol1 ==end:
        return [start, end]
    if sol1:
        return [start, sol1, end]
    else:
        return [start, sol2, end]


a = 'F1'
b  = 'K14'
print(line_intersection(16,14,a,b))
