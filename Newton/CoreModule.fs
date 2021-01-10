module Newton.CoreModule

open System
open System.Numerics
open MathNet.Numerics

let wrap x = complex x 0.0

let ( *| ) (k: float) (z: Complex) = complex (k * z.Real) (k * z.Imaginary)

let f a (z: Complex) = z * z * z + (a - Complex.One) * z - a

let f' a (z: Complex) = wrap (3.0) * (z * z) + (a - Complex.One)

let nf a z = z - (f a z) / (f' a z)

let a1 = complex 0.31 1.62

let f1 = f a1

let f1' = f' a1

let nf1 = nf a1

let a2 = complex 0.275 1.65

let f2 = f a2

let nf2 = nf a2

let h = 0.05

let epsilon = 0.5

let min = -1.0

let max = 1.0


let numberOfCellsOnOneLine = 1000

let createMatrix =
    [ for i in [ 0 .. numberOfCellsOnOneLine - 1 ] do
        for j in [ 0 .. numberOfCellsOnOneLine - 1 ] do
            yield Complex(min + double (i) / 500.0, min + double (j) / 500.0) ]

let findFixed (func: Complex -> Complex) matrix =
    let filter (z: Complex) =
        let fz = func (z)
        Complex.Abs(fz - z) < epsilon

    matrix |> List.filter filter
