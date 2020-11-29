open System
open System.Numerics
open MathNet.Numerics

let wrap x = complex x 0.0

let ( *| ) (k: float) (z: Complex) = complex (k * z.Real) (k * z.Imaginary)

let f a (z: Complex) = z ** 3.0 + (a - Complex.One) * z - a

let f' a (z: Complex)  = 3.0 *| (z ** 2.0)  + (a - Complex.One)

let nf a z= z - (f z a) / (f' z a)

let f1 = f (complex 0.31 1.62)

let f1' = f' (complex 0.31 1.62)

let nf1 = nf (complex 0.31 1.62)

let h = 0.1

let min = -100

let max = 100

[<EntryPoint>]
let main argv =
    printfn "%A" argv
    0 // return an integer exit code
