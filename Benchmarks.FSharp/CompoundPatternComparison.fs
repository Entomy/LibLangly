namespace Benchmarks

open System.Text.Patterns
open FParsec
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Diagnosers

[<ClrJob>]
[<MemoryDiagnoser>]
type CompoundPatternComparison() =
    let commentPattern = "--" >> +(-'\n')
    let commentParsec = attempt (pstring "--" .>>. restOfLine true)

    let identifierPattern = Pattern.Letter >> +(Pattern.Letter || Pattern.DecimalDigitNumber || '_')
    let identifierParsec = attempt (letter .>>. many1Chars (letter <|> digit <|> pchar '_'))

    let phoneNumberPattern = Pattern.Number * 3 >> '-' >> Pattern.Number * 3 >> '-' >> Pattern.Number * 4
    let phoneNumberParsec = attempt (digit .>>. digit .>>. digit .>>. pchar '-' .>>. digit .>>. digit .>>. digit .>>. pchar '-' .>>. digit .>>. digit .>>. digit .>>. digit)

    let stringLiteralPattern = erange "\"" "\"" "\\\""
    let normalChar = satisfy (fun c -> c <> '\\' && c <> '"')
    let unescape c = match c with
                     | 'n' -> '\n'
                     | 'r' -> '\r'
                     | 't' -> '\t'
                     | c -> c
    let escapedChar = pstring "\\" >>. (anyOf "\\nrt\"" |>> unescape)
    let stringLiteralParsec = attempt (between (pstring "\"") (pstring "\"")
                                      (manyChars (normalChar <|> escapedChar)))

    [<Benchmark>]
    member this.CommentPattern() = commentPattern.Consume("--Comment\n");

    [<Benchmark>]
    member this.CommentParsec() = run commentParsec "--Comment\n"

    [<Benchmark>]
    member this.IdentifierPattern() = identifierPattern.Consume("Hello_World")

    [<Benchmark>]
    member this.IdentifierParsec() = run identifierParsec "Hello_World"
    
    [<Benchmark>]
    member this.PhoneNumberPattern() = phoneNumberPattern.Consume("555-555-5555")

    [<Benchmark>]
    member this.PhoneNumberParsec() = run phoneNumberParsec "555-555-5555"

    [<Benchmark>]
    member this.StringLiteralPattern() = stringLiteralPattern.Consume("\"Hello\\\"World\"")

    [<Benchmark>]
    member this.StringLiteralParsec() = run stringLiteralParsec "\"Hello\\\"World\""
