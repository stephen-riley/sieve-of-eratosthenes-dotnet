# Sieve of Eratosthenes

The [Sather](https://en.wikipedia.org/wiki/Sather) language developed at ICSI had rich language support for iters, object-oriented generic iterators.  [This paper](https://www.researchgate.net/publication/2623870_Sather_Iters_Object-Oriented_Iteration_Abstraction/link/02e7e5228a6bbebd8c000000/download) showed an elegant (though inefficient!) implementation of the [Sieve of Eratosthenes](https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes) that has fascinated me since I first read it.

![Sieve of Eratosthenes in Sather](img/sieve.png)

This code attempts to realize that nested iterator approach in C# using `IEnumerator<>`.  It is... not as elegant. 😂  Sather has integrated language support for its iters, creating classes under the hood to handle the statefulness of the iters while syntactically allowing the programmer to invoke them like functions.  Definitely makes for more elegant code.

