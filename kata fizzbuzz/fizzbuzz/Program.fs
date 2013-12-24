let fizzbuzz max =
  let convert n =
    let isFizz n = n % 3 = 0
    let isBuzz n = n % 5 = 0
    let isFizzBuzz n = isFizz n && isBuzz n
  
    if   isFizzBuzz n then "FizzBuzz"
    elif isFizz n     then "Fizz"
    elif isBuzz n     then "Buzz"
    else                   n.ToString()
    
  [for i in 1..max -> convert i]

printfn "%A" (fizzbuzz 20)