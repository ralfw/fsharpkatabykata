module xUnitTest

open Xunit

[<Fact>]
let Hello_World() =
    Begrüßung.Hallo_sagen |> ignore
