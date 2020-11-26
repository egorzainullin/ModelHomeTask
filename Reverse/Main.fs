module Reverse.Main

open System.Numerics
open Reverse.Chart

[<EntryPoint>]
let main argv =
    let runner = new ReverseRunner()
    runner.Run()
    0 // return an integer exit code
