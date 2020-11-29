namespace Iterations

open System
open System.Numerics

type PolygonalLine = Vector2 list

module PolygonalLine =
    let map f l =
        let rec map' f l rev =
            match l with
            | [] -> List.rev rev
            | h :: t -> map' f t (h :: rev)

        map' f l []

    let transform h (l: PolygonalLine) =
        let transform' h l proc =
            match l with
            | [] -> List.rev proc
            | [ x ] -> List.rev (x :: proc)
            | (a: Vector2) :: (b: Vector2) :: tail ->
                let d = (a - b).Length
                if d h then
                    List.rev (b :: a :: proc)
                else
                    let c = (a + b) / (float32) 2.0
                    List.rev (b :: c :: a :: proc)

        transform' h l []

