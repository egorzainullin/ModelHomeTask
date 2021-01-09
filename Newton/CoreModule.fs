module Newton.CoreModule

    open System
    open System.Numerics
    open MathNet.Numerics

    let wrap x = complex x 0.0

    let ( *| ) (k: float) (z: Complex) = complex (k * z.Real) (k * z.Imaginary)

    let f a (z: Complex) = z ** 3.0 + (a - Complex.One) * z - a

    let f' a (z: Complex)  = 3.0 *| (z ** 2.0)  + (a - Complex.One)

    let nf a z = z - (f z a) / (f' z a)

    let a1 = complex 0.31 1.62

    let f1 = f a1

    let f1' = f' a1

    let nf1 = nf a1

    let a2 = complex 0.275 1.65

    let f2 = f a2

    let nf2 = nf a2 

    let h = 0.01

    let epsilon = 0.01

    let min = -10.0

    let numberOfCellsOnOneLine = 10
    

    let createMatrix = [ for i in [ 0..numberOfCellsOnOneLine - 1 ] do
                             for j in [ 0..numberOfCellsOnOneLine - 1 ] do yield Complex(min + h * double(i),  min + h * double(j)) ]

    let findFixed (func: Complex -> Complex) matrix =
        let filter (z: Complex) =
            Complex.Abs(func(z) - z) < epsilon
        matrix |> List.filter filter
        

