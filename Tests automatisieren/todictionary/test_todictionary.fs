module test_todictionary

open NUnit.Framework

[<TestFixture>]
type todictionary() =
    let mehrere_Zuweisungsfälle = 
        [
            ("a=1;b=2", [("a", "1"); ("b","2")]);
            ("a=1;;c=3", [("a", "1"); ("c","3")]);
            ("a=;b=2", [("a", ""); ("b","2")]);
        ]

    [<Test>] 
    member x.eine_Zuweisung() =
        let expected = Map.ofList [("a", "1")]
        Assert.AreEqual(expected, ToDictionary.convert "a=1")

    [<Test>]
    member x.mehrere_Zuweisungen() =
        let check (config, expected) = Assert.AreEqual(Map.ofList expected, ToDictionary.convert config)
        mehrere_Zuweisungsfälle |> List.iter check
