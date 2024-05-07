# TPL-csharp-workshop

This workshop is a practical application of various techniques related to parallel programming in C#. The main objective is to provide hands-on experience with the concepts and tools necessary to solve problems related to parallel programming.

## Workshop Objectives

After completing this workshop, you will be able to:

- Manipulate a `Parallel.For`
- Manipulate a `Parallel.ForEach`
- Manipulate a `Parallel.Invoke`
- Manipulate Tasks
- Manipulate an event
- Manipulate a delegate multi-cast

All exercises are performed in console-type applications. This workshop is designed to enhance your technical skills in this module. However, consistent work and rigorous implementation are essential for successful completion.

## Duration

This workshop is expected to take approximately 4 hours.

## Exercises

### Q1 — Code Observation

Observe the provided code in the [`Program.cs`](https://github.com/sikatikenmogne/TPL-csharp-workshop/commit/ba841952320025a2d565df6f4146fbba2fb42fdd?diff=unified&w=0#diff-0b69b473fe937040615d69f606751f61ddbc2e3a1849360ff2456c22afe88c0b) file. This code demonstrates the use of delegates, events, and parallel programming constructs.

### Q2 — Code Philosophy

Understand the philosophy of the provided code. What is it trying to achieve and how does it use the concepts of parallel programming to do so?

#### Answer:
The code is trying to achieve a demonstration of how these various parallel programming concepts can be used in C#. It uses delegates, events, and parallel programming constructs to show how multiple tasks can be executed concurrently to improve performance comparing to a normal approach.

### Q3 — Code Translation

Translate the provided code line by line. Understand what each line of code does and how it contributes to the overall functionality of the program.

### Q4 — Parallel.For

Write a simple program that demonstrates the use of `Parallel.For`. This construct is used to execute a `for` loop in parallel, which can significantly improve performance for CPU-bound tasks.

### Q5 — Parallel.ForEach

Write a simple program that demonstrates the use of `Parallel.ForEach`. This construct is used to execute a `foreach` loop in parallel, which can significantly improve performance when processing collections of data.

### Q6 — Parallel.Invoke

Write a simple program that demonstrates the use of `Parallel.Invoke`. This construct is used to execute multiple methods in parallel.

### Q7 — Task.Factory

Write a simple program that demonstrates the use of `Task.Factory`. This construct is used to start and manage tasks.