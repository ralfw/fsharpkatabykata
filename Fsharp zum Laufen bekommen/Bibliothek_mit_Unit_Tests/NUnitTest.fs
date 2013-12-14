module NUnitTest

open NUnit.Framework

[<TestFixture>]
type test_Begrüßung() = 

    [<Test>] member self.
        Hello_World() =
            Begrüßung.Hallo_sagen |> ignore
