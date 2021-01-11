module LogisticGrid.Model

open System

let fz r c x = r * x * (1 - x) + c

let numberOfPointsOnLine = 128

let genRandomNumbers count1 count2 =
    let rnd = System.Random()
    Array2D.init count1 count2 (fun _ _ -> float(rnd.NextDouble()))

let arr = (genRandomNumbers 128 128)

let deltaX (arr: float[,]) i j =
    let mutable sum = 0.0
    let mutable count = 0
    if i > 0 then
        sum <- sum +  arr.[i - 1, j]
        count <- count + 1
    if i < 127 then
        sum  <- sum + arr.[i + 1, j]
        count <- count + 1
    if j > 0 then
        sum <- sum + arr.[i, j - 1]
        count <- count +  1
    if j < 127 then
        sum <- sum + arr.[i, j + 1]
    sum / (double count)

let calculateNewState(gn: double, cp: double, (arr: float[,])) =
    let copiedArray = Array2D.copy(arr)
    for i in [0..127] do
        for j in [0..127] do
            let dX = deltaX arr i j
            let oldX = arr.[i, j]
            let mutable newValue = 4.0 * gn / 1000.0 * oldX * (1.0-oldX) + cp / 1000.0 * (dX - oldX)
            if newValue > 1.0 then newValue <- 1.0
            if newValue < 0.0 then newValue <- 0.0
            copiedArray.[i, j] <- newValue
    copiedArray

            
let toRGB (value: double) =
    match value with
    | value when value <= 1.0/4.0 -> "rgb(0, 0, 0)"
    | value when value <= 2.0/4.0 -> "rgn(64, 64, 0)"
    | value when value <= 3.0/4.0 -> "rgb(127, 127, 0)" 
    | _ -> "rgb(255, 255)"
    
let pointsWithColor(arr): string[,] = Array2D.map (toRGB) arr

let loadList(arr) = [ for i in [0..127] do
                        for j in [0..127] ->  (i, j, pointsWithColor(arr).[i,j])]

let filter color element =
    match element with
    | (_, _, c) -> color = c
    
let list(arr) = loadList(arr)    
let list1(arr) = list(arr) |> List.filter (filter "rgb(0, 0, 0)") |> List.map (fun (x, y, _) -> x, y)

let list2(arr) = list(arr) |> List.filter (filter "rgn(64, 64, 0)") |> List.map (fun (x, y, _) -> x, y)

let list3(arr) = list(arr) |> List.filter (filter "rgb(127, 127, 0)") |> List.map (fun (x, y, _) -> x, y)

let list4(arr) = list(arr) |> List.filter (filter "rgb(255, 255)") |> List.map (fun (x, y, _) -> x, y)



    
