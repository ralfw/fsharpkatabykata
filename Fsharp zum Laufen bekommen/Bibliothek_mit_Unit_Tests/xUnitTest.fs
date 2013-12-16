module xUnitTest

open Xunit

[<Fact>]
let Hello_World() =
    Begrüßung.Hallo_sagen |> ignore

[<Fact>]
let Hello_World2() =
    Begrüßung.Hallo_ohne_Rückgabe