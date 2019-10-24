---
title: 'Stringier: an implementation of Pattern Combinators, functional and behavioral characteristics'
tags:
  - parsing
  - pattern
  - combinator
authors:
  - name: Patrick Kelly
    orcid: 0000-0002-6293-1084
date: [//]: # (Fill this in)
bibliography: paper.bib
---

# Performance

Everything described prior wouldn't be worth it if the performance was abyssmal, luckily it's not.

All measures were taken on Windows 10 Pro v10.0.18362, Intel i5-6500 @ 3.2GHz, 12GB RAM.

All benchmarking was done through the excellent BenchmarkDotNet, and were run against several runtimes:
 * `Clr` .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.8.4018.0
 * `Core` .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT
 * `CoreRt` .NET CoreRT 1.0.27527.01 @BuiltBy: dlab14-DDVSOWINAGE101 @Branch: master @Commit: bd07c4e0727fa104d50e28ed70ca9bb480dcbc1b, 64bit AOT
 
Benchmarks against FParsec were, unfortunantly, only possible on `Clr`.

## Controls

What is of interest is the performance characteristics of this approach, not the performance of a full stack. Because of the `.NET CLR`, controlling for differences becomes much easier. Having the same runtime means performance differences between runtimes isn't an issue. Multiple languages targeting the same runtime also means that if an approach targets a specific language, comparisons can still be made, as this approach is language agnostic.

The closest analogs for the patterns or parser combinations was chosen for each. The exact values for these still live in the codebase, under both the ``Benchmarks`` and ``Benchmarks.FSharp`` projects, from commit [`1b09d6471b3b0de80b20cd5fd7d12513face6ef2`](https://github.com/Entomy/Stringier/commit/1b09d6471b3b0de80b20cd5fd7d12513face6ef2)

## Primative Components

### Alternates/Options
