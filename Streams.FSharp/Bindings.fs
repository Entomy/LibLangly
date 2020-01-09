namespace Stringier.Streams

open System.Text

module Bindings =
    type Binder =
        static member Write(stream:#stream, data:byte):#stream =
            stream.WriteByte(data)
            stream
        static member Write(stream:#stream, data:byte[]):#stream =
            for d in data do
                stream.WriteByte(d)
            stream
        static member Write(stream:#stream, data:char):#stream =
            stream.WriteByte(byte data)
            stream
        static member Write(stream:#stream, data:char[]):#stream =
            for d in Encoding.UTF8.GetBytes(data) do
                stream.WriteByte(d)
            stream
        static member Write(stream:#stream, data:string):#stream =
            for d in Encoding.UTF8.GetBytes(data) do
                stream.WriteByte(d)
            stream

    let inline internal write< ^t, ^s, ^d when (^t or ^s or ^d) : (static member Write : ^s -> ^d -> ^s)> stream data = ((^t or ^s or ^d) : (static member Write : ^s -> ^d -> ^s)(stream, data))