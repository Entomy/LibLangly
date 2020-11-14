# Streamy Architecture

**Streamy** uses an alternative design behind its streams. This document intends to explain that design. Of particular note is that `Stream` orchestrates the operations of several discrete components, and those components need to be explained.

## StreamBase

This is the actual datastream but with absolutely nothing added to it. It provides the mechanisms for reading and writing as well as information about the streams state. It can be viewed as the absolute most basic stream possible. While it could potentially be used as such, it is not meant to be.

## Buffer

This layers on top of a `StreamBase` to provide buffering behavior. It is split into two broad categories based on `IReadBuffer` and `IWriteBuffer`.

## Stream

This orchestrates the operations of the aforementioned components, while also providing a base for further additional components to orchestrate. In total this is three components: one `StreamBase`, and two buffers, one of which is a `IReadBuffer` and the other a `IWriteBuffer`.