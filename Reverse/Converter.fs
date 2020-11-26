module Reverse.Converter

open System

let tryParseDouble str =
    match Double.TryParse(str) with
    |(true, doubleNumber) -> doubleNumber |> Some
    | _ -> None
    
    