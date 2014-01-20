module xUnit_tests

open System
open Xunit
open Xunit.Extensions
open FsUnit.Xunit

[<Fact>]
let hello_world() =
    printfn "Hello, World!"


[<Fact>]
let eine_Zuweisung'() =
    Assert.Equal<Map<string,string>>(
        Map.ofList [("a", "1")], 
        ToDictionary.convert "a=1")

[<Fact>]
let eine_Zuweisung() =
    ToDictionary.convert "a=1" 
    |> should equal (Map.ofList [("a", "1")])
        

let akzeptanztests = 
    [
        ("a=1;b=2", Map.ofList [("a", "1"); ("b", "2")])
        ("a=1;;b=2", Map.ofList [("a", "1"); ("b", "2")])
        ("a=1;a=2", Map.ofList [("a", "2")])
    ] |> Seq.map (fun (c, e) -> [|c:>Object; e:>Object|]) 


[<Theory>]
[<PropertyData("akzeptanztests")>]
let ``akzeptanztests durchführen`` config expected =
    ToDictionary.convert config
    |> should equal expected

