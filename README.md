﻿# TPL-csharp-workshop

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

Observe the provided code in the [`Program.cs`](https://github.com/sikatikenmogne/TPL-csharp-workshop/blob/main/Program.cs) file. This code demonstrates the use of delegates, events, and parallel programming constructs.

---

### Q2 — Code Philosophy

Understand the philosophy of the provided code. What is it trying to achieve and how does it use the concepts of parallel programming to do so?

#### Answer:
- **[✍️ related "essay"](https://github.com/sikatikenmogne/TPL-csharp-workshop/blob/2-code-philosophy/README.md#q2--code-philosophy)**

---

### Q3 — Code Translation

Translate the provided code line by line. Understand what each line of code does and how it contributes to the overall functionality of the program.

#### Answer:
- **[✍️ related code](https://github.com/sikatikenmogne/TPL-csharp-workshop/blob/3-code-translation/Program.cs)**

---

### Q4 — Parallel.For

Write a simple program that demonstrates the use of `Parallel.For`. This construct is used to execute a `for` loop in parallel, which can significantly improve performance for CPU-bound tasks.

#### Answer:
- **[✍️ related code](https://github.com/sikatikenmogne/TPL-csharp-workshop/blob/4-parallel-for/Program.cs)**

```text
In this code, Parallel.For is used to execute a for loop in parallel. The loop runs from 0 to 9,
and for each iteration,it calculates the square of the current number and prints it. The order 
of the output may vary because the iterations are running in parallel.
```

---

### Q5 — Parallel.ForEach

Write a simple program that demonstrates the use of `Parallel.ForEach`. This construct is used to execute a `foreach` loop in parallel, which can significantly improve performance when processing collections of data.

#### Answer:
- **[✍️ related code](https://github.com/sikatikenmogne/TPL-csharp-workshop/blob/5-parallel-foreach/Program.cs)**

```text
The code you provided is a good example of using Parallel.ForEach to improve performance when
processing large collections of data. It calculates prime numbers in a list using both a 
regular foreach loop and Parallel.ForEach, and compares the time taken for each method.
```

---

### Q6 — Parallel.Invoke

Write a simple program that demonstrates the use of `Parallel.Invoke`. This construct is used to execute multiple methods in parallel.

#### Answer:
- **[✍️ related code](https://github.com/sikatikenmogne/TPL-csharp-workshop/blob/6-parallel-invoke/Program.cs)**

```text
In this code, Parallel.Invoke is used to execute three methods in parallel: BasicAction, 
a lambda expression, and an inline delegate. Each method prints a message to the console 
along with the ID of the thread it's running on
```

---

### Q7 — Task.Factory

Write a simple program that demonstrates the use of `Task.Factory`. This construct is used to start and manage tasks.

#### Answer:
- **[✍️ related code](https://github.com/sikatikenmogne/TPL-csharp-workshop/blob/7-parallel-factory/Program.cs)**

```text
This code is a simple C# program that demonstrates the use of Task.Factory.StartNew.
This method is used to create and start a new Task in one operation.

in this code, an array of Task objects is created. Then, a for loop is used to create
and start a new Task for each element in the array. Each Task prints a message to the 
console indicating that it has started, sleeps for a period of time proportional 
to its index in the array (simulating work), and then prints a message indicating that it has completed. 
```
