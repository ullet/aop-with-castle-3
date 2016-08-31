AOP with Castle
===============

A little example using Castle Windsor and Castle DynamicProxy for Aspect-Oriented Programming (AOP).

This small class library and NUnit unit tests demonstrate using an IInterceptor along with an IWindsorContainer to add error handling to methods without muddying the method with other concerns.

The specific scenario being simulated is for the case where a batch of items is being processed.  An error with any one item needs to be handled in some way, e.g. logged to a file, but the remaining items in the batch must still be processed.

---

Castle Core, Castle DynamicProxy, Castle.MicroKernel, and Castle.Windsor are part of the Castle Project.

Castle Project is released under the terms of the [Apache Software Foundation License 2.0](http://www.apache.org/licenses/LICENSE-2.0.html).

See http://www.castleproject.org/ for more details.
